using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class EnchantEffect
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Enchantment level
	/// </summary>
	[JsonPropertyName("enchant_level")]
	public double EnchantLevel { get; set; }

	/// <summary>
	///     Enchantment effect type (Refer to /meta/stat API)
	/// </summary>
	[JsonPropertyName("stat_id")]
	public string StatId { get; set; }

	/// <summary>
	///     Enchantment effect value
	/// </summary>
	[JsonPropertyName("value")]
	public double Value { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}