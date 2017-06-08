using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    static class Utiles
    {
        static public int getNoUse(bool[] arr, Random rnd)
        {
            int res = -1;

            do
            {
                res = rnd.Next(arr.Length);
            }
            while (arr.Contains<bool>(true) && !arr[res]);

            return res;
        }
    }
}
