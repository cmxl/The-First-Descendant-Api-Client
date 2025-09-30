using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class StatEffectPerLevel
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     vehicle level
	/// </summary>
	[JsonPropertyName("vehicle_level")]
	public double VehicleLevel { get; set; }

	/// <summary>
	///     stat effect by level information
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