using System.Data;
using Dapper;
using FlashCardApp.Controllers;
using FlashCardApp.Models.DBO;
using FlashCardApp.Services;

namespace FlashCardApp.Manager;

public class StudySessionManager
{
    private IDbConnection _dbConnection;

    private SessionController Controller { get; }

    public StudySessionManager(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        Controller = new SessionController();
    }


    public void DisplaySessions()
    {
        Display.DisplaySessions(Controller.GetSessions(_dbConnection));
    }

    public void StartSession()
    {
        int score = 0;
        const int point = 10;
        
        Display.DisplayLanguages(Helper.GetLanguageStack(_dbConnection));

        var stackController = new StackController();
        var languageNameInput = Helper.GetStackName();
        stackController.SetStackId(languageNameInput, _dbConnection);

        var items = stackController.GetStackFlashCard(_dbConnection).OrderBy(x => Guid.NewGuid());

        foreach (var card in items)
        {
            var answer = Helper.GetString($"Enter answer to the {card.FrontWord}");

            if (card.BackWord.ToLower().Trim() == answer.ToLower().Trim()) score += point;
            else Console.WriteLine("Wrong answer");
        }

        var toInsert = new StudySessionModel(stackController.CurrentStackId, score, DateTime.Now);

        Controller.Insert(toInsert, _dbConnection);
    }
    
}