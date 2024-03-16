using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thead_HW2
{
    internal class Barbershop
    {
        static int maxClient = 5;
        static int _countClients = 0;
        static Semaphore semHaircut = new Semaphore(1, 1);
        static Semaphore enter = new Semaphore(1, 1);

        public void HollEnter(Client client)
        {
            enter.WaitOne();
            if (_countClients < maxClient)
            {
                _countClients++;
                Console.WriteLine($"Клиент вошел в хол count {_countClients} занял место");
                var TheadCust = new Thread(() => Wait(client));
                TheadCust.Name = $"{_countClients} - клиент ";
                TheadCust.Start();              
            }
            else
            {
                Console.WriteLine($"Приходил клиент{Thread.CurrentThread.Name} но нет места"); ;
            }           
            enter.Release();         
        }

        public void Wait(Client client)
        {
            while (client._longHear)
            {
                Haircut(client);
            }
        }

        static void Haircut (Client client)
        {
            semHaircut.WaitOne();
            Thread.Sleep(2000);
            Console.WriteLine($"---------------------------------------------------------------");
            Console.WriteLine($" Постригся {Thread.CurrentThread.Name} || Свободных мест: {maxClient - _countClients+1} ");
            client._longHear = false;
            semHaircut.Release();
            _countClients--;
        }
    }
}
