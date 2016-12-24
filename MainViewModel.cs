using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MVVMLight
{
    class MainViewModel : ViewModelBase
    {
        private string _status;
        private Random _rand;

        public MainViewModel()
        {
            _rand = new Random();
            RequestStatus = new RelayCommand(() => Task.Factory.StartNew(() => { Thread.Sleep(1000); StatusChanged("Status " + _rand.Next().ToString());}));
        }

        public String Status
        {
            get { return _status; }
            set
            {
                Set(() => Status, ref _status, value);                
            }
        }


        public RelayCommand RequestStatus
        {
            get;
            private set;
        }

        public void StatusChanged(String newStatus)
        {
           Status = newStatus;
        }

    }
}
