using System.Diagnostics;
using LanguageExt;
using static LanguageExt.Prelude;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

new Thread(async () =>
{
    while (true)
    {
        Console.WriteLine($"Threads: {Process.GetCurrentProcess().Threads.Count}");
        await Task.Delay(1000);
    }
}).Start();

app.MapGet("/", async () =>
{
    var effect = liftEff(async () =>
    {
        // Heavy wwwork
        await Task.Delay(1000).ConfigureAwait(false);
        return new
        {
            Result = "worked"
        };
    });

    return await effect.RunUnsafeAsync().ConfigureAwait(false);
});

app.Run();
