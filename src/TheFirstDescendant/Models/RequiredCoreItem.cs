using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class RequiredCoreItem
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Required core item type
	/// </summary>
	[JsonPropertyName("meta_type")]
	public string MetaType { get; set; }

	/// <summary>
	///     Required core item identifier
	/// </summary>
	[JsonPropertyName("meta_id")]
	public string MetaId { get; set; }

	/// <summary>
	///     Required core item quantity
	/// </summary>
	[JsonPropertyName("count")]
	public double Count { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}