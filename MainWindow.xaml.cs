﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
using System.Windows.Threading;




namespace Delivery_Cabinet;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Page welcome;
    public Page select_cabinet;

    public List<string> valid_value;
    
    public MainWindow()
    {
        InitializeComponent();
        welcome = new Welcome
        {
            ParentWindow = this
        };
        container.Navigate(welcome);

        
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = new TimeSpan(0, 0, 1);//设置的间隔为一分钟
        timer.Tick += timer_Tick;//设置定时器溢出触发事件
                                 //开启定时器
        timer.Start();

        valid_value = new List<string> // 取货码初始化
        {
            "7459"
        };

    }

    private void timer_Tick(object? sender, EventArgs e)
    {
        time.Text = DateTime.Now.ToString("T");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    public void Init_All_Pages()
    {
        select_cabinet = new Select_Cabinet();
        
    }


    

}
