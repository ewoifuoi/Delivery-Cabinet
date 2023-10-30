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

namespace Delivery_Cabinet;
/// <summary>
/// Depositing.xaml 的交互逻辑
/// </summary>
public partial class Depositing : Page
{

    public string generated_value;

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
    public Depositing(MainWindow parentWindow)
    {
        InitializeComponent();
        this.parentWindow = parentWindow;

        
        generate_Value();
        
        
        Get_into_Depositing();
        
        
    }

    public void Get_into_Depositing()
    {
        int uid = parentWindow.selected_id;
        value.Text = generated_value;

        Cabinet temp = MainWindow.cabinets[uid];
        temp.value = generated_value;
        temp.isAvaliable = false;


        MainWindow.cabinets[uid].Deposit();
        
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.parentWindow.container.Navigate(this.parentWindow.welcome);
        this.ParentWindow.Init_All_Pages();
    }

    public void generate_Value()
    {
        Random random = new Random();

        while (true)
        {
            string temp = "";
            for (int i = 0; i < 4; i++)
            {
                int a = random.Next(0, 9);
                temp += a.ToString();
            }
            if (!this.parentWindow.CheckValue(temp))
            {
                generated_value = temp;
                break;
            }
        }
    }


}
