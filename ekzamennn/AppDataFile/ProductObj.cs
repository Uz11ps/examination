﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzamennn.AppDataFile
{
    internal class ProductObj
    {

        public int ID { get; set; }
        public decimal Price { get; set; }


        public static int Id { get; set; }
        public static decimal Cost { get; set; }

        public static string Title { get; set; }
        public static string Image { get; set; }

        public static string Description { get; set; }
        public static int OwnerId { get; set; }
        public static bool IsActive { get; set; }
    }
}
