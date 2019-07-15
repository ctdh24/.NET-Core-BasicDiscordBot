using System;
using System.Threading.Tasks;
using DSharpPlus;

namespace BasicDiscordBot
{
    class Program
    {
        static DiscordClient discord;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "<paste the token here>",
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async e =>
            {
                if (string.Equals(e.Message.Content, "ping", StringComparison.OrdinalIgnoreCase))
                    await e.Message.RespondAsync("pong!");
                if (string.Equals(e.Message.Content, "hello", StringComparison.OrdinalIgnoreCase))
                    await e.Message.RespondAsync("Hi "+e.Message.Author.Username+"!");
            };
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
