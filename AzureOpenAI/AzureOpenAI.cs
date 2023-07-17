using Azure;
using Azure.AI.OpenAI;

namespace AzureOpenAI
{    
    public class AzureOpenAI : IAIPrompt
    {
        private OpenAIClient _openAIClient;
        private string _engine;
        public AzureOpenAI(OpenAIClient client, string engine)
        {
            _openAIClient = client;
            _engine = engine;
        }

        public async Task<string> prompt(string prompt)
        {
            Response<Completions> completionsResponse =
                await _openAIClient.GetCompletionsAsync(_engine, prompt);
            string completion = completionsResponse.Value.Choices[0].Text;
            return completion;
        }
    }
}
