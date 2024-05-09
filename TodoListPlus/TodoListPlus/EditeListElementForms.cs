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
    public partial class EditeListElementForms : Form
    {

        public string name;
        public EditeListElementForms()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void EditeTodoListTextButton_Click(object sender, EventArgs e)
        {
            name = EditeTodoListTextBox.Text;

            if (!string.IsNullOrWhiteSpace(name))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (string.IsNullOrWhiteSpace(name))
            {
                EditeTodoListTextBox.Text = "List name cannot be empty!";
                EditeTodoListTextBox.Show();
            }
            else
            {
                EditeTodoListTextBox.Text = "This name is already in use!";
                EditeTodoListTextBox.Show();
            }

        }
    }
}
