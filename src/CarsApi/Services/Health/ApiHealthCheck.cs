using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace CarsApi.Services.Health;

public class ApiHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, 
        CancellationToken cancellationToken = default)
    {
        var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";

        var client = new RestClient();
        var request = new RestRequest(url, Method.Get);
        request.AddHeader("accept", "application/json");
        request.AddHeader("X-RapidAPI-Key", "11bf24e56emsh300f1cf74a59919p1d4ef9jsn95d784614af2");
        request.AddHeader("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");

        var response = client.Execute(request);

        if (response.IsSuccessful)
            return Task.FromResult(HealthCheckResult.Healthy());
        else
            return Task.FromResult(HealthCheckResult.Unhealthy());

    }
}
