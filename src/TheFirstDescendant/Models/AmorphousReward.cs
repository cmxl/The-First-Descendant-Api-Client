using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class AmorphousReward
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Identifier for Amorphous Material open reward
	/// </summary>
	[JsonPropertyName("amorphous_reward_id")]
	public string AmorphousRewardId { get; set; }

	/// <summary>
	///     Information about Amorphous Material open rewards
	/// </summary>
	[JsonPropertyName("open_reward")]
	public ICollection<OpenReward> OpenReward { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}