using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using TheFirstDescendant.Models;
using Module = TheFirstDescendant.Models.Module;

namespace TheFirstDescendant;

public class TheFirstDescendantApiClient
{
	private static readonly Lazy<JsonSerializerOptions> Settings = new(CreateSerializerSettings, true);
	private readonly HttpClient _httpClient;
	private string? _baseUrl;

	public TheFirstDescendantApiClient(HttpClient httpClient)
	{
		BaseUrl = "https://open.api.nexon.com/";
		_httpClient = httpClient;
	}

	public string BaseUrl
	{
		get => _baseUrl ?? string.Empty;
		set
		{
			_baseUrl = value;
			if (!string.IsNullOrEmpty(_baseUrl) && !_baseUrl.EndsWith('/'))
				_baseUrl += '/';
		}
	}

	public bool ReadResponseAsString { get; set; }

	private static JsonSerializerOptions CreateSerializerSettings()
	{
		var settings = new JsonSerializerOptions();
		return settings;
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve descendant metadata
	/// </summary>
	/// <remarks>
	///     Retrieves descendant metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Descendant>> GetDescendantsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Descendant>("descendant.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve weapon metadata
	/// </summary>
	/// <remarks>
	///     Retrieves weapon metadata.&lt;br&gt; This API only provides path information. You can check it via a separate
	///     client.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Weapon>> GetWeaponsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Weapon>("weapon.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve module metadata
	/// </summary>
	/// <remarks>
	///     Retrieves module metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Module>> GetModulesAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Module>("module.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Reactor metadata
	/// </summary>
	/// <remarks>
	///     Retrieves Reactor metadata.&lt;br&gt; This API only provides path information. You can check it via a separate
	///     client.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Reactor>> GetReactorsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Reactor>("reactor.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve external component metadata
	/// </summary>
	/// <remarks>
	///     Retrieves external component metadata.&lt;/br&gt; This API only provides path information. You can check it via a
	///     separate client.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<ExternalComponent>> GetExternalComponentsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<ExternalComponent>("external-component.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Difficulty Level Rewards metadata
	/// </summary>
	/// <remarks>
	///     Retrieves Difficulty Level Rewards metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<DifficultyLevelReward>> GetRewardsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<DifficultyLevelReward>("reward.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve base stat metadata
	/// </summary>
	/// <remarks>
	///     Retrieves base stat metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Stat>> GetStatsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Stat>("stat.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Void Intercept Battle metadata
	/// </summary>
	/// <remarks>
	///     Retrieves Void Intercept Battle metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<VoidBattle>> GetVoidBattlesAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<VoidBattle>("void-battle.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Title metadata
	/// </summary>
	/// <remarks>
	///     Retrieves Title metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Title>> GetTitlesAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Title>("title.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve EXP metadata by descendant level
	/// </summary>
	/// <remarks>
	///     Retrieves the required EXP information for each Descendant level.
	/// </remarks>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<DescendantLevelDetail>> GetDescendantLevelDetailsAsync(CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<DescendantLevelDetail>("descendant-level-detail.json", null, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve EXP metadata by Mastery Rank
	/// </summary>
	/// <remarks>
	///     Retrieves the required EXP information for each Mastery Rank.
	/// </remarks>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<MasteryRankLevelDetail>> GetMasteryRankLevelDetailsAsync(CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<MasteryRankLevelDetail>("mastery-rank-level-detail.json", null, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve consumable items metadata
	/// </summary>
	/// <remarks>
	///     Retrieves metadata for consumable items.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<ConsumableMaterial>> GetConsumableMaterialsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<ConsumableMaterial>("consumable-material.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve research info metadata
	/// </summary>
	/// <remarks>
	///     Retrieves research info metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Research>> GetResearchsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Research>("research.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Amorphous Material open reward metadata
	/// </summary>
	/// <remarks>
	///     Retrieves metadata for rewards received when opening Amorphous Materials in the game.
	/// </remarks>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<AmorphousReward>> GetAmorphousRewardsAsync(CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<AmorphousReward>("amorphous-reward.json", null, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Amorphous Material opening location metadata
	/// </summary>
	/// <remarks>
	///     Retrieves metadata for the locations where Amorphous Materials are opened.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<AmorphousOpenConditionDescription>> GetAmorphousOpenConditionDescriptionsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<AmorphousOpenConditionDescription>("amorphous-open-condition-description.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve acquisition source info metadata
	/// </summary>
	/// <remarks>
	///     Retrieves metadata for acquisition source information.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<AcquisitionDetail>> GetAcquisitionDetailsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<AcquisitionDetail>("acquisition-detail.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve weapon type metadata
	/// </summary>
	/// <remarks>
	///     Retrieves metadata for weapon types.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<WeaponType>> GetWeaponTypesAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<WeaponType>("weapon-type.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve fellow metadata
	/// </summary>
	/// <remarks>
	///     Retrieves metadata for fellow metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Fellow>> GetFellowsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Fellow>("fellow.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve EXP metadata by fellow level
	/// </summary>
	/// <remarks>
	///     Retrieves required EXP metadata by fellow level.
	/// </remarks>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<FellowLevelDetail>> GetFellowLevelDetailsAsync(CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<FellowLevelDetail>("fellow-level-detail.json", null, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve tier metadata
	/// </summary>
	/// <remarks>
	///     Retrieves tier metadata.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Tier>> GetTiersAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Tier>("tier.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve core slot metadata
	/// </summary>
	/// <remarks>
	///     Retrieves metadata for core slots.
	/// </remarks>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<CoreSlot>> GetCoreSlotsAsync(CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<CoreSlot>("core-slot.json", null, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve core type metadata
	/// </summary>
	/// <remarks>
	///     Retrieves metadata information for core types.
	/// </remarks>
	/// <param name="languageCode">language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<CoreType>> GetCoreTypesAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<CoreType>("core-type.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve descendant group metadata
	/// </summary>
	/// <remarks>
	///     Retrieves descendant group metadata.
	/// </remarks>
	/// <param name="languageCode">Language codes</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<DescendantGroup>> GetDescendantGroupsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<DescendantGroup>("descendant-group.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve adaptability level metadata
	/// </summary>
	/// <remarks>
	///     Retrieves adaptability level metadata.
	/// </remarks>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<AdaptLevel>> GetAdaptLevelsAsync(CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<AdaptLevel>("adapt-level.json", null, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Arche tuning board group metadata
	/// </summary>
	/// <remarks>
	///     Retrieves Arche tuning board group metadata.
	/// </remarks>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<ArcheTuningBoardGroup>> GetArcheTuningBoardGroupsAsync(CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<ArcheTuningBoardGroup>("arche-tuning-board-group.json", null, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Arche tuning board metadata
	/// </summary>
	/// <remarks>
	///     Retrieves Arche tuning board metadata.
	/// </remarks>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<ArcheTuningBoard>> GetArcheTuningBoardsAsync(CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<ArcheTuningBoard>("arche-tuning-board.json", null, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve Arche tuning node metadata
	/// </summary>
	/// <remarks>
	///     Retrieves Arche tuning node metadata.
	/// </remarks>
	/// <param name="languageCode">Language codes</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<ArcheTuningNode>> GetArcheTuningNodesAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<ArcheTuningNode>("arche-tuning-node.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve customization item metadata
	/// </summary>
	/// <remarks>
	///     Retrieves customization item metadata.
	/// </remarks>
	/// <param name="languageCode">Language codes</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<CustomizingItem>> GetCustomizingItemsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<CustomizingItem>("customizing-item.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve medal meta data
	/// </summary>
	/// <remarks>
	///     Retrieves medal meta data.
	/// </remarks>
	/// <param name="languageCode">Language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Medal>> GetMedalsAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Medal>("medal.json", languageCode, cancellationToken);
	}

	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <summary>
	///     Retrieve vehicle meta data
	/// </summary>
	/// <remarks>
	///     Retrieves vehicle meta data.
	/// </remarks>
	/// <param name="languageCode">Language code</param>
	/// <returns>SUCCESS</returns>
	/// <exception cref="ApiException">A server side error occurred.</exception>
	public async Task<ICollection<Vehicle>> GetVehiclesAsync(LanguageCode languageCode, CancellationToken cancellationToken)
	{
		return await ExecuteRequestAsync<Vehicle>("vehicle.json", languageCode, cancellationToken);
	}

	private async Task<ICollection<T>> ExecuteRequestAsync<T>(string endpoint, LanguageCode? languageCode = null, CancellationToken cancellationToken = default)
	{
		var client = _httpClient;
		var disposeClient = false;
		try
		{
			using var request = new HttpRequestMessage();
			request.Method = new HttpMethod("GET");
			request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

			var url = BuildUrl(endpoint, languageCode);
			request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

			var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
			var disposeResponse = true;
			try
			{
				var headers = new Dictionary<string, IEnumerable<string>>();
				foreach (var item in response.Headers)
					headers[item.Key] = item.Value;

				foreach (var item in response.Content.Headers)
					headers[item.Key] = item.Value;

				return await HandleResponse<ICollection<T>>(response, headers, cancellationToken);
			}
			finally
			{
				if (disposeResponse)
					response.Dispose();
			}
		}
		finally
		{
			if (disposeClient)
				client.Dispose();
		}
	}

	private string BuildUrl(string endpoint, LanguageCode? languageCode = null)
	{
		var urlBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(_baseUrl)) urlBuilder.Append(_baseUrl);
		urlBuilder.Append("static/tfd/meta/");

		if (languageCode.HasValue)
		{
			urlBuilder.Append(ConvertToString(languageCode.Value, CultureInfo.InvariantCulture));
			urlBuilder.Append('/');
		}

		urlBuilder.Append(endpoint);
		return urlBuilder.ToString();
	}

	private async Task<T> HandleResponse<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
	{
		var status = (int)response.StatusCode;
		switch (status)
		{
			case 200:
			{
				var objectResponse = await ReadObjectResponseAsync<T>(response, headers, cancellationToken).ConfigureAwait(false);
				return objectResponse.Object ?? throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
			}
			case 400:
			{
				var objectResponse = await ReadObjectResponseAsync<ErrorMessage>(response, headers, cancellationToken).ConfigureAwait(false);
				if (objectResponse.Object == null) throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
				throw new ApiException<ErrorMessage>("Bad Request", status, objectResponse.Text, headers, objectResponse.Object, null);
			}
			case 403:
			{
				var objectResponse = await ReadObjectResponseAsync<ErrorMessage>(response, headers, cancellationToken).ConfigureAwait(false);
				if (objectResponse.Object == null) throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
				throw new ApiException<ErrorMessage>("Forbidden", status, objectResponse.Text, headers, objectResponse.Object, null);
			}
			case 429:
			{
				var objectResponse = await ReadObjectResponseAsync<ErrorMessage>(response, headers, cancellationToken).ConfigureAwait(false);
				if (objectResponse.Object == null) throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
				throw new ApiException<ErrorMessage>("Too Many Requests", status, objectResponse.Text, headers, objectResponse.Object, null);
			}
			case 500:
			{
				var objectResponse = await ReadObjectResponseAsync<ErrorMessage>(response, headers, cancellationToken).ConfigureAwait(false);
				if (objectResponse.Object == null) throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
				throw new ApiException<ErrorMessage>("Internal Server Error", status, objectResponse.Text, headers, objectResponse.Object, null);
			}
			default:
			{
				var responseData = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
				throw new ApiException("The HTTP status code of the response was not expected (" + status + ").", status, responseData, headers, null);
			}
		}
	}

	protected async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
	{
		if (ReadResponseAsString)
		{
			var responseText = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
			try
			{
				var typedBody = JsonSerializer.Deserialize<T>(responseText, Settings.Value);
				if (typedBody != null) return new ObjectResponseResult<T>(typedBody, responseText);
				var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
				throw new ApiException(message, (int)response.StatusCode, responseText, headers, null);
			}
			catch (JsonException exception)
			{
				var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
				throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
			}
		}

		try
		{
			await using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
			var typedBody = await JsonSerializer.DeserializeAsync<T>(responseStream, Settings.Value, cancellationToken).ConfigureAwait(false);
			if (typedBody != null) return new ObjectResponseResult<T>(typedBody, string.Empty);
			var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
			throw new ApiException(message, (int)response.StatusCode, null, headers, null);
		}
		catch (JsonException exception)
		{
			var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
			throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
		}
	}

	private string ConvertToString(object? value, CultureInfo cultureInfo)
	{
		switch (value)
		{
			case null:
				return string.Empty;
			case Enum:
			{
				var name = Enum.GetName(value.GetType(), value);
				if (name != null)
				{
					var field = value.GetType().GetTypeInfo().GetDeclaredField(name);
					if (field != null)
						if (field.GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
							return attribute.Value ?? name;

					var converted = Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo));
					return converted ?? string.Empty;
				}

				break;
			}
			case bool b:
				return Convert.ToString(b, cultureInfo).ToLowerInvariant();
			case byte[] bytes:
				return Convert.ToBase64String(bytes);
			case string[] strings:
				return string.Join(",", strings);
			default:
			{
				if (value.GetType().IsArray)
				{
					var valueArray = (Array)value;
					var valueTextArray = new string[valueArray.Length];
					for (var i = 0; i < valueArray.Length; i++) valueTextArray[i] = ConvertToString(valueArray.GetValue(i), cultureInfo);
					return string.Join(",", valueTextArray);
				}

				break;
			}
		}

		var result = Convert.ToString(value, cultureInfo);
		return result ?? string.Empty;
	}

	protected struct ObjectResponseResult<T>
	{
		public ObjectResponseResult(T responseObject, string responseText)
		{
			Object = responseObject;
			Text = responseText;
		}

		public T Object { get; }

		public string Text { get; }
	}
}