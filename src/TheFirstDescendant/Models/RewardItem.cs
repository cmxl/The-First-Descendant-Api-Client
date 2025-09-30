using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class RewardItem
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Type of the Amorphous Material open reward item
	/// </summary>
	[JsonPropertyName("meta_type")]
	public string MetaType { get; set; }

	/// <summary>
	///     Identifier of the Amorphous Material open reward item
	/// </summary>
	[JsonPropertyName("meta_id")]
	public string MetaId { get; set; }

	/// <summary>
	///     Reward probability (%)
	/// </summary>
	[JsonPropertyName("rate")]
	public float Rate { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}