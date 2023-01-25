namespace FlashCardApp;

public class FlashCard
{
    public int FlashCardId { get; private set; }
    public int StackId { get; private set; }
    public string FrontWord { get; private set; }
    public string BackWord { get; private set; }

    public FlashCard(string frontWord, string backWord)
    {
        FrontWord = frontWord;
        BackWord = backWord;
    }

    public FlashCard(int flashCardId, int stackId, string frontWord, string backWord) : this(frontWord, backWord)
    {
        FlashCardId = flashCardId;
        StackId = stackId;
    }

    public FlashCard()
    {
        
    }
}

