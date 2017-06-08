using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    static class Untiles
    {

       public static string clean(string s)
        {
            s = s.ToUpper();
            string[] arr = s.Split(' ', ',', '.', '\t');
            return PrintArray(arr);
        }

        private static string PrintArray(string[] arr)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in arr)
            {
                sb.AppendFormat($" {item}");
            }
            return sb.ToString().Trim();
        }

        public static string GetKey(string s)
        {
            s = clean(s);
            string[] arr = s.Split(' ');
            Array.Sort(arr);

            return PrintArray(arr);
        }
    }
}
