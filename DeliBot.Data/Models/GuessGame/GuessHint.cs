namespace DeliBot.Data.Models.GuessGame
{
    public class GuessHint
    {
        public int Id { get; set; }
        public virtual GuessOption GuessOption { get; set; }
        public string Hint { get; set; }
    }
}