using FluentAssertions;
using TheFirstDescendant.Tests.Helpers;

namespace TheFirstDescendant.Tests.ServiceTests;

public class MinimalServiceTests : IDisposable
{
	private readonly HttpClient _httpClient;
	private readonly MockHttpMessageHandler _mockHandler;
	private readonly TheFirstDescendantService _service;

	public MinimalServiceTests()
	{
		_mockHandler = new MockHttpMessageHandler();
		_httpClient = new HttpClient(_mockHandler)
		{
			BaseAddress = new Uri("https://open.api.nexon.com/")
		};
		_service = new TheFirstDescendantService(_httpClient);
	}

	public void Dispose()
	{
		_httpClient?.Dispose();
		_mockHandler?.Dispose();
		GC.SuppressFinalize(this);
	}

	[Fact]
	public async Task GetDescendantsAsync_CallsCorrectEndpoint()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/descendant.json", new List<object>());

		// Act
		var result = await _service.GetDescendantsAsync();

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.Should().HaveCount(1);
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Contain("/en/descendant.json");
	}

	[Fact]
	public async Task GetWeaponsAsync_CallsCorrectEndpoint()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/weapon.json", new List<object>());

		// Act
		var result = await _service.GetWeaponsAsync();

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Contain("/en/weapon.json");
	}

	[Fact]
	public async Task GetModulesAsync_CallsCorrectEndpoint()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/module.json", new List<object>());

		// Act
		var result = await _service.GetModulesAsync();

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Contain("/en/module.json");
	}

	[Fact]
	public async Task GetReactorsAsync_CallsCorrectEndpoint()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/reactor.json", new List<object>());

		// Act
		var result = await _service.GetReactorsAsync();

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Contain("/en/reactor.json");
	}

	[Fact]
	public async Task GetExternalComponentsAsync_CallsCorrectEndpoint()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/external-component.json", new List<object>());

		// Act
		var result = await _service.GetExternalComponentsAsync();

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Contain("/en/external-component.json");
	}

	[Fact]
	public async Task GetAmorphousRewardsAsync_CallsEndpointWithoutLanguage()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/amorphous-reward.json", new List<object>());

		// Act
		var result = await _service.GetAmorphousRewardsAsync();

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().NotContain("/en/");
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Contain("amorphous-reward.json");
	}

	[Fact]
	public void GetRawClient_ReturnsApiClientInstance()
	{
		// Act
		var rawClient = _service.GetRawClient();

		// Assert
		rawClient.Should().NotBeNull();
		rawClient.Should().BeOfType<TheFirstDescendantApiClient>();
	}

	[Fact]
	public async Task CancellationTokenSupport_AllMethodsSupportCancellation()
	{
		// Arrange
		var cancellationTokenSource = new CancellationTokenSource();
		await cancellationTokenSource.CancelAsync();

		// Act & Assert
		await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
			                                                        _service.GetDescendantsAsync(cancellationTokenSource.Token));
	}

	[Fact]
	public async Task ServiceMethods_AlwaysUseEnglish()
	{
		// Test multiple endpoints to ensure they all use English
		var testEndpoints = new[]
		{
			("GetDescendantsAsync", "/en/descendant.json"),
			("GetWeaponsAsync", "/en/weapon.json"),
			("GetModulesAsync", "/en/module.json"),
			("GetReactorsAsync", "/en/reactor.json"),
			("GetStatsAsync", "/en/stat.json"),
			("GetTitlesAsync", "/en/title.json")
		};

		foreach (var (methodName, expectedPath) in testEndpoints)
		{
			// Arrange
			_mockHandler.Clear();
			var expectedUrl = $"https://open.api.nexon.com/static/tfd/meta{expectedPath}";
			_mockHandler.AddSuccessResponse(expectedUrl, new List<object>());

			// Act
			switch (methodName)
			{
				case "GetDescendantsAsync":
					await _service.GetDescendantsAsync();
					break;
				case "GetWeaponsAsync":
					await _service.GetWeaponsAsync();
					break;
				case "GetModulesAsync":
					await _service.GetModulesAsync();
					break;
				case "GetReactorsAsync":
					await _service.GetReactorsAsync();
					break;
				case "GetStatsAsync":
					await _service.GetStatsAsync();
					break;
				case "GetTitlesAsync":
					await _service.GetTitlesAsync();
					break;
			}

			// Assert
			_mockHandler.Requests.Should().HaveCount(1, $"Expected 1 request for {methodName}");
			_mockHandler.Requests.First().RequestUri?.ToString().Should().Contain("/en/", $"Expected English language code for {methodName}");
		}
	}
}