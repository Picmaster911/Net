using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string SurName { get; set; }

        public string AvatarImageData { get; set; }  
        public List <CursesItem> Curses { get; set; }
    }
}
