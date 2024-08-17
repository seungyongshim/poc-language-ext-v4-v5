using LanguageExt;
using static LanguageExt.Prelude;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () => 
{
    var effect = Aff(async () =>
    {
        // Heavy wwwork
        await Task.Delay(1000);
        return new
        {
            Result = "worked1"
        };
    });

    return (await effect.Run().ConfigureAwait(false)).ThrowIfFail();
});

app.Run();
