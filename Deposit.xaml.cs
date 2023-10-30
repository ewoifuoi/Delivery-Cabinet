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

        List<Button> c_btns;
        Cabinet cabinet;
        private int state = 0;

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
            c_btns = new List<Button>();
            get_All_cabinet_buttons(this);
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.Init_All_Pages();
            this.parentWindow.container.Navigate(this.parentWindow.welcome);
        }

        /// <summary>
        /// 柜子图标被点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cabinet_Selected(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            cabinet_data.Visibility = Visibility.Visible;
            cabinet_prompt.Visibility = Visibility.Collapsed;

            for(int i = 0; i < 26; i++)
            {
                c_btns[i].BorderThickness = new Thickness(1);
                c_btns[i].BorderBrush = new SolidColorBrush(Colors.Gray);
            }

            btn.BorderThickness = new Thickness(5);
            btn.BorderBrush = new SolidColorBrush(Colors.DarkRed);

            int uid = btn.Name.Substring(2, 1).ToCharArray()[0] - 'A';
            id.Text = uid.ToString();

            this.parentWindow.selected_id = uid;

            tem.Text = MainWindow.cabinets[uid].temperature.ToString();
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
                        c_btns.Add(btn);
                        
                    }
                    get_All_cabinet_buttons(ee);
                }
                
            }
        }

        public void getCabinetsState()
        {
            int sum = 0;
            foreach(var item in MainWindow.cabinets)
            {
                if(item.isAvaliable == true)
                {
                    sum++;
                }
            }
            cabinets_num.Text = sum.ToString();

            for(int i = 0; i < 26; i++)
            {
                c_btns[i].Click += Cabinet_Selected;

                int id = c_btns[i].Name.Substring(2, 1).ToCharArray()[0] - 'A';
                if (MainWindow.cabinets[id].isAvaliable == false)
                {
                    c_btns[i].IsHitTestVisible = false;
                    c_btns[i].Background = new SolidColorBrush(Colors.Silver);
                }
            }
            
        }

        private void ChooseCondition(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            v_0.IsEnabled = true; v_1.IsEnabled = true; v_2.IsEnabled = true;
            v_0.Background = enter.Background; v_1.Background = enter.Background;v_2.Background = enter.Background;

            if (btn.Name == "v_0") state = 0; if (btn.Name == "v_1") state = 1; if (btn.Name == "v_2") state = 2;
            MainWindow.cabinets[parentWindow.selected_id].state = state;
            btn.Background = new SolidColorBrush(Colors.LightGreen);
        }

        private void deposit_cabinet(object sender, RoutedEventArgs e)
        {
            
            this.parentWindow.depositing  = new Depositing(this.parentWindow);
            
            
            this.parentWindow.container.Navigate(this.parentWindow.depositing);
            
        }
    }
}
