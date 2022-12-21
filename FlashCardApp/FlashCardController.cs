namespace FlashCardApp;

public class FlashCardController
{
    
    public FlashCardModel FlashCard { get; private set; }

    public FlashCardController(FlashCardModel flashCard)
    {
        FlashCard = flashCard;
    }
}