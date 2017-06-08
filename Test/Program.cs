using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test
{
    class Program
    {
        static string[][] docArr;
        static Random rnd;
        static Manager maneger;

        static void Main(string[] args)
        {
            InitDocs();

            rnd = new Random();

            string[] formArr = getFormsArr();

            maneger = new Manager();

            int docCount = 0;

            for (int i = 0; i < formArr.Length; i++)
            {
                if (!maneger.IsDuplicated(formArr[i]))
                    docCount++;
            }

            Console.WriteLine(maneger.ShowDetails());

            for (int i = 0; i < docArr.Length; i++)
            {
                Console.WriteLine(maneger.ShowDetails(string.Join(" ", docArr[i])));
            }

            maneger.Delete(string.Join(",", docArr[0]));

            for (int i = 0; i < 10; i++)
            {
                int res;
                string newForm;
                Console.WriteLine(maneger.FindClosestAmount( getForm(docArr[rnd.Next(docArr.Length)])
                    ,out res, out newForm ));
                Console.WriteLine(res +" "+ newForm);

                Console.WriteLine(maneger.FindClosestAmount(formArr[rnd.Next(formArr.Length)]
                    , out res, out newForm));
                Console.WriteLine( res + " " + newForm);

            }
        }

        private static void InitDocs()
        {
            docArr = new string[5][];
            docArr[0] = new string[] { "aa", "bb", "cc", "dd", "ee", "ff", "hh", "ii", "gg" };
            docArr[1] = new string[] { "dani", "cat", "dog", "moshe", "account", "coins", "lend", "savings", "bills" };
            docArr[2] = new string[] { "credit", "loan", "guard", "borrow", "credit ", "card", "manager", "teller", "alarm" };
            docArr[3] = new string[] { "currency", "money", "vault", "cash", "customer", "mortgage" };
            docArr[4] = new string[] { "withdraw", "cashier", "deposit", "pay", "check", "interest", "save" };
        }

        private static string[] getFormsArr()
        {
            string[] arr = new string[1000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = getForm(docArr[rnd.Next(5)]);
            }

            return arr;
        }

        private static string getForm(string[] doc)
        {
            StringBuilder sb = new StringBuilder();
            bool[] indArr = new bool[doc.Length];

            for (int i = 0; i < indArr.Length; i++)
            {
                indArr[i] = true;
            }

            for (int i = 0; i < doc.Length; i++)
            {
                int ind = Utiles.getNoUse(indArr, rnd);
                indArr[ind] = false;
                sb.AppendFormat(" {0}", doc[ind]);
            }

            return sb.ToString();
        }
    }

}
