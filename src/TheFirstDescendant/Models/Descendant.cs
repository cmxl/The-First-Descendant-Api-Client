using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Descendant
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Descendant identifier
	/// </summary>
	[JsonPropertyName("descendant_id")]
	public string DescendantId { get; set; }

	/// <summary>
	///     Descendant name
	/// </summary>
	[JsonPropertyName("descendant_name")]
	public string DescendantName { get; set; }

	/// <summary>
	///     Descendant group identifier (Refer to /meta/descendant-group API)
	/// </summary>
	[JsonPropertyName("descendant_group_id")]
	public string DescendantGroupId { get; set; }

	/// <summary>
	///     Descendant image path
	/// </summary>
	[JsonPropertyName("descendant_image_url")]
	public string DescendantImageUrl { get; set; }

	/// <summary>
	///     Descendant stat information
	/// </summary>
	[JsonPropertyName("descendant_stat")]
	public ICollection<DescendantStat> DescendantStat { get; set; }

	/// <summary>
	///     Descendant skill information
	/// </summary>
	[JsonPropertyName("descendant_skill")]
	public ICollection<DescendantSkill> DescendantSkill { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}