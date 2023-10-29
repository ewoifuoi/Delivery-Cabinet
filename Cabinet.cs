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
        public Button c_btn = null;

        public Cabinet(int id, string value)
        {
            this.id = id;
            this.value = value;
        }

        public Cabinet(int id)
        {
            this.id = id;
            
        }


    }
}
