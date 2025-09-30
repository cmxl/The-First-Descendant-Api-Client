using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class WeaponType
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Weapon type
	/// </summary>
	[JsonPropertyName("weapon_type")]
	public string Type { get; set; }

	/// <summary>
	///     Weapon type name
	/// </summary>
	[JsonPropertyName("weapon_type_name")]
	public string TypeName { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}