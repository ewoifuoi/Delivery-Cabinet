using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.RightsManagement;
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
    /// 所有页面
    public Welcome welcome;
    
    public Completed completed;
    public Pick_up pick_up;
    public Deposit deposit;
    public Depositing depositing;


    public int selected_id = -1;
    

    public List<Cabinet> cabinets;
    
    public MainWindow()
    {
        InitializeComponent();
        cabinets = new List<Cabinet>();
        for (int i = 0; i < 26; i++) cabinets.Add(new Cabinet(i));

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

        

        Init_All_Pages();

    }

    /// <summary>
    /// 更新右上角时间
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void timer_Tick(object? sender, EventArgs e)
    {
        time.Text = DateTime.Now.ToString("T");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    /// <summary>
    /// 重写拖动
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    /// <summary>
    /// 重新初始化页面
    /// </summary>
    public void Init_All_Pages()
    {
        pick_up = new Pick_up
        {
            parentWindow = this
        };
        deposit = new Deposit
        {
            parentWindow = this
        };
        
    }

    /// <summary>
    /// 校验取货码
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool CheckValue(string value)
    {
        foreach (var item in cabinets)
        {
            if(item.value == value) return true;
        }
        return false;
    }

    




}
