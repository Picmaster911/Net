using AppHealth.View.Elements;
using AppHealth.ViewModel.Elements;
using Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealth.ViewModel
{
    internal class AllNotifyColWindowViewModel:ViewModelBase
    {
        public ObservableCollection<NotifyItemViewModel> ListNotify {  get; set; }    

        public AllNotifyColWindowViewModel(ObservableCollection <NotifyItemViewModel> list)
        {
            ListNotify = list;
        }
    }
}
