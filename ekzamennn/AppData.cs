using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ekzamennn.AppDataFile;

namespace ekzamennn
{
    class AppData
    {
        public static BeautyShopEntities Context = new BeautyShopEntities();
        internal static Client CurrentUser;
    }
}
