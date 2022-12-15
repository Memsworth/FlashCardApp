namespace FlashCardApp;

public class StudySessionModel
{
    public DateOnly StudyDate { get; private set; }
    public int Score { get; private set; }

    public StudySessionModel()
    {
        
    }
}