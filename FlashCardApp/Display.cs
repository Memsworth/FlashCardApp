using System.Data;
using ConsoleTableExt;

namespace FlashCardApp;

public class Display
{
    private IDbConnection _dbConnection;

    public Display(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void DisplayFlashCards<T>(List<T> items) where T : FlashCard => ConsoleTableBuilder
        .From(items.Select(x => new FlashCardDTO(x)).ToList()).ExportAndWriteLine();

    
    public void DisplayLanguages<T>(List<T> items) where T : LanguageStackModel => ConsoleTableBuilder
        .From(items.Select(x => new LanguageStackDTO(x)).ToList()).ExportAndWriteLine();
}