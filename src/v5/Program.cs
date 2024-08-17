using LanguageExt;
using static LanguageExt.Prelude;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
