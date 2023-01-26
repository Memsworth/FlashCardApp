using System.Data;
using Dapper;
using FlashCardApp.Models.DBO;

namespace FlashCardApp.Controllers;

public class SessionController
{
    public void Insert(StudySessionModel studySession, IDbConnection dbConnection)
    {
        dbConnection.Execute("INSERT INTO StudySessionTb (StackId, Score, SessionDate) VALUES (@StackId, @Score, @SessionDate)",
            studySession);
    }
    
    public List<StudySessionModel> GetSessions(IDbConnection dbConnection)
    {
        var items = dbConnection.Query<StudySessionModel>("SELECT * FROM StudySessionTb").ToList();
        return items;
    }
}