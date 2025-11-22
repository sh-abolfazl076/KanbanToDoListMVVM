using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanToDoListMVVM.ViewModels.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public MainViewModel() 
        {
            CurrentViewModel = new LoginViewModel();
        }
    }
}
