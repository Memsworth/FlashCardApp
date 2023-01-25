
namespace FlashCardApp.Models.DBO;

public class LanguageStackModel
{
    public string LanguageName { get; private set; }
    public int StackId { get; private set; }

    public LanguageStackModel(string languageName)
    {
        LanguageName = languageName;
    }

    public LanguageStackModel(int stackId, string languageName) : this(languageName)
    {
        StackId = stackId;
    }
}