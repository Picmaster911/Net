using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDoList.Model
{
    internal class ToDoEnteti
    {
        public string Name { get; set; }
        public List <CheckBox> CheckBoxesTodo = new();
    }
}
