using System.Net;
using FluentAssertions;
using TheFirstDescendant.Models;
using TheFirstDescendant.Tests.Helpers;

namespace TheFirstDescendant.Tests.ApiClientTests;

public class MinimalApiClientTests : IDisposable
{
	private readonly TheFirstDescendantApiClient _apiClient;
	private readonly HttpClient _httpClient;
	private readonly MockHttpMessageHandler _mockHandler;

	public MinimalApiClientTests()
	{
		_mockHandler = new MockHttpMessageHandler();
		_httpClient = new HttpClient(_mockHandler)
		{
			BaseAddress = new Uri("https://open.api.nexon.com/")
		};
		_apiClient = new TheFirstDescendantApiClient(_httpClient);
	}

	public void Dispose()
	{
		_httpClient?.Dispose();
		_mockHandler?.Dispose();
		GC.SuppressFinalize(this);
	}

	[Fact]
	public async Task GetDescendantsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/descendant.json", new List<object>());

		// Act
		var result = await _apiClient.GetDescendantsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.Should().HaveCount(1);
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/descendant.json");
	}

	[Fact]
	public async Task GetWeaponsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/weapon.json", new List<object>());

		// Act
		var result = await _apiClient.GetWeaponsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/weapon.json");
	}

	[Fact]
	public async Task GetModulesAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/module.json", new List<object>());

		// Act
		var result = await _apiClient.GetModulesAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/module.json");
	}

	[Fact]
	public async Task GetReactorsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/reactor.json", new List<object>());

		// Act
		var result = await _apiClient.GetReactorsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/reactor.json");
	}

	[Fact]
	public async Task GetExternalComponentsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/external-component.json", new List<object>());

		// Act
		var result = await _apiClient.GetExternalComponentsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/external-component.json");
	}

	[Fact]
	public async Task GetRewardsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/reward.json", new List<object>());

		// Act
		var result = await _apiClient.GetRewardsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/reward.json");
	}

	[Fact]
	public async Task GetStatsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/stat.json", new List<object>());

		// Act
		var result = await _apiClient.GetStatsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/stat.json");
	}

	[Fact]
	public async Task GetVoidBattlesAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/void-battle.json", new List<object>());

		// Act
		var result = await _apiClient.GetVoidBattlesAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/void-battle.json");
	}

	[Fact]
	public async Task GetTitlesAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/title.json", new List<object>());

		// Act
		var result = await _apiClient.GetTitlesAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/title.json");
	}

	[Fact]
	public async Task GetConsumableMaterialsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/consumable-material.json", new List<object>());

		// Act
		var result = await _apiClient.GetConsumableMaterialsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/consumable-material.json");
	}

	[Fact]
	public async Task GetResearchsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/research.json", new List<object>());

		// Act
		var result = await _apiClient.GetResearchsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/research.json");
	}

	[Fact]
	public async Task GetAmorphousRewardsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/amorphous-reward.json", new List<object>());

		// Act
		var result = await _apiClient.GetAmorphousRewardsAsync(CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/amorphous-reward.json");
	}

	[Fact]
	public async Task GetWeaponTypesAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/weapon-type.json", new List<object>());

		// Act
		var result = await _apiClient.GetWeaponTypesAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/weapon-type.json");
	}

	[Fact]
	public async Task GetFellowsAsync_Success_ReturnsCollection()
	{
		// Arrange
		_mockHandler.AddSuccessResponse("https://open.api.nexon.com/static/tfd/meta/en/fellow.json", new List<object>());

		// Act
		var result = await _apiClient.GetFellowsAsync(LanguageCode.En, CancellationToken.None);

		// Assert
		result.Should().NotBeNull();
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be("https://open.api.nexon.com/static/tfd/meta/en/fellow.json");
	}

	[Theory]
	[InlineData(HttpStatusCode.BadRequest)]
	[InlineData(HttpStatusCode.Forbidden)]
	[InlineData(HttpStatusCode.TooManyRequests)]
	[InlineData(HttpStatusCode.InternalServerError)]
	public async Task AllEndpoints_ErrorStatusCodes_ThrowsApiException(HttpStatusCode statusCode)
	{
		// Arrange
		_mockHandler.AddErrorResponse("https://open.api.nexon.com/static/tfd/meta/en/descendant.json", statusCode);

		// Act & Assert
		var exception = await Assert.ThrowsAnyAsync<ApiException>(() =>
			                                                          _apiClient.GetDescendantsAsync(LanguageCode.En, CancellationToken.None));
		exception.StatusCode.Should().Be((int)statusCode);
	}

	[Fact]
	public async Task CancellationToken_Honored()
	{
		// Arrange
		var cancellationTokenSource = new CancellationTokenSource();
		cancellationTokenSource.Cancel();

		// Act & Assert
		await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
			                                                        _apiClient.GetDescendantsAsync(LanguageCode.En, cancellationTokenSource.Token));
	}

	[Theory]
	[InlineData(LanguageCode.Ko, "ko")]
	[InlineData(LanguageCode.En, "en")]
	[InlineData(LanguageCode.De, "de")]
	[InlineData(LanguageCode.Fr, "fr")]
	[InlineData(LanguageCode.Ja, "ja")]
	[InlineData(LanguageCode.ZhCn, "zh-CN")]
	[InlineData(LanguageCode.ZhTw, "zh-TW")]
	[InlineData(LanguageCode.It, "it")]
	[InlineData(LanguageCode.Pl, "pl")]
	[InlineData(LanguageCode.Pt, "pt")]
	[InlineData(LanguageCode.Ru, "ru")]
	[InlineData(LanguageCode.Es, "es")]
	public async Task LanguageCodes_ConstructCorrectUrls(LanguageCode languageCode, string expectedLangCode)
	{
		// Arrange
		var expectedUrl = $"https://open.api.nexon.com/static/tfd/meta/{expectedLangCode}/descendant.json";
		_mockHandler.AddSuccessResponse(expectedUrl, new List<object>());

		// Act
		await _apiClient.GetDescendantsAsync(languageCode, CancellationToken.None);

		// Assert
		_mockHandler.Requests.Should().HaveCount(1);
		_mockHandler.Requests.First().RequestUri?.ToString().Should().Be(expectedUrl);
	}
}