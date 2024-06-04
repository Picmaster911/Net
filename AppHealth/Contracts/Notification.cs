using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTimeShowMassege { get; set; }
        public string Message { get; set; }
        public bool Accept { get; set; }
        public CursesItem CursesItem { get; set; }
        public int CursesItemId { get; set; }
    }
}

