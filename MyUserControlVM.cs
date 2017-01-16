using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight
{
    class MyUserControlVM : ViewModelBase
    {
        string _someText;

        public String SomeText
        {
            get
            {
                return _someText;
            }
            set
            {
                if (_someText == value)
                    return;

                _someText = value;
                FirePropertyChanged("");
            }
        }

        public String SomeText2
        {
            get
            {
                return _someText + "-2";
            }
            set
            {
                if (_someText + "-2" == value)
                    return;
                    
                _someText = value;
                FirePropertyChanged();
            }
        }

        void FirePropertyChanged([CallerMemberName] string propertyName = null)
        {
            RaisePropertyChanged(propertyName);
        }
    }
}
