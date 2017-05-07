using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    //<summary>This class contains all enums required for the application.</summary>
    public static class Enums
    {
        public enum TemperatureType
        {
            HOT,
            COLD
        };
        public enum TotalItems
        {
            HOT=6,
            COLD=8
        }
    }
}
