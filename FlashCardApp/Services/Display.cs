using ConsoleTableExt;
using FlashCardApp.Models.DBO;
using FlashCardApp.Models.DTO;

namespace FlashCardApp.Services;

public static class Display
{
    public static void DisplayFlashCards(List<FlashCard> items) => ConsoleTableBuilder
        .From(items.Select(x => new FlashCardDTO(x)).ToList()).ExportAndWriteLine();

    public static void DisplayFlashCardId(List<FlashCard> items) => ConsoleTableBuilder
        .From(items.Select(x => new {x.FlashCardId, x.FrontWord, x.BackWord}).ToList()).ExportAndWriteLine();
    
    public static void DisplayLanguages(List<LanguageStackModel> items) => ConsoleTableBuilder
        .From(items.Select(x => new LanguageStackDTO(x)).ToList()).ExportAndWriteLine();

    
    public static void DisplaySessions(List<StudySessionModel> items) => ConsoleTableBuilder
        .From(items.Select(x => new {x.Score, SessionDate = x.SessionDate.ToString("yyyy MMMM dd")}).ToList()).ExportAndWriteLine();
}