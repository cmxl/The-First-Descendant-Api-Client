using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class FellowDetail
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Fellow level
	/// </summary>
	[JsonPropertyName("fellow_level")]
	public double FellowLevel { get; set; }

	/// <summary>
	///     Search radius values for fellow items by level
	/// </summary>
	[JsonPropertyName("search_radius_value")]
	public double? SearchRadiusValue { get; set; }

	/// <summary>
	///     Stat effect by level
	/// </summary>
	[JsonPropertyName("stat_effect")]
	public ICollection<StatEffect> StatEffect { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}