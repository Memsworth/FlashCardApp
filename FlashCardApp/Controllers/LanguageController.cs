using System.Data;
using Dapper;
using FlashCardApp.Models.DBO;

namespace FlashCardApp.Controllers;

public class LanguageController
{
    private readonly IDbConnection _dbConnection;

    public LanguageController(IDbConnection connection)
    {
        _dbConnection = connection;
    }


    public void LanguageManager()
    {
        while (true)
        {
            Helper.LanguageMenu();
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    AddLanguageStack();
                    break;
                case 2:
                    DeleteLanguageStack();
                    break;
                case 3:
                    EditLanguageStack();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        }
    }
    
    private void AddLanguageStack()
    {
        var languageName = Helper.GetString("Creating a new language stack");
        var languageStack = new LanguageStackModel(languageName);
        try
        {
            _dbConnection.Execute("INSERT INTO LanguageStackTb (LanguageName) VALUES (@LanguageName)", languageStack);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void DeleteLanguageStack()
    {
        var languageNameInput = Helper.GetString("Deleting a language stack");
        try
        {
            var languageStack = _dbConnection.QueryFirst<LanguageStackModel>(
                "SELECT * FROM LanguageStackTb WHERE LanguageName = @languageName",
                new { languageName = languageNameInput });

            _dbConnection.Execute("Delete from LanguageStackTb WHERE StackId = @stackId",
                new { stackId = languageStack.StackId });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void EditLanguageStack()
    {
        var oldLanguageName = Helper.GetString("The language stack you want to replace");
        var newLanguageName = Helper.GetString("The new language stack");
        try
        {
            var languageStack = _dbConnection.QueryFirst<LanguageStackModel>(
                "SELECT * FROM LanguageStackTb WHERE LanguageName = @languageName",
                new { languageName = oldLanguageName });
            
            _dbConnection.Execute(
                "UPDATE LanguageStackTb SET LanguageName = @newLanguage WHERE StackId = @stackId",
                new { newLanguage = newLanguageName, stackId = languageStack.StackId });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}