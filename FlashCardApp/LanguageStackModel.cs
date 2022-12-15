namespace FlashCardApp;

public class LanguageStackModel
{
    public string LanguageName { get; }
    public List<FlashCardModel> FlashCardStack { get; private set; }

    public LanguageStackModel(string languageName)
    {
        LanguageName = languageName;
        FlashCardStack = new List<FlashCardModel>();
    }
}