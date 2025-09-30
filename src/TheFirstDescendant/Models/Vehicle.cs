using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Vehicle
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     vehicle identifier
	/// </summary>
	[JsonPropertyName("vehicle_id")]
	public string VehicleId { get; set; }

	/// <summary>
	///     vehicle name
	/// </summary>
	[JsonPropertyName("vehicle_name")]
	public string VehicleName { get; set; }

	/// <summary>
	///     vehicle description
	/// </summary>
	[JsonPropertyName("vehicle_description")]
	public string VehicleDescription { get; set; }

	/// <summary>
	///     vehicle grade
	/// </summary>
	[JsonPropertyName("vehicle_tier_id")]
	public string VehicleTierId { get; set; }

	/// <summary>
	///     vehicle image path
	/// </summary>
	[JsonPropertyName("image_url")]
	public string ImageUrl { get; set; }

	/// <summary>
	///     Stat effect
	/// </summary>
	[JsonPropertyName("stat_effect")]
	public ICollection<StatEffect> StatEffect { get; set; }

	/// <summary>
	///     stat effect by level information
	/// </summary>
	[JsonPropertyName("stat_effect_per_level")]
	public ICollection<StatEffectPerLevel> StatEffectPerLevel { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}