using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Training
{
    class program
    {
        public static void Main()
        {
            Console.Write("Input year : ");
            int year = Convert.ToInt32(Console.ReadLine());
            GetCenturyAndCheckLeapYear(year);
            Console.ReadLine();
        }
        public static void GetCenturyAndCheckLeapYear(int year)
        {
            if (year % 400 == 0 || year >= 1000 && year % 4 == 0 && year % 100 != 0)
            {
                int century = (year / 100) + 1;
                Console.WriteLine(century + "," + 1);

            }
            else
            {
                int century = (year / 100) + 1;
                Console.WriteLine(century + "," + (-1));

            }
        }
    }
}
