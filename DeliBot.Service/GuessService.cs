using DeliBot.Data.GuessGame;

namespace DeliBot.Service
{
    public class GuessService : IGuessService
    {

        public IGuessGame NewGame()
        {
            Celeb celeb = new Celeb() {name = "Kim Kardashian"};

            return new GuessGame(celeb.name, "https://cdn5-thumbs.motherlessmedia.com/thumbs/63418A0-zoom.jpg?from_helper", "https://thumb-p7.xhcdn.com/a/e_dnTd59fCYdvYA6l0t-Og/000/101/739/747_1000.jpg");
        }

        public bool TakeGuess(IGuessGame game, string nameGuess)
        {
            return game.GuessCorrect(nameGuess);
        }
        
        public string GetFullName(IGuessGame game)
        {
            return game.GetFullName();
        }

        public string GetCropPic(IGuessGame game)
        {
            return game.GetCropPic();
        }

        public string GetFullPic(IGuessGame game)
        {
            return game.GetFullPic();
        }
    }

    public class Celeb
    {
        public string name;
    }
}