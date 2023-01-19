using System.Data;
using ConsoleTableExt;
using Dapper;

namespace FlashCardApp;

public class StackController
{
    private readonly IDbConnection _dbConnection;
    private int CurrentStackId { get; set; }
    
    public StackController(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void StackManager()
    {
        var stackEdit = false;
        while (stackEdit != false)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Helper.StackMenu();
            switch (Console.ReadLine())
            {
                case "0":
                    stackEdit = true;
                    break;
                case "X":
                    break;
                case "V":
                    ViewStackFlashCards();
                    break;
                case "A":
                    break;
                case "C":
                    CreateFlashCard();
                    break;
                case "E":
                    EditFlashCard(1);
                    break;
                case "D":
                    DeleteFlashCard(1);
                    break;
                default:
                    Console.WriteLine("Wrong input. Try again.");
                    break;
            }
        }
    }

    private void CreateFlashCard()
    {
        var item = Helper.CreateCard();
        try
        {
            _dbConnection.Execute(
                "INSERT INTO FlashCardTb (StackId , FrontWord, BackWord) VALUES (@StackId, @FrontWord, @BackWord)",
                new {StackId = CurrentStackId, FrontWord = item.FrontWord, BackWord = item.BackWord});
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    private void EditFlashCard(int flashCardId)
    {
        var item = Helper.GetString("enter the edited word");
        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    
    private void DeleteFlashCard(int flashCardId)
    {
        try
        {
            _dbConnection.Execute("Delete from FlashCardTb WHERE FlashCardId = @Id AND StackId = @stackId",
                new { Id = flashCardId, stackId = CurrentStackId });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ViewStackFlashCards()
    {
        var items = _dbConnection.Query<FlashCardDTO>("SELECT * FROM FlashCardTb WHERE StackId = @Id", new {Id = CurrentStackId}).ToList();
        ConsoleTableBuilder.From(items).ExportAndWriteLine();
    }

    public void ViewAllLanguageStacks()
    {
        var items = _dbConnection.Query<LanguageStackDTO>("SELECT * FROM LanguageStackTb").ToList();
        ConsoleTableBuilder.From(items).ExportAndWriteLine();
    }
}