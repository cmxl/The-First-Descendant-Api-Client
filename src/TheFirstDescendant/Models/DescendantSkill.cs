using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class DescendantSkill
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Skill type (active/passive)
	/// </summary>
	[JsonPropertyName("skill_type")]
	public string SkillType { get; set; }

	/// <summary>
	///     Skill name
	/// </summary>
	[JsonPropertyName("skill_name")]
	public string SkillName { get; set; }

	/// <summary>
	///     Skill type
	/// </summary>
	[JsonPropertyName("element_type")]
	public string ElementType { get; set; }

	/// <summary>
	///     Arche type
	/// </summary>
	[JsonPropertyName("arche_type")]
	public string ArcheType { get; set; }

	/// <summary>
	///     Skill icon image path
	/// </summary>
	[JsonPropertyName("skill_image_url")]
	public string SkillImageUrl { get; set; }

	/// <summary>
	///     Skill description
	/// </summary>
	[JsonPropertyName("skill_description")]
	public string SkillDescription { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}