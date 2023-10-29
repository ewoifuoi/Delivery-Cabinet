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
    /// Deposit.xaml 的交互逻辑
    /// </summary>
    public partial class Deposit : Page
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
        public Deposit()
        {
            InitializeComponent();
        }
    }
}
