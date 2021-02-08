using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace DeliBot.Console.Commands
{
    public class Utils : BaseCommandModule
    {
        [Command("avatar")]
        public async Task Avatar(CommandContext ctx, DiscordMember member)
        {
            DiscordEmbed embed = new DiscordEmbedBuilder()
            {
                Author = new DiscordEmbedBuilder.EmbedAuthor()
                {
                    Name = ctx.Message.Author.Username,
                    IconUrl = ctx.Message.Author.AvatarUrl
                },
                Title = $"{member.Username}'s avatar",
                ImageUrl = member.AvatarUrl
            }.Build();

            await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
        }
    }
}