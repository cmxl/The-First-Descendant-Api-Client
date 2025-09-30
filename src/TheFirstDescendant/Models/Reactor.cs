using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Reactor
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Reactor identifier
	/// </summary>
	[JsonPropertyName("reactor_id")]
	public string ReactorId { get; set; }

	/// <summary>
	///     Reactor name
	/// </summary>
	[JsonPropertyName("reactor_name")]
	public string ReactorName { get; set; }

	/// <summary>
	///     Reactor image path
	/// </summary>
	[JsonPropertyName("image_url")]
	public string ImageUrl { get; set; }

	/// <summary>
	///     Reactor tier (Refer to /meta/tier API)
	/// </summary>
	[JsonPropertyName("reactor_tier_id")]
	public string ReactorTierId { get; set; }

	/// <summary>
	///     Skill Power by level information
	/// </summary>
	[JsonPropertyName("reactor_skill_power")]
	public ICollection<ReactorSkillPower> ReactorSkillPower { get; set; }

	/// <summary>
	///     Optimization Condition
	/// </summary>
	[JsonPropertyName("optimized_condition_type")]
	public string OptimizedConditionType { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}