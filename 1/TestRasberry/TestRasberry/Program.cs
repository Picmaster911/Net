// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Http;
using System.Device.Gpio;
using Iot.Device.Bmxx80;
using System.Device.I2c;


new Thread(() => Client()).Start();
Console.ReadLine();

static async Task Client()
{
    Console.WriteLine("Start");
    int port = 8888;
    TcpListener server = new TcpListener(IPAddress.Any, port);
    server.Start();
    Console.WriteLine("Server started. Waiting for connections...");

    try
    {
        while (true)
        {
            TcpClient client = await server.AcceptTcpClientAsync();
            Console.WriteLine($"Входящее подключение: {client.Client.RemoteEndPoint}");


            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

            // Преобразование полученных данных в строку и их вывод
            string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received message from client: " + receivedMessage);

            // Отправка ответа клиенту (например, эхо-ответ)
            byte[] responseBuffer = Encoding.ASCII.GetBytes("Message received: " + receivedMessage);
            stream.Write(responseBuffer, 0, responseBuffer.Length);
            client.Close();
        }
    }
    finally
    {
        // Остановка прослушивания в случае исключения или завершения работы
        server.Stop();
    }

    void Blink()
    {
        int pin = 18; // Измените на номер вашего GPIO пина
        using (GpioController controller = new GpioController())
        {
            controller.OpenPin(pin, PinMode.Output);

            Console.WriteLine($"GPIO pin {pin} is set to {PinValue.High}");
            controller.Write(pin, PinValue.High);
            Thread.Sleep(1000);

            Console.WriteLine($"GPIO pin {pin} is set to {PinValue.Low}");
            controller.Write(pin, PinValue.Low);
            Thread.Sleep(1000);
        }
    }

    void Icwire ()
    {
        var i2cSettings = new I2cConnectionSettings(1,  DefaultI2cAddress);
    }

}