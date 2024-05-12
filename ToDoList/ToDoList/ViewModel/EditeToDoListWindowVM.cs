using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Infrastructure.Commands;

namespace ToDoList.ViewModel
{
    class EditeToDoListWindowVM : ViewModelBase
    {
        public event EventHandler NewNameToDoListIsReady;
        private string _newNameToDoList;
        public string NewNameToDoList
        {
            get { return _newNameToDoList; }
            set
            {
                if (_newNameToDoList != value)
                {
                    _newNameToDoList = value;
                    OnPropertyChanged();
                    ((LambdaCommand)EditeTodoListCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public EditeToDoListWindowVM()
        {
            EditeTodoListCommand = new LambdaCommand(EditeNameTodoListCommand, CanEditEditeNameTodoListCommandd);
        }

        #region AddTodoItemCommand
        public ICommand EditeTodoListCommand { get; }

        private void EditeNameTodoListCommand(object p)
        {
            NewNameToDoListIsReady?.Invoke(this, EventArgs.Empty);
        }
        private bool CanEditEditeNameTodoListCommandd(object p) => String.IsNullOrEmpty(NewNameToDoList) ? false : true;
        #endregion

    }
}
