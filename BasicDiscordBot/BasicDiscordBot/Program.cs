using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace BasicDiscordBot
{
    class Program
    {
        static DiscordClient discord;
        static CommandsNextModule commands;
        static WolframAlphaRequestHandler wolframAlphaRequestHandler;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "placeholder",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });
            

            discord.MessageCreated += async e =>
            {
                List<String> listStrLineElements = e.Message.Content.Split(' ').ToList();
                if (string.Equals(listStrLineElements.ElementAt(0), "ping", StringComparison.OrdinalIgnoreCase))
                    await e.Message.RespondAsync("pong!");
                if (string.Equals(listStrLineElements.ElementAt(0), "hello", StringComparison.OrdinalIgnoreCase))
                    await e.Message.RespondAsync("Hi "+e.Message.Author.Username+"!");
                //if (string.Equals(listStrLineElements.ElementAt(0), "scrabble", StringComparison.OrdinalIgnoreCase))
                //{
                //    WolframAlphaService service = new WolframAlphaService("placeholder");
                //    WolframAlphaRequest request = new WolframAlphaRequest(listStrLineElements.ElementAt(1) + " scrabble");
                //    WolframAlphaResult result = await service.Compute(request);
                //    var scrabbleScore = result.QueryResult.Pods.ElementAt(1);
                //    foreach (var pod in result.QueryResult.Pods)
                //    {
                //        if (pod.SubPods != null)
                //        {
                //            Console.WriteLine(pod.Title);
                //            await e.Channel.SendMessageAsync(pod.Title);
                //            foreach (var subpod in pod.SubPods)
                //            {
                //                await e.Channel.SendMessageAsync("    " + subpod.Plaintext);
                //            }
                //        }
                //    }
                //}
            };
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });
            commands.RegisterCommands<MyCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
