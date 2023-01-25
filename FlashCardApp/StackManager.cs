using System.Data;

namespace FlashCardApp;

public class StackManager
{
    private IDbConnection DbConnection { get; }
    public StackManager(IDbConnection connection)
    {
        DbConnection = connection;
    }
    
    public void Stack()
    {
        var stackController = new StackController(DbConnection);
        var displayController = new Display(DbConnection);

        displayController.DisplayLanguages(Helper.GetLanguageStack<LanguageStackModel>(DbConnection));
        var currentLanguageStackName = Helper.GetStackName();
        stackController.SetStackId(currentLanguageStackName);

        while (true)
        {
            Helper.StackMenu(currentLanguageStackName);
            switch (Console.ReadLine())
            {
                case "0":
                    return;
                case "X":
                    displayController.DisplayLanguages(Helper.GetLanguageStack<LanguageStackModel>(DbConnection));
                    currentLanguageStackName = Helper.GetStackName();
                    stackController.SetStackId(currentLanguageStackName);
                    break;
                case "V":
                    displayController.DisplayFlashCards(stackController.GetStackFlashCard<FlashCard>());
                    break;
                case "A":
                    Console.Write("Enter amount: ");
                    int.TryParse(Console.ReadLine(), out int amount);
                    displayController.DisplayFlashCards(stackController.DisplayXCards<FlashCard>(amount));
                    break;
                case "C":
                    stackController.CreateFlashCard();
                    break;
                case "E":
                    displayController.DisplayFlashCards(stackController.GetStackFlashCard<FlashCard>());
                    stackController.EditFlashCard();
                    break;
                case "D":
                    displayController.DisplayFlashCards(stackController.GetStackFlashCard<FlashCard>());
                    stackController.DeleteFlashCard();
                    break;
                default:
                    Console.WriteLine("Wrong input. Try again.");
                    break;
            }
        }
    }
}