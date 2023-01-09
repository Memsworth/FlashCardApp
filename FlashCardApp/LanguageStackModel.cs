namespace FlashCardApp;

public class LanguageStackModel
{
    public string LanguageName { get; private set; }
    public int Id { get; private set; }
    public List<FlashCardModel> FlashCards { get; private set; }

    public LanguageStackModel(string languageName)
    {
        LanguageName = languageName;
        FlashCards = new List<FlashCardModel>();
    }

    public LanguageStackModel(string languageName, int id) : this(languageName)
    {
        Id = id;
    }
}