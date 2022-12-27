namespace FlashCardApp
{
    internal class FlashCardDTO
    {
        public string FrontWord { get; private set; }
        public string BackWord { get; private set; }

        public FlashCardDTO(string frontWord, string backWord)
        {
            FrontWord = frontWord;
            BackWord = backWord;
        }
    }
}
