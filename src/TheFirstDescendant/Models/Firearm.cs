using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Firearm
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Firearm ATK type (Refer to /meta/stat API)
	/// </summary>
	[JsonPropertyName("firearm_atk_type")]
	public string FirearmAtkType { get; set; }

	/// <summary>
	///     Firearm ATK value
	/// </summary>
	[JsonPropertyName("firearm_atk_value")]
	public double FirearmAtkValue { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}