using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ResearchResult
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Metadata type of the research result item
	/// </summary>
	[JsonPropertyName("meta_type")]
	public string MetaType { get; set; }

	/// <summary>
	///     Identifier of the research result item
	/// </summary>
	[JsonPropertyName("meta_id")]
	public string MetaId { get; set; }

	/// <summary>
	///     Quantity of the research result item
	/// </summary>
	[JsonPropertyName("result_count")]
	public double ResultCount { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}