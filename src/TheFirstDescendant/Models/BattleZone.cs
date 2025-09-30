using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class BattleZone
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Battlefield identifier
	/// </summary>
	[JsonPropertyName("battle_zone_id")]
	public string BattleZoneId { get; set; }

	/// <summary>
	///     Battlefield name
	/// </summary>
	[JsonPropertyName("battle_zone_name")]
	public string BattleZoneName { get; set; }

	/// <summary>
	///     Reward rotation information
	/// </summary>
	[JsonPropertyName("reward")]
	public ICollection<Reward> Reward { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}