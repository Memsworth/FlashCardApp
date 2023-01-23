using System;

namespace FlashCardApp // Note: actual namespace depends on the project name.
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var db = new Database();
            var languageController = new LanguageController(db.DbConnection());
            var stackController = new StackManager(db.DbConnection());

            while (true)
            {
                ShowMainMenu();
                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        languageController.LanguageManager();
                        break;
                    case 2:
                        stackController.Stack();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("wrong input");
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

        private static void ShowStackInput()
        {
            Console.Write("Choose a stack of FlashCards to interact with: ");
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("Input a current stack name");
            Console.WriteLine("Input 0 to exit input");
            Console.WriteLine("---------------------------------------------");

        }
        
        

    }
}