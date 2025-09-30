using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Research
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Research identifier
	/// </summary>
	[JsonPropertyName("research_id")]
	public string ResearchId { get; set; }

	/// <summary>
	///     Research name
	/// </summary>
	[JsonPropertyName("research_name")]
	public string ResearchName { get; set; }

	/// <summary>
	///     Repeatable
	/// </summary>
	[JsonPropertyName("repeatable_research")]
	public bool RepeatableResearch { get; set; }

	/// <summary>
	///     Research type
	/// </summary>
	[JsonPropertyName("research_type")]
	public string ResearchType { get; set; }

	/// <summary>
	///     Research time (seconds)
	/// </summary>
	[JsonPropertyName("research_time")]
	public double ResearchTime { get; set; }

	/// <summary>
	///     Research cost
	/// </summary>
	[JsonPropertyName("research_cost")]
	public ICollection<ResearchCost> ResearchCost { get; set; }

	/// <summary>
	///     Boost Research Cost
	/// </summary>
	[JsonPropertyName("research_boost_cost")]
	public ICollection<ResearchBoostCost> ResearchBoostCost { get; set; }

	/// <summary>
	///     Research result
	/// </summary>
	[JsonPropertyName("research_result")]
	public ICollection<ResearchResult> ResearchResult { get; set; }

	/// <summary>
	///     Research materials
	/// </summary>
	[JsonPropertyName("research_material")]
	public ICollection<ResearchMaterial> ResearchMaterial { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}