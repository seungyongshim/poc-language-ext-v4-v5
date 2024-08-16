using LanguageExt;
using static LanguageExt.Prelude;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () => 
{
    var effect = Aff(() => Task.Delay(1000).ToUnit().ToValue());

    await effect.Run().ConfigureAwait(false);
});

app.Run();
