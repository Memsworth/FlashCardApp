using System.Data;
using Dapper;
using FlashCardApp.Models.DBO;

namespace FlashCardApp.Controllers;

public static class LanguageController
{
    public static void AddLanguageStack( this IDbConnection dbConnection)
    {
        var languageName = Helper.GetString("Creating a new language stack");
        var languageStack = new LanguageStackModel(languageName);
        try
        {
            dbConnection.Execute("INSERT INTO LanguageStackTb (LanguageName) VALUES (@LanguageName)", languageStack);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void DeleteLanguageStack( this IDbConnection dbConnection)
    {
        var languageNameInput = Helper.GetString("Deleting a language stack");
        try
        {
            var languageStack = dbConnection.QueryFirst<LanguageStackModel>(
                "SELECT * FROM LanguageStackTb WHERE LanguageName = @languageName",
                new { languageName = languageNameInput });

            dbConnection.Execute("Delete from LanguageStackTb WHERE StackId = @stackId",
                new { stackId = languageStack.StackId });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void EditLanguageStack(this IDbConnection dbConnection)
    {
        var oldLanguageName = Helper.GetString("The language stack you want to replace");
        var newLanguageName = Helper.GetString("The new language stack");
        try
        {
            var languageStack = dbConnection.QueryFirst<LanguageStackModel>(
                "SELECT * FROM LanguageStackTb WHERE LanguageName = @languageName",
                new { languageName = oldLanguageName });
            
            dbConnection.Execute(
                "UPDATE LanguageStackTb SET LanguageName = @newLanguage WHERE StackId = @stackId",
                new { newLanguage = newLanguageName, stackId = languageStack.StackId });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}