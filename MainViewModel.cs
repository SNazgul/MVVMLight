using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using MVVMLight.IoC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
            RequestStatus = new RelayCommand(() => Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    //StatusChanged("Status " + _rand.Next().ToString());
                    StatusChangedThroughDispatcher("Status " + _rand.Next().ToString());
                }));
        }

        #region Left top cell

        public String Status
        {
            get { return _status; }
            set
            {
                Set(ref _status, value);                
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

        public void StatusChangedThroughDispatcher(String newStatus)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => StatusChanged(newStatus));
        }

        #endregion


        #region Top right cell

        private RelayCommand _requestWebStatusCommand;
        private string _statusWebRequest;
        private string _webRequestTest;

        public String StatusWebRequest
        {
            get { return _statusWebRequest; }
            set
            {
                Set(ref _statusWebRequest, value);
            }
        }

        public String WebRequestTest
        {
            get { return _webRequestTest; }
            set
            {
                Set(ref _webRequestTest, value);
            }
        }

        public RelayCommand RequestWebStatusCommand
        {
            get
            {
                return _requestWebStatusCommand ?? (_requestWebStatusCommand = new RelayCommand(
                    () =>
                    {
                        var request = WebRequest.Create("http://www.galasoft.ch");
                        request.BeginGetResponse(BeginGetResponseCompleted, request);
                    }));
            }
        }

        private void BeginGetResponseCompleted(IAsyncResult ar)
        {
            var request = ar.AsyncState as HttpWebRequest;
            if (request != null)
            {
                using (var stream = request.EndGetResponse(ar).GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var result = reader.ReadToEnd();
                        WebRequestTest = result;
                        StatusWebRequest = "Web page was loaded";
                    }
                }
            }
        }

        #endregion



        #region Right bottom cell

        public void RequestInteraction()
        {
            InteractionText = Guid.NewGuid().ToString();
        }

        private String _interactionTest;

        public String InteractionText
        {
            get
            {
                return _interactionTest;
            }

            set
            {
                Set(ref _interactionTest, value);
            }
        }

        #endregion

        #region Right bottom cell

        public void TestIoC()
        {
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Register<GeneralDialogService>();
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Register<IFindDialogService>(() => GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<GeneralDialogService>());
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Register<IShowNameMessageService>(() => GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<GeneralDialogService>());

            var srv = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<IFindDialogService>();
            srv.ShowFindDialog();
            var srv2 = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<IShowNameMessageService>();
            srv2.ShowName("Papaya");
        }

        #endregion

    }
}
