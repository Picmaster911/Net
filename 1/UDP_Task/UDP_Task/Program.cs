using System.Net.Sockets;
using System.Net;
using System.Text;

while (true)
{
    var receivedMessage = await ReceiveDataAsync();
    Console.WriteLine($"{receivedMessage} - Message");
}


static async Task <string> ReceiveDataAsync()
{
    // Создаем сокет и другие необходимые ресурсы
    using (UdpClient client = new UdpClient(8888))
    {
        Console.WriteLine("Сервер запущен. Ожидание данных...");

            // Асинхронно ожидаем прихода данных
            UdpReceiveResult result = await client.ReceiveAsync();

            // Получаем данные и информацию об отправителе
            byte[] receivedData = result.Buffer;
            IPEndPoint remoteEP = result.RemoteEndPoint;

            // Преобразуем данные в строку
            string receivedMessage = Encoding.ASCII.GetString(receivedData);

            // Выводим полученное сообщение
            Console.WriteLine($"Получено сообщение от {remoteEP}: {receivedMessage}");
        return receivedMessage;
    }
}
