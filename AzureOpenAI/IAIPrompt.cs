namespace AzureOpenAI
{
    public interface IAIPrompt
    {
        Task<string> prompt(string prompt);
    }
}
