﻿namespace FlashCardApp
{
    internal class LanguageStackDTO
    {
        public string LanguageName { get; private set; }
        public List<FlashCard> FlashCardStack { get; private set; }

        public LanguageStackDTO(string languageName)
        {
            LanguageName = languageName;
            FlashCardStack = new List<FlashCard>();
        }
    }
}
