using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DeliBot.Data.GuessGame;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace DeliBot.Console.Commands
{
    public class GuessCommands : BaseCommandModule
    {
        private readonly IGuessService _guessService;

        public GuessCommands(IGuessService guessService)
        {
            _guessService = guessService;
        }

        [Command("guess")]
        [Description("Play a round of guess the celeb")]
        public async Task Guess(CommandContext ctx)
        {

            IGuessGame game = _guessService.NewGame();
            bool gameWon = false;
            DiscordUser winningMember = null;

            InteractivityExtension interactivity = ctx.Client.GetInteractivity();

            DiscordEmbed startGameEmbed = new DiscordEmbedBuilder()
            {
                Title = "Guess who game",
                Description = "Type your guess",
                Author = new DiscordEmbedBuilder.EmbedAuthor()
                {
                    Name = ctx.Message.Author.Username,
                    IconUrl = ctx.Message.Author.AvatarUrl
                },
                ImageUrl = _guessService.GetCropPic(game)
            }.Build();

            await ctx.RespondAsync(embed: startGameEmbed).ConfigureAwait(false);

            Regex rx = new Regex(@"^[A-Za-z]");

            await interactivity.WaitForMessageAsync(message =>
            {
                if (message.Channel != ctx.Message.Channel || message.Author.IsBot
                || !rx.IsMatch(message.Content)) return false;

                bool correctGuess = _guessService.TakeGuess(game, message.Content);

                if (!correctGuess)
                {
                    message.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":x:"));
                    return false;
                }
                
                gameWon = true;
                winningMember = message.Author;
                return true;

            }).ConfigureAwait(false);
            
            DiscordEmbed endGameEmbed = new DiscordEmbedBuilder()
            {
                Title = gameWon ? $"Game won by {winningMember.Username}" : "Guess who - ended",
                Description = "It was: " + _guessService.GetFullName(game),
                ImageUrl = _guessService.GetFullPic(game),
                Color = gameWon ? DiscordColor.Green : DiscordColor.Red
            }.Build();
            
            await ctx.RespondAsync(embed: endGameEmbed).ConfigureAwait(false);
        }
    }
}