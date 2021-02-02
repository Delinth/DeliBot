namespace DeliBot.Data.GuessGame
{
    public interface IGuessService
    {
        IGuessGame NewGame();
        bool TakeGuess(IGuessGame game, string nameGuess);
        string GetFullName(IGuessGame game);
        string GetCropPic(IGuessGame game);
        string GetFullPic(IGuessGame game);
    }
}