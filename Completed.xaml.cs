using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Completed.xaml 的交互逻辑
    /// </summary>
    public partial class Completed : Page
    {
        public int selected_id = -1;
        List<Button> c_btns = new List<Button>();

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
        public Completed()
        {
            InitializeComponent();

            get_All_cabinet_buttons(this);

            
        }


        public void pick_up(string value)
        {
            
            foreach(var item in this.parentWindow.cabinets)
            {
                if(item.value == value)
                {
                    selected_id = item.id;
                }
            }
            MessageBox.Show(selected_id.ToString());
            
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
                if (ee != null)
                {
                    if (ee.Name != "" && ee.Name.Substring(0, 1) == "c")
                    {
                        Button btn = ee as Button;
                        ee.IsHitTestVisible = false;
                        c_btns.Add(btn);

                    }
                    get_All_cabinet_buttons(ee);
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.container.Navigate(this.parentWindow.welcome);
            this.ParentWindow.Init_All_Pages();
        }
    }
}
