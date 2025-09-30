using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class OptionEffect
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Option effect stat identifier (refer to /meta/stat API)
	/// </summary>
	[JsonPropertyName("stat_id")]
	public string StatId { get; set; }

	/// <summary>
	///     Stat operation type (Add:addition, Multiply:multiplication)
	/// </summary>
	[JsonPropertyName("operator_type")]
	public string OperatorType { get; set; }

	/// <summary>
	///     Minimum stat value
	/// </summary>
	[JsonPropertyName("min_stat_value")]
	public double MinStatValue { get; set; }

	/// <summary>
	///     Maximum stat value
	/// </summary>
	[JsonPropertyName("max_stat_value")]
	public double MaxStatValue { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}