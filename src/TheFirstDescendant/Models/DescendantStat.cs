using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class DescendantStat
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Level
	/// </summary>
	[JsonPropertyName("level")]
	public double Level { get; set; }

	/// <summary>
	///     Descendant details
	/// </summary>
	[JsonPropertyName("stat_detail")]
	public ICollection<StatDetail> StatDetail { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}