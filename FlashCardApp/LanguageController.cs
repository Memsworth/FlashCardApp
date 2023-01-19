using System.Data;
using Dapper;

namespace FlashCardApp;

public class LanguageController
{
    private readonly IDbConnection _dbConnection;

    public LanguageController(IDbConnection connection)
    {
        _dbConnection = connection;
    }


    public void LanguageManager()
    {
        var isDone = false;

        while (isDone != true)
        {
            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 0:
                    isDone = true;
                    break;
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
            var languageStackId =
                _dbConnection.Execute("SELECT StackId FROM LanguageStackTb WHERE LanguageName = @languageName",
                    new { languageName = languageNameInput });
            
            _dbConnection.Execute("Delete from LanguageStackTb WHERE StackId = @stackId",
                new { stackId = languageStackId });
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
            _dbConnection.Execute(
                "UPDATE LanguageStackTb SET LanguageName = @newLanguage WHERE LanguageName = @oldLanguage",
                new { newLanguage = newLanguageName, oldLanguage = oldLanguageName });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}