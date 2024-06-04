using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Input;
using AppHealth.Infrastructure;
using Contracts;
using System.IO;
using System.Collections.ObjectModel;
using AppHealth.View;


namespace AppHealth.ViewModel.Elements
{
    class PersonItemViewModel : ViewModelBase
    {
        private BitmapImage _avatarImage;
        private Window _addSettingWindow;
        private Window _mainWindow;

        private IApplicationDbContext _dbContext;
        private string _avatarImagePath;
        public  string AvatarImagePath { get => _avatarImagePath;
            set {
                _avatarImagePath = value;
                LoadAvatar(AvatarImagePath);               
            }}
        public BitmapImage AvatarImage
        {
            get {  return _avatarImage; }
            set { _avatarImage = value; OnPropertyChanged();  }
        }
        private string _name;
        private string  _surname;
        private int _id;
       
        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string Surname { get => _surname; set { _surname = value; OnPropertyChanged(); } }

        public List <CursesItemViewModel> Curses { get; set; }
        public PersonItemViewModel(IApplicationDbContext dbContext)
        {
            _mainWindow = Application.Current.MainWindow;
            LoadImageCommand = new LambdaCommand(OnLoadImageCommand, CanOnLoadImageCommand);
            _dbContext = dbContext;
            ButtonShowCurses = new LambdaCommand(OnButtonShowCurses,CanButtonShowCurses);
        }

        private BitmapImage LoadAvatar(string path)
        {
            try 
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                AvatarImage = bitmap;
                return bitmap;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
                return new BitmapImage();
            }
        }
        #region commands
        #region ButtonLoadImageCommand
        public ICommand LoadImageCommand { get; set; }
        private void OnLoadImageCommand(object p)
        {
            PersonItemViewModel viewModel = (PersonItemViewModel)p;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = LoadAvatar(openFileDialog.FileName);
                    SaveAvatarToFolder(viewModel, bitmap);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
                }
            }
        }
        private bool CanOnLoadImageCommand(object p)
        {
            return true;
        }
        #endregion
        #region ButtonShowCurses
        public ICommand ButtonShowCurses {  get; set; } 
        public void OnButtonShowCurses (object p)
        {
            _addSettingWindow = new AddSettingWindow();
            _addSettingWindow.DataContext = new AddSettingWindowViewModel(_dbContext, this);
            _addSettingWindow.Owner = _mainWindow;
            _addSettingWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _addSettingWindow.ShowDialog();
        }
        public bool CanButtonShowCurses  (object p)
        {
            return true;
        }
        #endregion
        #endregion
        public void ConvertImgToByte(BitmapImage bitmap)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
        }
        public void SaveAvatarToFolder(PersonItemViewModel viewModel, BitmapImage bitmap)
        {
            var FileName = $"{Id}_{Name}_{Surname}";
            var location = Directory.GetCurrentDirectory();
            var allDir = Directory.GetDirectories(location);
            DirectoryInfo myDir = new DirectoryInfo($"{location}\\img");
            if (!allDir.Contains($"{location}\\img"))
            {
                myDir.Create();
            }

            var item = _dbContext.Persons.Where(x => x.Id == viewModel.Id).FirstOrDefault();
            item.AvatarImageData = $"{location}\\img\\{FileName}.jpg";
            _dbContext.SaveChangesAsync();

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var fileStream = new FileStream($"{location}\\img\\{FileName}.jpg", FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }
    }
}
