
using System.Data;
using FlashCardApp.Controllers;

namespace FlashCardApp.Manager;

public class LanguageManager
{
    private readonly IDbConnection _dbConnection;

    public LanguageManager(IDbConnection connection)
    {
        _dbConnection = connection;
    }
    
    public void ManageLanguage()
    {
        var controller = new LanguageController();
        
        while (true)
        {
            Helper.LanguageMenu();
            int choice = Helper.GetValidInt("Enter a value", 0, 3);
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    controller.AddLanguageStack(_dbConnection);
                    break;
                case 2:
                    controller.DeleteLanguageStack(_dbConnection);
                    break;
                case 3:
                    controller.EditLanguageStack(_dbConnection);
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        }
    }
}