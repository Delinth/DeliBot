using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace DeliBot.Console.Commands
{
    public class GuessCommands : BaseCommandModule
    {

        [Command("guess")]
        public async Task Guess(CommandContext ctx)
        {
            string name = "Kim Kardashian";
            bool guessed = false;

            InteractivityExtension interactivity = ctx.Client.GetInteractivity();

            await ctx.Message.RespondWithFileAsync("kim-k.jpg","Type your guess now!").ConfigureAwait(false);

            await interactivity.WaitForMessageAsync(x =>
            {
                if (x.Channel != ctx.Message.Channel) return false;
                    
                if(x.Content.ToLower() == name.ToLower())
                {
                    guessed = true;
                    return true;
                }
                x.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":x:")).Wait();
                return false;
            });

            if (guessed)
            {
                await ctx.Message.RespondAsync("You guessed it").ConfigureAwait(false);
                return;
            }
            else
            {
                await ctx.Message.RespondAsync("Bummer, you didn't guess it!");
            }
        }
    }
}