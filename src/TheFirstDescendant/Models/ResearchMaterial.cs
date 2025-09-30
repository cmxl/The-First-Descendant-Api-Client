using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ResearchMaterial
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Metadata type of the research material item
	/// </summary>
	[JsonPropertyName("meta_type")]
	public string MetaType { get; set; }

	/// <summary>
	///     Identifier of the research material item
	/// </summary>
	[JsonPropertyName("meta_id")]
	public string MetaId { get; set; }

	/// <summary>
	///     Quantity of the research material item
	/// </summary>
	[JsonPropertyName("material_count")]
	public double MaterialCount { get; set; }

	/// <summary>
	///     Research identifier of the research material item (refer to /meta/research API)
	/// </summary>
	[JsonPropertyName("research_id")]
	public ICollection<string> ResearchId { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}