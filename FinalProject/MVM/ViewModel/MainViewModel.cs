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

        // commands for each view
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CustViewCommand { get; set; }
        public RelayCommand ProdViewCommand { get; set; }

        // view models for each view
        public HomeViewModel HomeVM { get; set; }
        public CustManageModel CustVM { get; set; }
        public ProdManageModel ProdVM { get; set; }

        // property to hold current displayed view
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged(); // notify the ui of a change
            }
        }
        public MainViewModel()
        {
            // initialize each view model and set the current view to the homeVM
            HomeVM = new HomeViewModel();
            CustVM = new CustManageModel();
            ProdVM = new ProdManageModel();
            CurrentView = HomeVM;

            // Set up the commands for each view, which change the current view when executed
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
