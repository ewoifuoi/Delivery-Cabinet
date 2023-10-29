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

namespace Delivery_Cabinet
{
    /// <summary>
    /// Welcome.xaml 的交互逻辑
    /// </summary>
    
    public partial class Welcome : Page
    {

        public MainWindow parentWindow;
        public MainWindow ParentWindow
        {
            get
            {
                return parentWindow;
            }
            set
            {
                parentWindow = value;
            }
        }

        public Welcome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.parentWindow.container.Navigate(this.parentWindow.pick_up);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.parentWindow.container.Navigate(this.parentWindow.deposit);
        }
    }
}
