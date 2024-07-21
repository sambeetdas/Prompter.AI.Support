using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Prompter.AI.Support;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<InferenceService>();

var app = builder.Build();


app.MapGet("/inference/{input}", async (string input, InferenceService service) =>
{
    return await service.Execute(input);
});

app.Run();
