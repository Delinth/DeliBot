using System.Collections.Generic;

namespace DeliBot.Data.Models.GuessGame
{
    public class GuessOption
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual List<GuessPicture> GuessPictures { get; set; }
        public virtual List<GuessHint> GuessHints { get; set; }
    }
}