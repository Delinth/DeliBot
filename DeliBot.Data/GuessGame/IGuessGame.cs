namespace DeliBot.Data.GuessGame
{
    public interface IGuessGame
    {
        string GetFullName();
        string GetCropPic();
        string GetFullPic();
        bool GuessCorrect(string nameGuess);
    }
}