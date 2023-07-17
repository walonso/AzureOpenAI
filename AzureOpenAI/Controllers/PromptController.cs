using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1;

namespace AzureOpenAI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromptController : ControllerBase
    {
        private readonly ILogger<PromptController> _logger;
        private readonly IAIPrompt _aiPrompt;


        public PromptController(ILogger<PromptController> logger, IAIPrompt aiPrompt)
        {
            _logger = logger;
            _aiPrompt = aiPrompt;
        }

        [HttpGet(Name = "GetResponse")]
        public async Task<String> Prompt(string message)
        {
            string response = await _aiPrompt.prompt(message);
            return response;
        }
    }
}
