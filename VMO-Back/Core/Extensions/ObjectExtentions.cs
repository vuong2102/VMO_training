using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ObjectExtentions
    {
        public static string GenerateGuid() => Guid.NewGuid().ToString("N");
        public static bool IsNotNullOrEmpty(this object input)
        {
            if (input == null || input.ToString().Length == 0 || input.ToString().Trim().Length == 0)
            {
                return false;
            }
            return true;
        }

        public static bool IsGreaterThan0(this int input)
        {
            if(input > 0)
            {
                return true;
            }
            return false;
        }
        /*public static string GenerateCode(string data)
        {

        }*/
    }
}
