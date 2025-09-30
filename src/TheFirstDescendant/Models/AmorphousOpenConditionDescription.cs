using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class AmorphousOpenConditionDescription
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Identifier for the Amorphous Material opening location
	/// </summary>
	[JsonPropertyName("amorphous_open_condition_id")]
	public string AmorphousOpenConditionId { get; set; }

	/// <summary>
	///     Amorphous Material opening location name
	/// </summary>
	[JsonPropertyName("amorphous_open_condition_name")]
	public string AmorphousOpenConditionName { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}