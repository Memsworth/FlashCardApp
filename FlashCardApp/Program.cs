using FlashCardApp.Manager;
using FlashCardApp.Services;

namespace FlashCardApp // Note: actual namespace depends on the project name.
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var db = new Database();
            var languageManager = new LanguageManager(db.DbConnection());
            var stackManager = new StackManager(db.DbConnection());
            var sessionManager = new StudySessionManager(db.DbConnection());
            while (true)
            {
                ShowMainMenu();
                int choice = Helper.GetValidInt("Enter a value", 0, 4);

                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        languageManager.ManageLanguage();
                        break;
                    case 2:
                        stackManager.ManageStack();
                        break;
                    case 3:
                        sessionManager.StartSession();
                        break;
                    case 4:
                        sessionManager.DisplaySessions();
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
    }
}