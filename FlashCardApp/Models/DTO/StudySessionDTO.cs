namespace FlashCardApp;

public class StudySessionDTO
{
    public int Score { get; private set; }
    public DateTime SessionDate { get; private set; }

    public StudySessionDTO(StudySessionModel session)
    {
        Score = session.Score;
        SessionDate = session.SessionDate;
    }

    public StudySessionDTO()
    {
        
    }
}