using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Core;

namespace FinalProject.MVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CustViewCommand { get; set; }
        public RelayCommand ProdViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public CustManageModel CustVM { get; set; }
        public ProdManageModel ProdVM { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            CustVM = new CustManageModel();
            ProdVM = new ProdManageModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o=> 
            {
                CurrentView = HomeVM;
            });

            CustViewCommand = new RelayCommand(o =>
            {
                CurrentView = CustVM;
            });

            ProdViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProdVM;
            });
        }
    }
}
