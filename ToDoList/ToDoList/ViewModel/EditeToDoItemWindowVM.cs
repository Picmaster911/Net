using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Infrastructure.Commands;

namespace ToDoList.ViewModel
{
    class EditeToDoItemWindowVM
    {
        public event EventHandler EditeTodoIsReady;
        public string NewNameToDo { get; set; }

        public EditeToDoItemWindowVM()
        {
            EditeTodoItemCommand = new LambdaCommand(EditeTodoIteCommand, CanEditeTodoIteCommand);
        }

        #region AddTodoItemCommand
        public ICommand EditeTodoItemCommand { get; }

        private void EditeTodoIteCommand(object p)
        {
            EditeTodoIsReady?.Invoke(this, EventArgs.Empty);
        }
        private bool CanEditeTodoIteCommand(object p) => String.IsNullOrEmpty(NewNameToDo) ? false : true;
        #endregion

    }
}
