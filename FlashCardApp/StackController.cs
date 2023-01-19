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
        var stackEdit = true;
        while (stackEdit != false)
        {
            ViewAllLanguageStacks();
            SetStackId();
            Helper.StackMenu();
            switch (Console.ReadLine())
            {
                case "0":
                    stackEdit = false;
                    break;
                case "X":
                    SetStackId();
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
                    DeleteFlashCard();
                    break;
                default:
                    Console.WriteLine("Wrong input. Try again.");
                    break;
            }
        }
    }

    private void SetStackId()
    {
        try
        {
            var stackNameInput = Helper.GetString("Enter the stack you want to work with");
            var item = _dbConnection.QueryFirst<LanguageStackModel>(
                "SELECT * FROM LanguageStackTb WHERE LanguageName = @languageName",
                new { languageName = stackNameInput });

            CurrentStackId = item.StackId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
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
    
    
    private void DeleteFlashCard()
    {
        Console.Write("Enter flashcardID to delete");
        int.TryParse(Console.ReadLine(), out int flashCardId);
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

    private void ViewAllLanguageStacks()
    {
        var items = _dbConnection.Query<LanguageStackDTO>("SELECT * FROM LanguageStackTb").ToList();
        ConsoleTableBuilder.From(items).ExportAndWriteLine();
    }
}