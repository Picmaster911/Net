using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class CursesItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ItemsInDay { get; set; }
        public int InADay { get; set; }
        public string Description { get; set; }
        public List <Notification> Message { get; set;}
        public Person Person { get; set; }  
        public int PersonId { get; set; }   
    }
}
