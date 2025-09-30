using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class StatDetail
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Stat type (Refer to /meta/stat API)
	/// </summary>
	[JsonPropertyName("stat_id")]
	public string StatId { get; set; }

	/// <summary>
	///     Value by stat type
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