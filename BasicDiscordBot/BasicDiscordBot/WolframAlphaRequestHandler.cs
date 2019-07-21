using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;
using DSharpPlus.EventArgs;

namespace BasicDiscordBot
{
    class WolframAlphaRequestHandler
    {
        WolframAlphaService service = new WolframAlphaService("TP6XVU-RTEHHAPVW3");
        public async void ScrabbleScoreAsync(String input, MessageCreateEventArgs e)
        {
            WolframAlphaRequest request = new WolframAlphaRequest(input+" scrabble");
            WolframAlphaResult result = await service.Compute(request);
            var scrabbleScore = result.QueryResult.Pods.ElementAt(1);
            foreach (var pod in result.QueryResult.Pods)
            {
                if (pod.SubPods != null)
                {
                    Console.WriteLine(pod.Title);
                    await e.Channel.SendMessageAsync(pod.Title);
                    foreach (var subpod in pod.SubPods)
                    {
                        await e.Channel.SendMessageAsync("    " + subpod.Plaintext);
                    }
                }
            }
        }
        
    }
}
