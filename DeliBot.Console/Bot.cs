using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using GuessWhoBot.Console.Commands;
using Microsoft.Extensions.Configuration;

namespace GuessWhoBot.Console
{
    public class Bot
    {
        private readonly IServiceProvider _services;
        private readonly IConfiguration _configuration;

        public CommandsNextExtension Commands { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }

        public Bot(IConfiguration configuration, IServiceProvider services)
        {
            _configuration = configuration;
            _services = services;
        }
        
        public async Task RunAsync()
        {
            DiscordClient discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = _configuration.GetValue<string>("Discord:Token"),
                TokenType = TokenType.Bot,
                AutoReconnect = true
            });

            CommandsNextConfiguration commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] {"$"},
                EnableDms = false,
                EnableMentionPrefix = true,
                Services = _services
            };

            discord.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            Commands = discord.UseCommandsNext(commandsConfig);
            
            Commands.RegisterCommands<FunCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}