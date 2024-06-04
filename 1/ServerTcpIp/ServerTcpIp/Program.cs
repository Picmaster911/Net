using System.Net.Sockets;
using System.Text;


new Thread(() => ServerTC()).Start();
Console.ReadLine();
static async Task ServerTC()
{

    using TcpClient tcpClient = new TcpClient();
    Console.WriteLine("Клиент запущен");
    await tcpClient.ConnectAsync("192.168.88.40", 8888);

    if (tcpClient.Connected)
        Console.WriteLine($"Подключение с {tcpClient.Client.RemoteEndPoint} установлено");
    else
        Console.WriteLine("Не удалось подключиться");
    // Получение потока для записи данных в сокет
    using NetworkStream stream = tcpClient.GetStream();

    // Отправка сообщения серверу
    string message = "Hello from client";
    byte[] buffer = Encoding.ASCII.GetBytes(message);
    await stream.WriteAsync(buffer, 0, buffer.Length);
    Console.WriteLine("Сообщение отправлено серверу");

    // Ожидание ответа от сервера (если нужно)
    // ...

    // Закрытие подключения к серверу
    tcpClient.Close();
    Console.WriteLine("Подключение закрыто");
}

