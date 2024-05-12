using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.Infrastructure.Commands;
using ToDoList.Model;
using ToDoList.View;

namespace ToDoList.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<CheckBox> _obsTodoColectionItem = new();
        public ObservableCollection<CheckBox> ObsTodoColectionItem
        {
            get => _obsTodoColectionItem;
            set => _obsTodoColectionItem = value;
        }
        private ObservableCollection<ToDoEnteti> _obsTodoColection = new();
        public ObservableCollection<ToDoEnteti> ObsTodoColection
        {
            get => _obsTodoColection;
            set => _obsTodoColection = value;
        }
        private AddToDoItemWindow _addToDoItemWindow;
        private AddToDoListWindow _addToDoListWindow;
        private EditeToDoItemWindow _editeToDoItemWindow;
        private EditeToDoListWindow _editeToDoListWindow;
        private Window _mainWindow;

        private ToDoEnteti _selectedListTodo;
        public ToDoEnteti SelectedListTodo
        {
            get { return _selectedListTodo; }
            set
            {
                _selectedListTodo = value;
                FillSelectetedEnteti();
                OnPropertyChanged();
            }
        }
  
        public MainWindowViewModel()
        {
            DeleteToDoItemCommand = new LambdaCommand(DeleteItem, CanDeleteItem);
            ShowWindowAddToDoItemCommand = new LambdaCommand(ShowWindowAddToDoItem, CanShowWindowAddToDoItem);
            ShowWindowEditeToDoItemCommand = new LambdaCommand(ShowWindowEditeToDoItem, CanShowWindowEditeToDoItem);
            ShowWindowAddToDoListCommand = new LambdaCommand(ShowWindowAddToDoList, CanShowWindowAddToDoList);
            ShowWindowEditeToDoListCommand = new LambdaCommand(ShowWindowEditeToDoList, CanShowWindowEditeToDoList);
            DeleteToDoListCommand = new LambdaCommand(DeleteListTodo, CanDeleteListToDo);
            _mainWindow = Application.Current.MainWindow;

        }
        public void FillSelectetedEnteti()
        {
            _obsTodoColectionItem.Clear();
            if(_selectedListTodo != null) 
            {
                _selectedListTodo.CheckBoxesTodo.ForEach(x => _obsTodoColectionItem.Add(x));
            }       
        }

        private void NewToDoIsReady(object? sender, EventArgs e)
        {
            var vm = sender as AddTodoItemWindowVM;
            var newCheckBox = new CheckBox();
            newCheckBox.Content = vm.NameToDo;
            newCheckBox.Checked += CheckBox_Checked;
            _selectedListTodo.CheckBoxesTodo.Add(newCheckBox);
            ObsTodoColectionItem.Add(newCheckBox);
            OnPropertyChanged(nameof(SelectedListTodo));
            _addToDoItemWindow.Close();

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
          var select = "TestEvent";
        }

        #region Commands
        #region DeleteTodoItemCommand
        public ICommand DeleteToDoItemCommand { get; }

        private void DeleteItem(object p)
        {
            var isChekedItemObs = _obsTodoColectionItem.Where(item => item.IsChecked == true );
            isChekedItemObs.ToList().ForEach(x => _obsTodoColectionItem.Remove(x));
            var isChekedItem = _selectedListTodo.CheckBoxesTodo.Where(item => item.IsChecked == true);
            isChekedItem.ToList().ForEach(x => _selectedListTodo.CheckBoxesTodo.Remove(x));

        }
        private bool CanDeleteItem(object p) => _obsTodoColectionItem.Count == 0 ? false : true;
        #endregion

        #region DeleteToDoListCommand
        public ICommand DeleteToDoListCommand { get; }

        private void DeleteListTodo(object p)
        {
            ObsTodoColection.Remove(_selectedListTodo);
        }
        private bool CanDeleteListToDo(object p) => _selectedListTodo == null ? false : true;
        #endregion



        #region ShowWindowAddTodoItemCommand
        public ICommand ShowWindowAddToDoItemCommand { get; }
        private void ShowWindowAddToDoItem(object p)
        {
            var addTodoItemWindowVM = new AddTodoItemWindowVM();
            addTodoItemWindowVM.NewTodoIsReady += NewToDoIsReady;
            _addToDoItemWindow = new AddToDoItemWindow();
            _addToDoItemWindow.DataContext = addTodoItemWindowVM;
            _addToDoItemWindow.Owner = _mainWindow;
            _addToDoItemWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _addToDoItemWindow.ShowDialog();
        }

        private bool CanShowWindowAddToDoItem(object p) => _selectedListTodo == null ? false:true;
        #endregion

        #region ShowWindowEditeToDoItemCommand
        public ICommand ShowWindowEditeToDoItemCommand { get; }
        private void ShowWindowEditeToDoItem(object p)
        {
            var editeTodoItemWindowVM = new EditeToDoItemWindowVM();
            editeTodoItemWindowVM.EditeTodoIsReady += EditeTodoIsReady;
            _editeToDoItemWindow = new EditeToDoItemWindow();
            _editeToDoItemWindow.DataContext = editeTodoItemWindowVM;
            _editeToDoItemWindow.Owner = _mainWindow;
            _editeToDoItemWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _editeToDoItemWindow.ShowDialog();
        }

        private void EditeTodoIsReady(object? sender, EventArgs e)
        {
            var editeToDoItemWindowVM = sender as EditeToDoItemWindowVM;
            var isChekedItemObs = _obsTodoColectionItem.Where(item => item.IsChecked == true);
            isChekedItemObs.ToList().ForEach(x => x.Content = editeToDoItemWindowVM.NewNameToDo);
            _editeToDoItemWindow.Close();   
        }

        private bool CanShowWindowEditeToDoItem(object p)
        {
            if (SelectedListTodo != null)
                if(SelectedListTodo.CheckBoxesTodo.Count > 0)
                { return true; }
            else { return false; }
            else { return false; }
        }
   
        #endregion

        #region ShowWindowAddToDoListCommand
        public ICommand ShowWindowAddToDoListCommand { get; }
        private void ShowWindowAddToDoList(object p)
        {
            var addToDoListWindowVM = new AddToDoListWindowVM();
            addToDoListWindowVM.NewTodoListIsReady += NewTodoListIsReady;
             _addToDoListWindow = new AddToDoListWindow();
            _addToDoListWindow.DataContext = addToDoListWindowVM;
            _addToDoListWindow.Owner = _mainWindow;
            _addToDoListWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _addToDoListWindow.ShowDialog();
        }

        private void NewTodoListIsReady(object? sender, EventArgs e)
        {
            var vm = sender as AddToDoListWindowVM;
            var newToDo = new ToDoEnteti() { Name = vm.NameToDoList };
            _obsTodoColection.Add(newToDo);
            _addToDoListWindow?.Close();
        }

        private bool CanShowWindowAddToDoList(object p) => true;
        #endregion

        #region ShowWindowEditeToDoItemCommand
        public ICommand ShowWindowEditeToDoListCommand { get; }
        private void ShowWindowEditeToDoList(object p)
        {
            var editeToDoListCommandVm = new EditeToDoListWindowVM();
            editeToDoListCommandVm.NewNameToDoListIsReady += NewNameTodoListIsReady;
            _editeToDoListWindow = new EditeToDoListWindow();
            _editeToDoListWindow.DataContext = editeToDoListCommandVm;
            _editeToDoListWindow.Owner = _mainWindow;
            _editeToDoListWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _editeToDoListWindow.ShowDialog();
        }

        private void NewNameTodoListIsReady(object? sender, EventArgs e)
        {
            if (_selectedListTodo != null)
            {
                var editeToDoListCommandVm = sender as EditeToDoListWindowVM;
                _selectedListTodo.Name = editeToDoListCommandVm.NewNameToDoList;
                RefreshListToDo();
                _editeToDoListWindow.Close();
            }           
        }
        private bool CanShowWindowEditeToDoList(object p) => true;
        #endregion
        #endregion
        public void RefreshListToDo()
        {
            var copyColection = new List<ToDoEnteti>();
            ObsTodoColection.ToList().ForEach(x => copyColection.Add(x));
            ObsTodoColection.Clear();
            copyColection.ForEach(x => ObsTodoColection.Add(x));
        }
 
    }


 
}
