using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Reward
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Reward rotation
	/// </summary>
	[JsonPropertyName("rotation")]
	public double Rotation { get; set; }

	/// <summary>
	///     Reward type
	/// </summary>
	[JsonPropertyName("reward_type")]
	public string RewardType { get; set; }

	/// <summary>
	///     Skill type
	/// </summary>
	[JsonPropertyName("reactor_element_type")]
	public string ReactorElementType { get; set; }

	/// <summary>
	///     Weapon rounds type
	/// </summary>
	[JsonPropertyName("weapon_rounds_type")]
	public string WeaponRoundsType { get; set; }

	/// <summary>
	///     Arche type
	/// </summary>
	[JsonPropertyName("arche_type")]
	public string ArcheType { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}