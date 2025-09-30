using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class SkillPowerCoefficient
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Skill Power Boost Ratio identifier (Refer to /meta/stat API)
	/// </summary>
	[JsonPropertyName("coefficient_stat_id")]
	public string CoefficientStatId { get; set; }

	/// <summary>
	///     Skill Power Boost Ratio value
	/// </summary>
	[JsonPropertyName("coefficient_stat_value")]
	public double CoefficientStatValue { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}