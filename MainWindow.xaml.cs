using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMLight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty CurrentPerson = DependencyProperty.RegisterAttached(
            "CurrentPerson",
            typeof(String),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender)
        );
        public static void SetCurrentPerson(UIElement element, String value)
        {
            element.SetValue(CurrentPerson, value);
        }
        public static String GetCurrentPerson(UIElement element)
        {
            return (String)element.GetValue(CurrentPerson);
        }

        public MainWindow()
        {
            InitializeComponent();
         
        }

        
    }
}
