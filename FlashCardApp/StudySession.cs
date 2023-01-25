using System.Data;
using ConsoleTableExt;
using Dapper;

namespace FlashCardApp;

public class StudySession
{
    private IDbConnection _dbConnection;

    public StudySession(IDbConnection connection)
    {
        _dbConnection = connection;
    }


    public void StartSession()
    {
        int score = 0;
        const int point = 10;
        
        var display = new Display(_dbConnection);
        var stackController = new StackController(_dbConnection);
        
        display.DisplayLanguages(Helper.GetLanguageStack<LanguageStackModel>(_dbConnection));
        var languageNameInput = Helper.GetStackName();
        
        stackController.SetStackId(languageNameInput);

        var items = stackController.GetStackFlashCard<FlashCard>().OrderBy(x => Guid.NewGuid());

        ConsoleTableBuilder.From(items.Select(x => new FlashCardDTO(x)).ToList()).ExportAndWrite();
       
        foreach (var card in items)
        {
            var answer = Helper.GetString($"Enter answer to the {card.FrontWord}: ");

            if (card.BackWord.ToLower().Trim() == answer.ToLower().Trim()) score += point;
            else Console.WriteLine("Wrong answer");
        }


        var toInsert = new StudySessionModel(stackController.CurrentStackId, score, DateTime.Now);

        _dbConnection.Execute("INSERT INTO StudySessionTb (StackId, Score, SessionDate) VALUES (@StackId, @Score, @SessionDate)",
            toInsert);
    }
    
    
}