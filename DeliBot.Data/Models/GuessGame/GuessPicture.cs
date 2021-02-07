namespace DeliBot.Data.Models.GuessGame
{
    public class GuessPicture
    {
        public int Id { get; set; }
        public virtual GuessOption  GuessOption { get; set; }
        public string CropPicUrl { get; set; }
        public string FullPicUrl { get; set; }
    }
}