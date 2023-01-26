using System.Data;
using FlashCardApp.Controllers;
using FlashCardApp.Models.DBO;
using FlashCardApp.Services;

namespace FlashCardApp.Manager;

public class StackManager
{
    private readonly IDbConnection _dbConnection;
    public StackManager(IDbConnection connection)
    {
        _dbConnection = connection;
    }
    
    public void ManageStack()
    {
        var stackController = new StackController();

        Display.DisplayLanguages(Helper.GetLanguageStack(_dbConnection));
        var currentLanguageStackName = Helper.GetStackName();
        stackController.SetStackId(currentLanguageStackName, _dbConnection);

        while (true)
        {
            Helper.StackMenu(currentLanguageStackName);
            switch (Console.ReadLine())
            {
                case "0":
                    return;
                case "X":
                    Display.DisplayLanguages(Helper.GetLanguageStack(_dbConnection));
                    currentLanguageStackName = Helper.GetStackName();
                    stackController.SetStackId(currentLanguageStackName, _dbConnection);
                    break;
                case "V":
                    Display.DisplayFlashCards(stackController.GetStackFlashCard(_dbConnection));
                    break;
                case "A":
                    Console.Write("Enter amount: ");
                    int.TryParse(Console.ReadLine(), out int amount);
                    Display.DisplayFlashCards(stackController.DisplayXCards(amount, _dbConnection));
                    break;
                case "C":
                    stackController.CreateFlashCard(_dbConnection);
                    break;
                case "E":
                    Display.DisplayFlashCards(stackController.GetStackFlashCard(_dbConnection));
                    stackController.EditFlashCard(_dbConnection);
                    break;
                case "D":
                    Display.DisplayFlashCards(stackController.GetStackFlashCard(_dbConnection));
                    stackController.DeleteFlashCard(_dbConnection);
                    break;
                default:
                    Console.WriteLine("Wrong input. Try again.");
                    break;
            }
        }
    }
}