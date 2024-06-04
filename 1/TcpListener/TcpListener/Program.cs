// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Http;


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

   
}