using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight.IoC
{
    class GeneralDialogService : IFindDialogService, IShowNameMessageService
    {
        public GeneralDialogService()
        {
            int a = 10;
        }

        public bool ShowFindDialog()
        {
            System.Windows.MessageBox.Show("ShowFindDialog");
            return true;
        }

        public void ShowName(string name)
        {
            System.Windows.MessageBox.Show($"ShowName-{name}");
        }
    }
}
