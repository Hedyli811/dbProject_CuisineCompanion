using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisineCompanionMDI
{
    public static class Validator
    {
        public static bool IsNumeric(this string value)
        {
            return decimal.TryParse(value, out _);
        }
    } 
}
