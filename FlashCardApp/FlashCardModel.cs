namespace FlashCardApp;

public class FlashCard
{
    public int Id { get; private set; }
    public int LanguageStackId { get; private set; }
    public string FrontWord { get; private set; }
    public string BackWord { get; private set; }

    public FlashCard(string frontWord, string backWord)
    {
        FrontWord = frontWord;
        BackWord = backWord;
    }

    public FlashCard(int id, int languageStackId, string frontWord, string backWord) : this(frontWord, backWord)
    {
        Id = id;
        LanguageStackId = languageStackId;
    }
    public FlashCard(int id, string frontWord, string backWord) : this(frontWord, backWord)
    {
        Id = id;
    }
}

