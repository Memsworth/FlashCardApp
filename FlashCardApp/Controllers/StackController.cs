using System.Data;
using Dapper;
using FlashCardApp.Models.DBO;

namespace FlashCardApp.Controllers;

public class StackController
{
    
    public int CurrentStackId { get; private set; }
    
    public StackController()
    {
    }

    internal List<FlashCard> DisplayXCards(int amount, IDbConnection dbConnection) => dbConnection.Query<FlashCard>(
        $"SELECT TOP {amount} * FROM FlashCardTb WHERE StackId = @Id",
        new { Id = CurrentStackId }).ToList();


    internal void SetStackId(string languageNameInput, IDbConnection dbConnection)
    {
        try
        {
            var item = dbConnection.QueryFirst<LanguageStackModel>(
                "SELECT * FROM LanguageStackTb WHERE LanguageName = @languageName",
                new { languageName = languageNameInput });

            CurrentStackId = item.StackId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    internal void CreateFlashCard(IDbConnection dbConnection)
    {
        var item = Helper.CreateCard();
        try
        {
            dbConnection.Execute(
                "INSERT INTO FlashCardTb (StackId , FrontWord, BackWord) VALUES (@StackId, @FrontWord, @BackWord)",
                new {StackId = CurrentStackId, FrontWord = item.FrontWord, BackWord = item.BackWord});
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    internal void EditFlashCard(IDbConnection dbConnection)
    {
        int flashCardId = Helper.GetValidInt("Select flashCardId to change", 1, int.MaxValue);
        
        var item = Helper.GetString("enter an updated word");
        
        int choice = Helper.GetValidInt("Enter 1 to change Front Word. 2 to change Back Word", 1, 2);

        switch (choice)
        {
            case 1:
                try
                {
                    dbConnection.Execute(
                        "UPDATE FlashCardTb SET FrontWord = @frontWord WHERE FlashCardId = @flashcardId",
                        new { frontWord = item, flashcardId = flashCardId });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                break;
            case 2:
                try
                {
                    dbConnection.Execute(
                        "UPDATE FlashCardTb SET BackWord = @backWord WHERE FlashCardId = @flashcardId",
                        new { backWord = item, flashcardId = flashCardId });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                break;
            default:
                Console.WriteLine("wrong command");
                break;
        }
    }
    
    
    internal void DeleteFlashCard(IDbConnection dbConnection)
    {
        int flashCardId = Helper.GetValidInt("Select flashCardId to delete", 1, int.MaxValue);

        try
        {
            dbConnection.Execute("Delete from FlashCardTb WHERE FlashCardId = @Id AND StackId = @stackId",
                new { Id = flashCardId, stackId = CurrentStackId });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    internal List<FlashCard> GetStackFlashCard(IDbConnection dbConnection) => dbConnection
        .Query<FlashCard>("SELECT * FROM FlashCardTb WHERE StackId = @Id", new { Id = CurrentStackId }).ToList();
}