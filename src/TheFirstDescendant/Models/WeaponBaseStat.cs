using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class WeaponBaseStat
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Weapon base spec identifier (Refer to /meta/stat API)
	/// </summary>
	[JsonPropertyName("stat_id")]
	public string StatId { get; set; }

	/// <summary>
	///     Weapon base spec value
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