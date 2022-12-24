namespace FlashCardApp;

public class LanguageStackController
{
    public FlashCardController FlashCardController { get; }
    public LanguageStackController()
    {
        FlashCardController = new FlashCardController(new FlashCardModel("1" ,"1"));
    }
    public void CreateFlashCard()
    {
        var item = FlashCardController.CreateCard();
        //TODO: insert flashcard into stack 
    }
    public void EditFlashCard(FlashCardModel model)
    {
        var item = FlashCardController.EditFlashCard(model);
        //TODO: change model place with item and insert back
    }
    public void DeleteFlashCard(int id)
    {
        //TODO: Where id is equal quenry, delete
    }
}