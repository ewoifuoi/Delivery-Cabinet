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
    /// Pick_up.xaml 的交互逻辑
    /// </summary>
    /// 



    public partial class Pick_up : Page
    {

        public string value = "";
        public int index = 0;
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

        public Pick_up()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.container.Navigate(this.parentWindow.welcome);
        }

        private void Keyboard_Event(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button; if (btn != null)
            {
                MessageBox.Show(btn.Name);
            }
        }

    }
}
