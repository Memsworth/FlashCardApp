namespace FlashCardApp;
public class FlashCardController
{
    public FlashCardController()
    {
        
    }

    public FlashCard CreateCard()
    {
        var frontWord = Helper.GetString("Enter a front word for the flashcard");
        var backWord = Helper.GetString($"Enter a back word for {frontWord}");
        return new FlashCard(frontWord, backWord);
    }

    public void EditFlashCard(int stackId)
    {
    }
    
    
}