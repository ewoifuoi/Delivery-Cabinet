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
            get_All_cabinet_buttons(this);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.Init_All_Pages();
            this.parentWindow.container.Navigate(this.parentWindow.welcome);
        }

        /// <summary>
        /// 遍历逻辑树获得箱体按钮实例
        /// </summary>
        /// <param name="e"></param>
        public void get_All_cabinet_buttons(FrameworkElement e)
        {
            foreach (var item in LogicalTreeHelper.GetChildren(e))
            {
                FrameworkElement ee = item as FrameworkElement;
                if(ee != null)
                {
                    if(ee.Name != "" && ee.Name.Substring(0,1) == "c")
                    {
                        Button btn = ee as Button;
                        int index = ee.Name.Substring(2, 1).ToCharArray()[0] - 65;
                        this.parentWindow.cabinets[index].c_btn = btn;
                    }
                    get_All_cabinet_buttons(ee);
                }
                
            }
        }
    }
}
