using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class DifficultyLevelReward
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Map identifier
	/// </summary>
	[JsonPropertyName("map_id")]
	public string MapId { get; set; }

	/// <summary>
	///     Map name
	/// </summary>
	[JsonPropertyName("map_name")]
	public string MapName { get; set; }

	/// <summary>
	///     Battlefield information
	/// </summary>
	[JsonPropertyName("battle_zone")]
	public ICollection<BattleZone> BattleZone { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}