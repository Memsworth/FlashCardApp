    using FlashCardApp.Models.DBO;

    namespace FlashCardApp.Models.DTO; 

    internal class LanguageStackDTO
    {
        public string LanguageName { get; private set; }

        public LanguageStackDTO(LanguageStackModel languageStack)
        {
            LanguageName = languageStack.LanguageName;
        }

        public LanguageStackDTO()
        {
            
        }
    }