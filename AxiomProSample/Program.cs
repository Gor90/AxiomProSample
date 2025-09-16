using Microsoft.Extensions.DependencyInjection;
using AxiomProSample.Repository;
using AxiomProSample.Service;

class Program
{
    static async Task Main()
    {
        var services = new ServiceCollection()
            .AddSingleton<IAxiomRepository, InMemoryAxiomRepository>()
            .AddTransient<AxiomService>()
            .BuildServiceProvider();

        var app = services.GetRequiredService<AxiomService>();
        await app.RunDemoAsync();
    }
}