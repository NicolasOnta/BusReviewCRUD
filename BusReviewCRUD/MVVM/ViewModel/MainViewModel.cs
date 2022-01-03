using BusReviewCRUD.Core;
using System;


namespace BusReviewCRUD.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand MenuViewCommand { get; set; }
        public RelayCommand BusesViewCommand { get; set; }
        public RelayCommand ParadasViewCommand { get; set; }
        public RelayCommand ReportesViewCommand { get; set; }
        public RelayCommand ReseniasViewCommand { get; set; }
        public RelayCommand UsuariosViewCommand { get; set; }

        public MenuViewModel MenuVM { get; set; }
        public BusesViewModel BusesVM { get; set; }
        public ParadasViewModel ParadasVM { get; set; }
        public ReportesViewModel ReportesVM { get; set; }
        public ReseniasViewModel ReseniasVM { get; set; }
        public UsuariosViewModel UsuariosVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            MenuVM = new MenuViewModel();
            BusesVM = new BusesViewModel();
            ParadasVM = new ParadasViewModel();
            ReportesVM = new ReportesViewModel();
            ReseniasVM = new ReseniasViewModel();
            UsuariosVM = new UsuariosViewModel();

            CurrentView = MenuVM;

            MenuViewCommand = new RelayCommand(o => { CurrentView = MenuVM; });
            BusesViewCommand = new RelayCommand(o => { CurrentView = BusesVM; });
            ParadasViewCommand = new RelayCommand(o => { CurrentView = ParadasVM; });
            ReportesViewCommand = new RelayCommand(o => { CurrentView = ReportesVM; });
            ReseniasViewCommand = new RelayCommand(o => { CurrentView = ReseniasVM; });
            UsuariosViewCommand = new RelayCommand(o => { CurrentView = UsuariosVM; });
        }
    }
}
