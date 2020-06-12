using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomax_Addon.Model
{
    public class Request
    {
        public static Request instance;

        public Request()
        {
                
        }
        public Request(string id, string num,string replace,string amount)
        {
            this.id = id;
            this.number_code = num;
            this.replace_code = replace;
            this.amount = amount;
        }

       public static Request getInstance()
        {
            if (instance == null)
            {
                instance = new Request();
            }
            return instance;
        }

        public static void SetInstance(Request temp)
        {
            instance = temp;

        }
         
        public String number_code { get; set; }
        public String replace_code { get; set; }
        public String amount { get; set; }
        public String id { get; set; }

    }
}
