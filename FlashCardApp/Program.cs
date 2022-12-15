using System;

namespace FlashCardApp // Note: actual namespace depends on the project name.
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var endApp = false;

            while (endApp != false)
            {
                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 0:
                        endApp = true;
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
        }


        private static void ShowMainMenu()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\nMAIN MENU");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("Type 0 to Close Application.");
            Console.WriteLine("Type 1 to manage Stacks.");
            Console.WriteLine("Type 2 to manage Flash Cards.");
            Console.WriteLine("Type 3 to Study.");
            Console.WriteLine("Type 4 to view Study session data.");
            Console.WriteLine("---------------------------------------------");
        }
    }
}