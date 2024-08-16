using LanguageExt;
using static LanguageExt.Prelude;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var effect = liftEff(async () =>
    {
        await Task.Delay(1000).ConfigureAwait(false);
        return unit;
    });

    effect.Run();
});

app.Run();
