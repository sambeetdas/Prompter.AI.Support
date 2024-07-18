using Microsoft.Extensions.DependencyInjection;
using Prompter.Models;

namespace Prompter.Test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Ask question:");
            string input = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(input))
            {
                var services = new ServiceCollection();
                services.AddPrompterService();

                var config = new InferenceConfigModel
                {
                    ModelProvider = ModelProviderEnum.HuggingFace,
                    ModelName = "mistralai/Mistral-7B-Instruct-v0.3",
                    AuthKey = "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",
                    ToolModel = new ToolModel
                    {
                        APISource = new List<APISourceDetails>
                    {
                        new APISourceDetails
                        {
                            Id = "get_all_phones",
                            Description = "This api is used to get the list of phones",
                            Url = "https://api.restful-api.dev/objects",
                            Method = "GET",
                            Headers = new Dictionary<string, string>(),
                            Request = string.Empty,
                            ResponseKeys = new Dictionary<string, string>()
                            {
                                { "name", "name" },
                                { "price","price" }
                            }
                        },
                        new APISourceDetails
                        {
                            Id = "get_breeds_of_dogs",
                            Description = "This api is used to get the list of breeds of dogs",
                            Url = "https://dogapi.dog/api/v2/breeds",
                            Method = "GET",
                            Headers = new Dictionary<string, string>(),
                            Request = string.Empty,
                            ResponseKeys = new Dictionary<string, string>()
                            {
                                { "name", "name" },
                                { "description","description" }
                            }
                        }
                    }
                    }
                };



                InferenceModule inferenceModule = new InferenceModule(config);

                var infModel = new InferenceModel
                {
                    UserPrompt = input,
                };

                var response = await inferenceModule.Processer(infModel);

                Console.WriteLine(response);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No question found. Re-run the application again.");
            }
        }
    }
}
