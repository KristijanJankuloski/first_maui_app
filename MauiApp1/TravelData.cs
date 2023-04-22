using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public static class TravelData
    {
        public static DateTime StartDate { get; set; }
        public static DateTime EndDate { get; set;}
        public static int Budget { get; set; }

        static TravelData()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Budget = 0;
        }
    }
}
