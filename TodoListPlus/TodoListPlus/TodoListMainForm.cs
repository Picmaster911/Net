using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TodoListPlus
{
    public partial class TodoListMainForm : Form
    {
        public List<ToDoEnteti> TodoLists = new();
        public List<string> TodoItems = new();
        public List<bool> IsComplete = new();
        private string TodoListsPath = "../../../todo-lists.txt";
        private string TodoItemsPath;
        private ToDoEnteti _selectedItem;
        private CheckBox _selectedCheckBox;
        private int _selactedIndcheckBox;

        public TodoListMainForm()
        {
            InitializeComponent();
            //if (!Directory.Exists("../../../lists"))
            //{
            //    Directory.CreateDirectory("../../../lists");
            //}

            TodoListsListBox.DataSource = TodoLists;
            TodoListsListBox.SelectedIndex = -1;
            NoTodoListSelected();
        }

        private void NoTodoListSelected()
        {
            CurrentListLabel.Text = "Choose or create new Todo list";
            DeleteListBtn.Enabled = false;
            RenameBtn.Enabled = false;
            RenameListBtn.Enabled = false;
            RemoveBtn.Enabled = false;
            AddBtn.Enabled = false;
        }

        private void AddTodoList_Click(object sender, EventArgs e)
        {
            var toDo = new ToDoEnteti();
            CreateNewListForm createNewListForm = new CreateNewListForm(TodoLists);
            createNewListForm.ShowDialog();

            if (createNewListForm.DialogResult == DialogResult.OK)
            {
                toDo.Name = createNewListForm.name;
                TodoLists.Add(toDo);

                TodoListsListBox.DataSource = null;
                TodoListsListBox.DisplayMember = "Name";
                TodoListsListBox.DataSource = TodoLists;
                // TODO: add saving to text file

                TodoListsListBox.SelectedIndex = TodoLists.Count() - 1;
            }
        }

        private void TodoListsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TodoItems.Clear();
            IsComplete.Clear();
            checkedListBoxTodoItems.Items.Clear();

            if (TodoListsListBox.SelectedIndex == -1)
            {
                NoTodoListSelected();
                return;
            }
            _selectedItem = TodoListsListBox.SelectedItem as ToDoEnteti;
            CurrentListLabel.Text = _selectedItem?.Name ?? "Select todo list";

            DeleteListBtn.Enabled = true;
            RenameBtn.Enabled = true;
            AddBtn.Enabled = true;
            RenameListBtn.Enabled = true;

            // show todo items on UI
            checkedListBoxTodoItems.DisplayMember = "Name";

            for (int i = 0; i < _selectedItem.CheckBoxesTodo.Count(); i++)
            {
                checkedListBoxTodoItems.Items.Add(_selectedItem.CheckBoxesTodo[i]);
                if (_selectedItem.CheckBoxesTodo[i].Checked == true)
                {
                    checkedListBoxTodoItems.SetItemChecked(i, true);
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddTodoItemForm createNewItemForm = new AddTodoItemForm(_selectedItem);
            createNewItemForm.ShowDialog();
            checkedListBoxTodoItems.DisplayMember = "Name";
            checkedListBoxTodoItems.Items.Add(createNewItemForm.NewCheckBox);

            // open AddTodoItemForm
            // add logic for saving new todo item 
        }

        private void TodoListsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckBox checkedItemText = checkedListBoxTodoItems.Items[e.Index] as CheckBox;
            string checkedItemName = checkedListBoxTodoItems.Items[e.Index].ToString();


            if (e.NewValue == CheckState.Checked)
            {
                var selected = _selectedItem.CheckBoxesTodo.Where(x => Equals(x, checkedItemText) == true).FirstOrDefault();
                selected.Checked = true;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                var selectedOff = _selectedItem.CheckBoxesTodo.Where(x => Equals(x, checkedItemText) == true).FirstOrDefault();
                selectedOff.Checked = false;
            }
        }

        private void TodoCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox checkBox = sender as CheckedListBox;
            _selactedIndcheckBox = checkBox.SelectedIndex - 1;
            RenameListBtn.Enabled = true;
            RemoveBtn.Enabled = true;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBoxTodoItems.CheckedItems.Count - 1; i >= 0; i--)
            {
                var checkItem = checkedListBoxTodoItems.CheckedItems[i];
                checkedListBoxTodoItems.Items.Remove(checkItem);
                _selectedItem.CheckBoxesTodo.Remove((CheckBox)checkItem);
            }
        }

        private void RenameBtn_Click(object sender, EventArgs e)
        {

            EditeElementFormscs RditeNameItem = new EditeElementFormscs();
            RditeNameItem.ShowDialog();
            checkedListBoxTodoItems.DisplayMember = "Name";
            var name = RditeNameItem.name;
            for (int i = checkedListBoxTodoItems.CheckedItems.Count - 1; i >= 0; i--)
            {
                var checkItem = (CheckBox)checkedListBoxTodoItems.CheckedItems[i];
                checkItem.Name = name;
                checkItem.Text = name;
            }
            checkedListBoxTodoItems.Refresh();
        }

        private void RenameListBtn_Click(object sender, EventArgs e)
        {
            EditeListElementForms EditeNameList = new EditeListElementForms();
            EditeNameList.ShowDialog();
            checkedListBoxTodoItems.DisplayMember = "Name";
            var name = EditeNameList.name;

            _selectedItem.Name = name;
            TodoListsListBox.DataSource = null;
            TodoListsListBox.DisplayMember = "Name";
            TodoListsListBox.DataSource = TodoLists;
            TodoListsListBox.Refresh();
        }

        private void DeleteListBtn_Click(object sender, EventArgs e)
        {           
            TodoLists.Remove(_selectedItem);
            TodoListsListBox.DataSource = null;
            TodoListsListBox.DisplayMember = "Name";
            TodoListsListBox.DataSource = TodoLists;
        }
    }
}