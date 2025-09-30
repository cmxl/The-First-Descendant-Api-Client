using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Tier
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Tier identifier
	/// </summary>
	[JsonPropertyName("tier_id")]
	public string TierId { get; set; }

	/// <summary>
	///     Tier name
	/// </summary>
	[JsonPropertyName("tier_name")]
	public string TierName { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}