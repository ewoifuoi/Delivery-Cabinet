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
        /// <summary>
        /// 输入的取货码
        /// </summary>
        public string value = "";
        /// <summary>
        /// 取货码光标
        /// </summary>
        public int index = 0;

        public List<TextBox> input = new List<TextBox>();

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

            input.Add(value_0); input.Add(value_1); input.Add(value_2); input.Add(value_3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.container.Navigate(this.parentWindow.welcome);
        }

        private void Keyboard_Event(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            if (btn.Name == "key_Clear") Clear();
            else if(btn.Name == "key_Back")
            {
                
                input[index].Clear();
                if (index != 0) 
                {
                    value = value.Substring(0, value.Length - 1);
                    index--;
                }
            }
            else
            {
                if(index < 4)
                {
                    input[index].Text = "1";
                    value += input[index].Text;
                    index++;
                }
            }

        }

        private void Open_Cabinet(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(value);
            if(parentWindow.CheckValue(value))
            {

            }
            else
            {

            }
        }

        private void Clear()
        {
            foreach(var item in input)
            {
                item.Clear();
            }
            value = "";
            index = 0;
        }
    }
}
