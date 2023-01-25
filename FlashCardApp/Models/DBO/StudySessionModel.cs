namespace FlashCardApp;

public class StudySessionModel
{
    public int SessionId { get; private set; }
    public int StackId { get; private set; }
    public int Score { get; private set; }
    public DateTime SessionDate { get; private set; }

    public StudySessionModel(int stackId, int score, DateTime date)
    {
        StackId = stackId;
        Score = score;
        SessionDate = date;
    }

    public StudySessionModel(int sessionId, int stackId, int score, DateTime sessionDate) : this(stackId, score, sessionDate)
    {
        SessionId = sessionId;
    }
    public StudySessionModel()
    {
        
    }
}