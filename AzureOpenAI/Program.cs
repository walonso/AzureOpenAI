using Azure.AI.OpenAI;
using AzureOpenAI;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string aoai_endpoint = builder.Configuration.GetSection("AOAI:AOAI_ENDPOINT").Value;
string aoai_keys = builder.Configuration.GetSection("AOAI:AOAI_KEY").Value;
string aoai_gpt35_model = builder.Configuration.GetSection("AOAI:AOAI_DEPLOYMENTID_GPT35_TURBO").Value;
OpenAIClient client = new(new Uri(aoai_endpoint), new Azure.AzureKeyCredential(aoai_keys));
builder.Services.AddSingleton<IAIPrompt>(x =>
      ActivatorUtilities.CreateInstance<AzureOpenAI.AzureOpenAI>(x, client, aoai_gpt35_model));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
