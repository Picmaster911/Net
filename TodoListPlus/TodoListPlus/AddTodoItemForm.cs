using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TodoListPlus
{
    public partial class AddTodoItemForm : Form
    {
        private ToDoEnteti _selectedItem;
        public string name;
        public CheckBox NewCheckBox;
        public AddTodoItemForm(ToDoEnteti selectedItem)
        {
            _selectedItem = selectedItem;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddTodoItemtBtn_Click(object sender, EventArgs e)
        {
            name = addNewTodoItemTextBox.Text;
            NewCheckBox = new CheckBox { Name = addNewTodoItemTextBox.Text, Text = addNewTodoItemTextBox.Text, };         
            _selectedItem.CheckBoxesTodo.Add(NewCheckBox);

            if (!string.IsNullOrWhiteSpace(name))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (string.IsNullOrWhiteSpace(name))
            {
                addNewTodoItemErrorLabel.Text = "List name cannot be empty!";
                addNewTodoItemErrorLabel.Show();
            }
            else
            {
                addNewTodoItemErrorLabel.Text = "This name is already in use!";
                addNewTodoItemErrorLabel.Show();
            }
        }

    }
}
