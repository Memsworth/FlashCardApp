namespace FlashCardApp;
public class FlashCardController
{
    public FlashCardModel FlashCard { get; private set; }
    public FlashCardController(FlashCardModel flashCard)
    {
        FlashCard = flashCard;
    }

    public FlashCardModel CreateCard()
    {
        return new FlashCardModel("1", "1");
    }

    public FlashCardModel EditFlashCard(FlashCardModel model)
    {
        return model;
    }
}