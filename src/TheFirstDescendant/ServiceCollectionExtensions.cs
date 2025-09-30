using Microsoft.Extensions.DependencyInjection;

namespace TheFirstDescendant;

public static class ServiceCollectionExtensions
{
	private static readonly Action<HttpClient> _defaultConfigurationAction = o =>
	{
		o.BaseAddress = new Uri("https://open.api.nexon.com");
		o.Timeout = TimeSpan.FromSeconds(5);
	};

	public static IServiceCollection AddTheFirstDescendantServices(this IServiceCollection services, Action<HttpClient>? configure = null)
	{
		var configureHttpClient = configure ?? _defaultConfigurationAction;
		services.AddHttpClient<TheFirstDescendantService>("TheFirstDescendantApiClient", configureHttpClient);
		return services;
	}
}