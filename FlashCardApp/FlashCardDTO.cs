namespace FlashCardApp
{
    internal class FlashCardDTO
    {
        public string FrontWord { get; private set; }
        public string BackWord { get; private set; }

        public static FlashCardDTO FromModel(FlashCardModel flashCard)
        {
            return new FlashCardDTO
            {
                FrontWord = flashCard.FrontWord,
                BackWord = flashCard.BackWord
            };
        }
    }
}
