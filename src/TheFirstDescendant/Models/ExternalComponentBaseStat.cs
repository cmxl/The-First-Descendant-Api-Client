using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ExternalComponentBaseStat
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     External component level
	/// </summary>
	[JsonPropertyName("level")]
	public double Level { get; set; }

	/// <summary>
	///     External component effect type
	/// </summary>
	[JsonPropertyName("stat_id")]
	public string StatId { get; set; }

	/// <summary>
	///     External component effect value
	/// </summary>
	[JsonPropertyName("stat_value")]
	public double StatValue { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}