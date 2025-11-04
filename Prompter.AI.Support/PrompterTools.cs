using Prompter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.AI.Support
{
    public class PrompterTools
    {
        private int _counter = 0; // Instance state for demonstration

        [AgentTool("GetCurrentTime", "Gets the current UTC time.")]
        public static string GetCurrentTime()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss UTC");
        }

        [AgentTool("EchoMessage", "Echoes back the input message.")]
        public string EchoMessage(string message)
        {
            return $"You said: \"{message}\"";
        }

        [AgentTool("FetchDataAsync", "Fetches data from a given URL.")]
        public async Task<string> FetchDataAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Console.WriteLine($"Fetching data from: {url}");
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return $"Successfully fetched {responseBody.Length} characters. First 100: {responseBody.Substring(0, Math.Min(responseBody.Length, 100))}...";
                }
            }
            catch (HttpRequestException e)
            {
                return $"Error fetching data: {e.Message}";
            }
        }

        [AgentTool("SayHello", "Just says hello.")]
        public string SayHello()
        {
            return "Hello from SayHello!";
        }

        [AgentTool("IncrementCounter", "Increments an internal counter and returns its new value.")]
        public string IncrementCounter()
        {
            _counter++;
            return $"Counter is now: {_counter}";
        }
    }
}
