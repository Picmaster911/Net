using AppHealth.Infrastructure;
using AppHealth.Model;
using AppHealth.View;
using AppHealth.ViewModel.Elements;
using Contracts;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AppHealth.ViewModel
{
    internal class MainWindowViewModel:ViewModelBase
    {
        private Window _mainWindow;
        private Window _addPerssonWindow;
        private AddPerssonViewModel _addPerssonViewModel;

        private BitmapImage _avatarImage;
        public BitmapImage AvatarImage
        {
            get => _avatarImage;
            set { _avatarImage = value; OnPropertyChanged(); }
        }

        private IApplicationDbContext _dbContext;

        #region ButtonCommandsName
     
        public ICommand ShowAddSetingWindowCommand { get; set; }
        #endregion
        public ObservableCollection<PersonItemViewModel> PersonItemVMObserv {get; set;}
        public MainWindowViewModel(IApplicationDbContext dbContext, CreateGlobalDO createGlobalDO)
        {
            _mainWindow = Application.Current.MainWindow;        
            ShowAddPersonWindowCommand = new LambdaCommand(OnAddPerssonWindowCommand, CanAddPerssonWindowCommand);
            _dbContext = dbContext;
            PersonItemVMObserv = createGlobalDO.PersonItemVMObserv;
        }
       
        //AvatarImage = ToImage(x.AvatarImageData)

        //      public BitmapImage ToImage(byte[] array) 
        //     {
        //         if (array != null)
        //         {
        //             using (System.IO.MemoryStream ms = new System.IO.MemoryStream(array))
        //            {
        //                BitmapImage image = new BitmapImage();
        //                image.BeginInit();
        //                image.StreamSource = ms;
        //                image.EndInit();
        //               return image;
        //           }
        //       }
        //        return new BitmapImage();
        //    }
        #region ButtonCommandsMethod
        #endregion
        public ICommand ShowAddPersonWindowCommand { get; }

        private void OnAddPerssonWindowCommand(object p)
        {
            _addPerssonViewModel = new AddPerssonViewModel(_dbContext, this);
            _addPerssonWindow = new AddPerssonWindow();
            _addPerssonWindow.DataContext = _addPerssonViewModel;
            _addPerssonWindow.Owner = _mainWindow;
            _addPerssonWindow.WindowStartupLocation= WindowStartupLocation.CenterOwner;
            _addPerssonViewModel.NewPersonIsReady += CloseWindowCommand;
            _addPerssonWindow.ShowDialog();
        }

        private void CloseWindowCommand(object? sender, EventArgs e)
        {
            _addPerssonWindow.Close();  
        }
        private bool CanAddPerssonWindowCommand (object p)
        {
            return true;
        }

    
    }
}
