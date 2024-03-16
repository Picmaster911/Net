using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thead_HW2
{
    internal class Client
    {
        static public int instance;
        public bool _longHear = true;
        public Client(Barbershop barbershop)
        {
            instance = instance + 1;
            var TheadCust = new Thread(() => barbershop.HollEnter(this));
            TheadCust.Name = $"Клиент {instance}";
            TheadCust.Start();

        }
    }
}
