using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ReactorSkillPower
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Reactor level
	/// </summary>
	[JsonPropertyName("level")]
	public double Level { get; set; }

	/// <summary>
	///     Skill Power
	/// </summary>
	[JsonPropertyName("skill_atk_power")]
	public double SkillAtkPower { get; set; }

	/// <summary>
	///     Sub Attack Power
	/// </summary>
	[JsonPropertyName("sub_skill_atk_power")]
	public double SubSkillAtkPower { get; set; }

	/// <summary>
	///     Skill Power Boost Ratio information
	/// </summary>
	[JsonPropertyName("skill_power_coefficient")]
	public ICollection<SkillPowerCoefficient> SkillPowerCoefficient { get; set; }

	/// <summary>
	///     Enchantment effect by level information
	/// </summary>
	[JsonPropertyName("enchant_effect")]
	public ICollection<EnchantEffect> EnchantEffect { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}