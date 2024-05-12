using System.Windows.Input;
using ToDoList.Infrastructure.Commands;

namespace ToDoList.ViewModel
{
    internal class AddTodoItemWindowVM: ViewModelBase
    {
        public event EventHandler NewTodoIsReady;
        public string NameToDo {  get; set; }   

        public AddTodoItemWindowVM()
        {
            AddTodoItemCommand = new LambdaCommand(AddTodoItem, CanAddTodoItem);
        }

        #region AddTodoItemCommand
        public ICommand AddTodoItemCommand { get; }

        private void AddTodoItem(object p)
        {
            NewTodoIsReady?.Invoke(this, EventArgs.Empty);
        }
        private bool CanAddTodoItem(object p) => true;
        #endregion

    }
}
