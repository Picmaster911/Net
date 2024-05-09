using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoListPlus
{
    public partial class EditeElementFormscs : Form
    {
        public string name;
        public EditeElementFormscs()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void EditeElementButton_Click(object sender, EventArgs e)
        {
            name = EditeTodoItemBox.Text;

            if (!string.IsNullOrWhiteSpace(name))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (string.IsNullOrWhiteSpace(name))
            {
                editeNewTodoItemErrorLabel.Text = "List name cannot be empty!";
                editeNewTodoItemErrorLabel.Show();
            }
            else
            {
                editeNewTodoItemErrorLabel.Text = "This name is already in use!";
                editeNewTodoItemErrorLabel.Show();
            }
        }
    }
    
}

