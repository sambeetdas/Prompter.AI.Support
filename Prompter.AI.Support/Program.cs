using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prompter.AI.Support;
using Prompter.Extensions;
using Prompter.Interfaces;
using Prompter.Models;
using Prompter.Services;
using System.Transactions;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddPromptDataLLM(config =>
{
    config.OpenAI.ApiKey = "your-openai-api-key";
    config.OpenAI.BaseUrl = "base-url";
    config.OpenAI.Model = "gpt-4o-mini";
    config.OpenAI.Version = "2024-08-01-preview";
    config.DefaultTimeoutSeconds = 30;
    config.EnableLogging = true;
});

builder.Services.AddTransient<IPromptService, PromptService>();

var app = builder.Build();
app.UseCors("AllowAll");

///Inference with SQL Server. Based on the input, it will query the database and return results.
app.MapPost("/sql-inference", async (RequestModel request, IPromptService promptService) =>
{


    var requestLLM = new LLMRequest
    {
        Question = request.Question,
        Provider = LLMProvider.OpenAI,
        DataSource = new DataSourceConfig
        {
            Type = DataSourceType.SqlServer,
            ConnectionString = "Server=localhost;Database=TestDB;Trusted_Connection=true;",
            DBSchema = File.ReadAllText("InputForInference\\dbschema.txt")
        }
    };

    return await promptService.ProcessQuestionWithDataAsync(requestLLM);
});

///Inference with in-memory collection in json format. Based on the input, it will query the json and return results.
app.MapPost("/json-inference", async (RequestModel request, IPromptService promptService) =>
{


    var requestLLM = new LLMRequest
    {
        Question = request.Question,
        Provider = LLMProvider.OpenAI,
        DataSource = new DataSourceConfig
        {
            Type = DataSourceType.InMemoryCollection,            
            JsonSchema = File.ReadAllText("InputForInference\\jsonschema.txt"),
            JsonData = File.ReadAllText("InputForInference\\data.json")
        }
    };

    return await promptService.ProcessQuestionWithDataAsync(requestLLM);
});

app.Run();
