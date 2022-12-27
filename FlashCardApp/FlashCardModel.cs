namespace FlashCardApp;

public class FlashCardModel
{
    public int Id { get; private set; }
    public string FrontWord { get; private set; }
    public string BackWord { get; private set; }

    public FlashCardModel(string frontWord, string backWord)
    {
        FrontWord = frontWord;
        BackWord = backWord;
    }

    public FlashCardModel(int id, string frontWord, string backWord) : this(frontWord, backWord)
    {
        Id = id;
    }
}

