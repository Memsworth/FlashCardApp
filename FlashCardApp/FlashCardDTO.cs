namespace FlashCardApp
{
    internal class FlashCardDTO
    {
        public string FrontWord { get; private set; }
        public string BackWord { get; private set; }

        public static FlashCardDTO FromModel(FlashCard flashCard)
        {
            return new FlashCardDTO
            {
                FrontWord = flashCard.FrontWord,
                BackWord = flashCard.BackWord
            };
        }
    }
}
