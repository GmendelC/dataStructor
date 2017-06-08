using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ux
{
    class Program
    {
        static Logic.Manager currentManager = new Logic.Manager();

        static void Main(string[] args)
        {
            Choise choice = 0;
            while (choice != Choise.Exit)
            {
                PrintMenu();
                choice = GetChoise();

                switch (choice)
                {
                    case Choise.IsDuplicated:
                        IsDuplicated();
                        break;
                    case Choise.ShowDetails:
                        ShowDetails();
                        break;
                    case Choise.Delete:
                        Delete();
                        break;
                    case Choise.FindClosestAmount:
                        FindClosestAmount();
                        break;
                }

            }
        }

        private static void FindClosestAmount()
        {
            int count;
            string form;
            Console.WriteLine(("Please, enter the Formart to find Closest Amount:"));
            if(currentManager.FindClosestAmount(Console.ReadLine(), out count, out form))
                Console.WriteLine($"Find - {form} have {count}");
            else
                Console.WriteLine("Not Found");
        }

        private static void Delete()
        {
            Console.WriteLine(("Please, enter the doucoment to delete"));
            if(currentManager.Delete(Console.ReadLine()))
                Console.WriteLine("Succeeded");
            else
                Console.WriteLine("Fail");
        }

        private static void ShowDetails()
        {
            Console.WriteLine("Please, enter the doucoment to Detail or press only enter to all Details");
            string tmp = Console.ReadLine();
            if (tmp == "")
                Console.WriteLine(currentManager.ShowDetails());
            else
                Console.WriteLine(currentManager.ShowDetails(tmp));
        }

        private static void IsDuplicated()
        {
            Console.WriteLine("Please, enter the doucoment to insert, or enter to return to menu");

            string str = Console.ReadLine();

            if (string.IsNullOrEmpty(str))// Empty return to menu.
                return;

            if ( currentManager.IsDuplicated(str))
                Console.WriteLine("Duplicated");
            else
                Console.WriteLine("(new)NotDuplicated");
        }

        private static Choise GetChoise()
        {
            try
            {

                Choise choice = (Choise)Enum.Parse(typeof(Choise), Console.ReadLine());
                return choice;
            }
            catch (Exception)
            {
                Console.WriteLine("to IsDuplicate");
                return Choise.IsDuplicated;
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("Choise: ");
            string[] tmp = Enum.GetNames(typeof(Choise));

            for (int i = 0; i < tmp.Length; i++)
            {
                Console.Write($"{i}:{tmp[i]}. ");
            }
            Console.WriteLine("");
        }

        enum Choise { IsDuplicated, ShowDetails, Delete, FindClosestAmount, Exit}
    }
}
