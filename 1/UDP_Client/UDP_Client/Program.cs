using System.Net.Sockets;
using System.Text;

string ipAddress = "127.0.0.1";
int port = 8888;

while (true)
{
    // Создание UDP клиента
    using (UdpClient client = new UdpClient())
    {
        // Преобразование строки в байты
        byte[] data = Encoding.ASCII.GetBytes("Hello from .NET!");

        // Отправка данных на микроконтроллер
        client.Send(data, data.Length, ipAddress, port);

        Console.WriteLine("Data sent to microcontroller.");
    }
Thread.Sleep(7000);
}
