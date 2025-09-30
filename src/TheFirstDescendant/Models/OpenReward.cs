using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class OpenReward
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Reward type (Default, Upgrade)
	/// </summary>
	[JsonPropertyName("reward_type")]
	public string RewardType { get; set; }

	/// <summary>
	///     Identifier of the Shape Stabilizer required for upgrade (refer to /meta/consumable-material API)
	/// </summary>
	[JsonPropertyName("required_stabilizer")]
	public string RequiredStabilizer { get; set; }

	/// <summary>
	///     Information about items from Amorphous Material open rewards
	/// </summary>
	[JsonPropertyName("reward_item")]
	public ICollection<RewardItem> RewardItem { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}