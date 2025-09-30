using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class VoidBattle
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Void Intercept Battle identifier
	/// </summary>
	[JsonPropertyName("void_battle_id")]
	public string VoidBattleId { get; set; }

	/// <summary>
	///     Void Intercept Battle name
	/// </summary>
	[JsonPropertyName("void_battle_name")]
	public string VoidBattleName { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}