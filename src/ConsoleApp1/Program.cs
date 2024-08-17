using FsToolkit.ErrorHandling;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http.CSharp;

var http = new HttpClient();

var scenarioV4 = Scenario.Create("v4", async context =>
{
    var request = Http.CreateRequest("GET", "http://localhost:5223");
    var response = await Http.Send<Response1>(http, request).ConfigureAwait(false);

    return response.Payload.Value.Data switch
    {
        { Result: "worked" } => Response.Ok(200),
        _ => Response.Fail(9000)
    };
})
.WithoutWarmUp()
.WithLoadSimulations(
    Simulation.Inject(rate: 500,
                      interval: TimeSpan.FromSeconds(1),
                      during: TimeSpan.FromSeconds(10))
);

var scenarioV5 = Scenario.Create("v5", async context =>
{
    var request = Http.CreateRequest("GET", "http://localhost:5223");
    var response = await Http.Send<Response1>(http, request).ConfigureAwait(false);

    return response.Payload.Value.Data switch
    {
        { Result: "worked" } => Response.Ok(200),
        _ => Response.Fail(9000)
    };
})
.WithoutWarmUp()
.WithLoadSimulations(
    Simulation.Inject(rate: 500,
                      interval: TimeSpan.FromSeconds(1),
                      during: TimeSpan.FromSeconds(10))
);

NBomberRunner.RegisterScenarios(scenarioV4).Run();
NBomberRunner.RegisterScenarios(scenarioV5).Run();
