using DeliBot.Data.GuessGame;

namespace DeliBot.Data.GuessGame
{
    public class GuessGame : IGuessGame
    {
        private string PersonName { get; set; }
        public string CropPic { get; set; }
        private string FullPic { get; set; }

        public GuessGame(string name, string cropPic, string fullPic)
        {
            PersonName = name;
            CropPic = cropPic;
            FullPic = fullPic;
        }

        public string GetFullPic() => FullPic;

        public bool GuessCorrect(string nameGuess) => PersonName.ToLower() == nameGuess.ToLower();

        public string GetFullName() => PersonName;

        public string GetCropPic() => CropPic;
    }
}