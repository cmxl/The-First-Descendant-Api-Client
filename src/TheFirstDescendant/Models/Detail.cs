using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Detail
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Core option grade&lt;br&gt;- Higher grades provide better effect values.
	/// </summary>
	[JsonPropertyName("core_option_grade")]
	public double? CoreOptionGrade { get; set; }

	[JsonPropertyName("required_core_item")]
	public RequiredCoreItem RequiredCoreItem { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}