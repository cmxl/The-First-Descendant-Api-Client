using Microsoft.Extensions.DependencyInjection;

namespace TheFirstDescendant.Models;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTfdApiClient(this IServiceCollection services, string? baseUrl = null)
    {
        // Use typed HttpClient for better lifecycle management
        services.AddHttpClient<TheFirstDescendantService>("TfdApiClient", client =>
        {
            client.BaseAddress = new Uri(baseUrl ?? "https://open.api.nexon.com");
            client.DefaultRequestHeaders.Add("User-Agent", "TFDTool/1.0");
            client.Timeout = TimeSpan.FromSeconds(30);
        });

        return services;
    }

    public static IServiceCollection AddTfdApiClient(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.AddHttpClient<TheFirstDescendantService>("TfdApiClient", configureClient);
        return services;
    }

    public static IServiceCollection AddTfdApiClient(this IServiceCollection services, string clientName, string? baseUrl = null)
    {
        services.AddHttpClient<TheFirstDescendantService>(clientName, client =>
        {
            client.BaseAddress = new Uri(baseUrl ?? "https://open.api.nexon.com");
            client.DefaultRequestHeaders.Add("User-Agent", "TFDTool/1.0");
            client.Timeout = TimeSpan.FromSeconds(30);
        });

        return services;
    }

    public static IServiceCollection AddTfdApiClient(this IServiceCollection services, string clientName, Action<HttpClient> configureClient)
    {
        services.AddHttpClient<TheFirstDescendantService>(clientName, configureClient);
        return services;
    }
}