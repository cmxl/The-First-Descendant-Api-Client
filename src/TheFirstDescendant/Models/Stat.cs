using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Stat
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Base stat identifier
	/// </summary>
	[JsonPropertyName("stat_id")]
	public string StatId { get; set; }

	/// <summary>
	///     Base stat name
	/// </summary>
	[JsonPropertyName("stat_name")]
	public string StatName { get; set; }

	/// <summary>
	///     Base stat sort order (ascending)
	/// </summary>
	[JsonPropertyName("stat_order_no")]
	public double? StatOrderNo { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}