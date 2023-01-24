namespace FlashCardApp;

public class StudySessionModel
{
    public int SessionId { get; private set; }
    public int StackId { get; private set; }
    public int Score { get; private set; }
    public DateOnly SessionDate { get; private set; }

    public StudySessionModel(int score)
    {
        Score = score;
    }

    public StudySessionModel(int sessionId, int stackId, int score, DateOnly sessionDate) : this(score)
    {
        SessionId = sessionId;
        StackId = stackId;
        SessionDate = sessionDate;
    }
    public StudySessionModel()
    {
        
    }
}