﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Delivery_Cabinet
{
    /// <summary>
    /// Completed.xaml 的交互逻辑
    /// </summary>
    public partial class Completed : Page
    {
        public int selected_id = -1;
        List<Button> c_btns = new List<Button>();

        public LinearGradientBrush lb;

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
        public Completed(string value, MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;

            get_All_cabinet_buttons(this);

            
            pick_up(value);

            SolidColorBrush ys = new SolidColorBrush();//颜色绘制

            ColorAnimation ks = new ColorAnimation();//颜色动画处理
            ks.From = Colors.DarkGray;//初始颜色
            ks.To = Colors.IndianRed;//结束颜色
            ks.AutoReverse = true;//反向播放动画
            ks.RepeatBehavior = RepeatBehavior.Forever;//无限循环播放
            ks.Duration = new Duration(TimeSpan.FromMilliseconds(500));//动画一次所用时间
            ys.BeginAnimation(SolidColorBrush.ColorProperty, ks);//颜色绘制使用动画绘制
            c_btns[selected_id].Background = ys;//窗体背景颜色为绘制颜色



        }



        public void pick_up(string value)
        {
            
            foreach(var item in MainWindow.cabinets)
            {
                if(item.value == value)
                {
                    selected_id = item.id;
                }
            }


            MainWindow.cabinets[selected_id].value = "";
            MainWindow.cabinets[selected_id].isAvaliable = true;

            MainWindow.cabinets[selected_id].Withdraw();
            
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
