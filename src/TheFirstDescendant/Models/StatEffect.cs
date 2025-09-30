using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class StatEffect
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Stat effect types (Refer to /meta/stat API)
	/// </summary>
	[JsonPropertyName("stat_id")]
	public string StatId { get; set; }

	/// <summary>
	///     Stat effect value
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