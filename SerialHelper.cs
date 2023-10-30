﻿using System;
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
        serialPort.PortName = "COM3"; // 设置串口号
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
        
       
    }

    public static void SendString(string ss)
    {
        if(serialPort.IsOpen)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, e) => {
                serialPort.Write(ss);
            };
            worker.RunWorkerCompleted += (s, e) => {
                MessageBox.Show("向串口发送数据: " + s);
            };
            worker.RunWorkerAsync();
            
        }
        

    }
}