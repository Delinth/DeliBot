using System;
using System.Linq;
using DeliBot.Data;
using DeliBot.Data.GuessGame;
using DeliBot.Data.Models.GuessGame;

namespace DeliBot.Service
{
    public class GuessService : IGuessService
    {
        private readonly DeliBotContext _context;

        public GuessService(DeliBotContext context)
        {
            _context = context;
        }

        public IGuessGame NewGame()
        {
            Random random = new Random();
            int toSkip = random.Next(0, _context.GuessOptions.Count());

            GuessOption guess = _context.GuessOptions.Skip(toSkip).Take(1).First();

            int toSkipPics = random.Next(0, guess.GuessPictures.Count());

            GuessPicture guessPic = guess.GuessPictures.Skip(toSkipPics).Take(1).First();

            return new GuessGame($"{guess.Person.FirstName} {guess.Person.LastName}", guessPic.CropPicUrl, guessPic.FullPicUrl);
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
}