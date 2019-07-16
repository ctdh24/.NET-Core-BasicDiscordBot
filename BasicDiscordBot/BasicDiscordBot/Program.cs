using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace BasicDiscordBot
{
    class Program
    {
        static DiscordClient discord;
        static WolframAlphaRequestHandler wolframAlphaRequestHandler;
        static TableTopRPGStatRoller tableTopRPGStatRoller;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "PLACEHOLDER",
                TokenType = TokenType.Bot
            });
            

            discord.MessageCreated += async e =>
            {
                List<String> listStrLineElements = e.Message.Content.Split(' ').ToList();
                if (string.Equals(listStrLineElements.ElementAt(0), "ping", StringComparison.OrdinalIgnoreCase))
                    await e.Message.RespondAsync("pong!");
                if (string.Equals(listStrLineElements.ElementAt(0), "hello", StringComparison.OrdinalIgnoreCase))
                    await e.Message.RespondAsync("Hi "+e.Message.Author.Username+"!");
                if (string.Equals(listStrLineElements.ElementAt(0), "roll", StringComparison.OrdinalIgnoreCase))
                    await e.Message.RespondAsync(tableTopRPGStatRoller.RollStats(listStrLineElements.ElementAt(1)));
                //if (string.Equals(listStrLineElements.ElementAt(0), "scrabble", StringComparison.OrdinalIgnoreCase))
                //{
                //    await e.Message.RespondAsync(wolframAlphaRequestHandler.ScrabbleScoreAsync(listStrLineElements.ElementAt(1)));
                //}
            };
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
