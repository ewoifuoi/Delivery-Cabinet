using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Delivery_Cabinet;
public static class SerialHelper
{
    public static SerialPort serialPort;
    public static void Init()
    {
        serialPort = new SerialPort();
        serialPort.PortName = "COM2"; // 设置串口号
        serialPort.BaudRate = 9600;   // 设置波特率
        serialPort.DataBits = 8;
        serialPort.Handshake = Handshake.None;
        serialPort.Parity = Parity.None;
        serialPort.StopBits = StopBits.One;
        int count = 0;

        if (!serialPort.IsOpen)
        {
            serialPort.Open();
        }

        ListenData();
        
       
    }

    public static void SendString(string ss)
    {
        
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += (s, e) => {
            serialPort.Write(ss);
        };
        worker.RunWorkerCompleted += (s, e) => {
            //MessageBox.Show("向串口发送数据: " + s);
        };
        worker.RunWorkerAsync();
            
        
    }

    public static void ListenData()
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += (s, e) => {

            
            while(true)
            {
            /// 串口数据接收响应逻辑

                string data = serialPort.ReadLine();
                switch(data.Substring(0,1))
                {
                    case "T": // 温度数据

                        string temperature = data.Substring(1,data.Length-1);
                        //MessageBox.Show(temperature);
                        foreach(var item in MainWindow.cabinets)
                        {
                            item.temperature = Convert.ToDouble(temperature);
                        }
                        break;
                    case "S": // 状态数据
                        break;
                    default: 
                        break;

                }
            }
        };
        worker.RunWorkerCompleted += (s, e) => {
            
        };
        worker.RunWorkerAsync();
    }
}
