namespace FlashCardApp
{
    internal class LanguageStackDTO
    {
        public string LanguageName { get; private set; }

        public LanguageStackDTO(string languageName)
        {
            LanguageName = languageName;
        }

        public LanguageStackDTO()
        {
            
        }
    }
}
