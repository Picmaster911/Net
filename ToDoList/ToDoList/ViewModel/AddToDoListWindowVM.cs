using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.Infrastructure.Commands;

namespace ToDoList.ViewModel
{
    internal class AddToDoListWindowVM: ViewModelBase
    {
        public event EventHandler NewTodoListIsReady;
        private string _nameToDoList;
        public string NameToDoList
        {
            get { return _nameToDoList; }
            set
            {
                if ( _nameToDoList != value)
                {
                    _nameToDoList = value;
                    OnPropertyChanged();
                    ((LambdaCommand)AddTodoListToDoCommand).RaiseCanExecuteChanged();
                }
            }
        }
        public AddToDoListWindowVM()
        {
            AddTodoListToDoCommand = new LambdaCommand(AddTodoList, CanAddTodoList);
        }

        #region AddTodoListToDoCommand
        public ICommand AddTodoListToDoCommand { get; }

        private void AddTodoList(object p)
        {
            NewTodoListIsReady?.Invoke(this, EventArgs.Empty);
        }
        private bool CanAddTodoList(object p) => String.IsNullOrEmpty(NameToDoList) ? false : true ;
        #endregion


    }
}
