using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace BasicDiscordBot
{
    class WolframAlphaRequestHandler
    {
        WolframAlphaService service = new WolframAlphaService("PLACEHOLDER");
        public async System.Threading.Tasks.Task<string> ScrabbleScoreAsync(String input)
        {
            String scrabbleResult = "";
            WolframAlphaRequest request = new WolframAlphaRequest(input+"scrabble");
            WolframAlphaResult result = await service.Compute(request);
            var scrabbleScore = result.QueryResult.Pods.ElementAt(1);
            return scrabbleResult;
        }
        
    }
}
