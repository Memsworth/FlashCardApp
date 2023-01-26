
using System.Data;
using FlashCardApp.Controllers;
using FlashCardApp.Services;

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
        
        while (true)
        {
            Helper.LanguageMenu();
            int choice = Helper.GetValidInt("Enter a value", 0, 3);
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    _dbConnection.AddLanguageStack();
                    break;
                case 2:
                    Display.DisplayLanguages(Helper.GetLanguageStack(_dbConnection));
                    _dbConnection.DeleteLanguageStack();
                    break;
                case 3:
                    Display.DisplayLanguages(Helper.GetLanguageStack(_dbConnection));
                    _dbConnection.EditLanguageStack();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        }
    }
}