using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Delivery_Cabinet
{
    public class Cabinet
    {
        
        public int id;
        public string value = "";
        public bool isAvaliable = true;
        public int state; // 制冷状态
        public double temperature;
        

        public Cabinet(int id, string value)
        {
            this.id = id;
            this.value = value;
        }

        public Cabinet(int id)
        {
            this.id = id;
            
        }

        /// <summary>
        /// 存入柜子
        /// </summary>
        public void Deposit()
        {
            SerialHelper.SendString("1"); // 通知存入

            switch (state) {
                case 0: { // 当前需要制冷 (冷冻)
                    SerialHelper.SendString("2"); // 打开制冷
                    break;
                }
                case 1: { // 当前需要制冷 (保鲜)

                    SerialHelper.SendString("8"); // 进入5度自动调节模式
                    break;
                }
                case 2: { // 当前不需要制冷
                    SerialHelper.SendString("3"); // 关闭制冷
                    break;
                }
            }

            OpenCabinet(); // 开柜门
        }

        /// <summary>
        /// 从柜子中取出
        /// </summary>
        public void Withdraw()
        {
            SerialHelper.SendString("0"); // 通知取出
            SerialHelper.SendString("3"); // 关闭制冷

            OpenCabinet(); // 开柜门


        }
       
        /// <summary>
        /// 开柜门
        /// </summary>
        public void OpenCabinet()
        {
            

        }


    }
}
