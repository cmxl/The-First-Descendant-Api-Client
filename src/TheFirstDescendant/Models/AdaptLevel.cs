using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class AdaptLevel
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Level
	/// </summary>
	[JsonPropertyName("level")]
	public double Level { get; set; }

	/// <summary>
	///     Required EXP for the next level
	/// </summary>
	[JsonPropertyName("exp_per_level")]
	public double ExpPerLevel { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}