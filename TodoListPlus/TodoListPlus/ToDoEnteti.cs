using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListPlus
{
    public class ToDoEnteti
    {
        public string Name { get; set; }
        public List <CheckBox> CheckBoxesTodo = new();
    }
}
