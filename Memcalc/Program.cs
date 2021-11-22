using System;
using System.IO;

namespace Memcalc
{
    class Program
    {
        public static char menuCh;
        public static char op;
        public static double ans;
        public static double num1;
        public static double num2;
        public static double rr;


        private const char OP_ADD = '+';
        private const char OP_SUBTRACT = '-';
        private const char OP_MULT = '*';
        private const char OP_DIV = '/';
        private const char OP_MOD = '%';

        // main program mostly containing main menu
        static void Main(string[] args)
        {
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\tMemcalc VERSION 1.2\r");
                Console.WriteLine("\t\t\t\t\t\t=====================\n");
                Console.WriteLine("\t\t\t\t\t\tOption 1. Use calculator\r");
                Console.WriteLine("\t\t\t\t\t\tOption 2. Calculate with percentages\r");
                Console.WriteLine("\t\t\t\t\t\tOption 3. Calculate square root\r");
                Console.WriteLine("\t\t\t\t\t\tOption 4. Load previous answer\r");
                Console.WriteLine("\t\t\t\t\t\tOption 5. Exit\r");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("I choose Option: ");
                menuChoice();
                Console.ReadKey();
            } while (menuCh != 9);
        }

        // main menu option system
        private static void menuChoice()
        {
            char menuCh = Console.ReadKey().KeyChar;

            switch (menuCh)
            {
                case '1':
                    Console.WriteLine();
                    Calculator();
                    break;
                case '2':
                    Percentage();
                    break;
                case '3':
                    Sqrt();
                    break;
                case '4':
                    LoadMath(ans);
                    break;
                case '5':
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("\t\t\t\tIncorrect input..\r");
                    break;
            }
        }

        // calculator for basic operations
        public static void Calculator()
        {
            double ans;

            try
            {
                Console.WriteLine("\t\t\t\t\t\tEnter your first number: \r");
                num1 = double.Parse(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine($"\t\t\t\t\t\t{e.Message}\r"); }

            try
            {
                Console.WriteLine("\t\t\t\t\t\tSelect an operator: (+ ; -; *; /, %)\r");
                op = char.Parse(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine($"\t\t\t\t\t\t{e.Message}\r"); }

            try
            {
                Console.WriteLine("\t\t\t\t\t\tEnter your second number: \r");
                num2 = double.Parse(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine($"\t\t\t\t\t\t{e.Message}\r"); }

            switch (op)
            {
                case OP_ADD:
                    ans = num1 + num2;
                    Console.WriteLine($"\t\t\t\t\t\tANSWER: {ans} \r");
                    SaveMath(ans);
                    break;
                case OP_SUBTRACT:
                    ans = num1 - num2;
                    Console.WriteLine($"\t\t\t\t\t\tANSWER: {ans} \r");
                    SaveMath(ans);
                    break;
                case OP_MULT:
                    ans = num1 * num2;
                    Console.WriteLine($"\t\t\t\t\t\tANSWER: {ans} \r");
                    SaveMath(ans);
                    break;
                case OP_DIV:
                    ans = num1 / num2;
                    Console.WriteLine($"\t\t\t\t\t\tANSWER: {ans} \r");
                    SaveMath(ans);
                    break;
                case OP_MOD:
                    ans = num1 % num2;
                    Console.WriteLine($"\t\t\t\t\t\tANSWER: {ans} \r");
                    SaveMath(ans);
                    break;
            }
        }

        // menu for percentage calculation options
        public static void Percentage()
        {
            Console.WriteLine("\t\t\t\tOPTIONS: \r");
            Console.WriteLine("\t\t\t\t\t\t--------\r");
            Console.WriteLine("\t\t\t\t\t\t1) Calculate the % of a number in relateion to another\r");
            Console.WriteLine("\t\t\t\t\t\t2) Calculate what % a number is of another \r");
            Console.WriteLine("");
            Console.Write("I choose Option: ");
            char avgMenuCh = Console.ReadKey().KeyChar;

            if (avgMenuCh == '1')
            {
                CalcPercentage();
            }
            else if (avgMenuCh == '2')
            {
                CalcPercentage2();
            }
            else { Console.WriteLine("Incorrect input.."); }
        }

        // calculator for finding result of % of another value
        public static void CalcPercentage()
        {
            try
            {
                Console.WriteLine("\t\t\t\tEnter the number which you wish to find the percentage OF: \r");
                num1 = double.Parse(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine($"\t\t\t\t\t\t{e.Message}\r"); }

            try
            {
                Console.WriteLine("\t\t\t\t\t\tEnter the number which you wish to find the pertentage FROM: \r");
                num2 = double.Parse(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine($"\t\t\t\t\t\t{e.Message}\r"); }

            ans = num1 * num2 / 100;
            Console.WriteLine($"\t\t\t\t\t\tANSWER: {ans}\r");
            SaveMath(ans);
        }

        // calculator for finding total % of another value
        public static void CalcPercentage2()
        {
            try
            {
                Console.WriteLine("\t\t\t\tEnter the number you wish to find how much PERCENTAGE they represent: \r");
                num1 = double.Parse(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine($"\t\t\t\t\t\t{e.Message}\r"); }

            try
            {
                Console.WriteLine("\t\t\t\t\t\tEnter the number which the first number entered is relative TO: \r");
                num2 = double.Parse(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine($"\t\t\t\t\t\t{e.Message}\r"); }

            ans = num1 / num2 * 100;
            Console.WriteLine($"\t\t\t\t\t\tANSWER: {ans}%\r");
            SaveMath(ans);
        }

        // basic calculator which returns square root of input value
        public static void Sqrt()
        {
            try
            {
                Console.WriteLine("\t\t\t\tEnter the number you wish to find the square root of: \r");
                ans = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException e) { Console.WriteLine($"\t\t\t\t\t\t{e.Message}\r"); }
            ans = (Math.Sqrt(ans));
            Console.WriteLine($"\t\t\t\t\t\tANSWER: {ans}\r");
            SaveMath(ans);
        }

        // operation history recording
        public static double SaveMath(double ans)
        {
            StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory() + "//nastenadata.txt");
            write.WriteLine(ans);
            write.Close();
            return ans;
        }

        // printing previous answer to console
        public static double LoadMath(double ans)
        {
            StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "//nastenadata.txt");
            ans = double.Parse(reader.ReadLine());
            Console.WriteLine($"\n\t\t\t\t\t\tPREVIOUS ANSWER: {ans}");

            reader.Close();
            return ans;
        }
    }
}
