using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace BasicDiscordBot
{
    public class MyCommands
    {
        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");

        }
        [Command("roll")]
        public async Task Roll(CommandContext ctx, String diceInput)
        {
            String[] inputs = diceInput.Split("d");
            String rolls = "";
            int result = 0;
            var rnd = new Random();
            for (int dice = 0; dice < Int32.Parse(inputs[0]); dice++)
            {
                int roll = rnd.Next(1, Int32.Parse(inputs[1]));
                if (dice == 0) rolls += roll;
                else rolls = rolls + " + " + roll;
                result += roll;
            }
            await ctx.RespondAsync($"🎲 You rolled {rolls} = {result}");
        }
    }
}
