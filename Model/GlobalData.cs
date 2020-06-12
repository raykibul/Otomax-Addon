using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otomax_Addon.Model
{
    public class GlobalData
    {
        public static GlobalData instance;
        public static GlobalData getinstance()
        {
            if (instance == null)
                instance = new GlobalData();

            return instance;
        }
             
        public  bool isEditingNow=false;



    }
}
