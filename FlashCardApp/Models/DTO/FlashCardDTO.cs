    using FlashCardApp.Models.DBO;

    namespace FlashCardApp.Models.DTO; 

    internal class FlashCardDTO
    {
        public string FrontWord { get; private set; }
        public string BackWord { get; private set; }

        public FlashCardDTO(FlashCard flashCard)
        {
            FrontWord = flashCard.FrontWord;
            BackWord = flashCard.BackWord;
        }

        public FlashCardDTO()
        {
            
        }
        
    }