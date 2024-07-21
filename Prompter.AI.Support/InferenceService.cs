using Prompter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.AI.Support
{
    public class InferenceService
    {
        public async Task<string> Execute(string input)
        {
            var config = InferenceModelBuilder.Build();

            InferenceModule inferenceModule = new InferenceModule(config);

            var infModel = new InferenceModel
            {
                UserPrompt = input,
            };

            return await inferenceModule.Processer(infModel);
        }
    }
}
