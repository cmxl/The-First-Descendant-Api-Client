using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Weapon
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Weapon name
	/// </summary>
	[JsonPropertyName("weapon_name")]
	public string WeaponName { get; set; }

	/// <summary>
	///     Weapon identifier
	/// </summary>
	[JsonPropertyName("weapon_id")]
	public string WeaponId { get; set; }

	/// <summary>
	///     Weapon image path
	/// </summary>
	[JsonPropertyName("image_url")]
	public string ImageUrl { get; set; }

	/// <summary>
	///     Weapon type
	/// </summary>
	[JsonPropertyName("weapon_type")]
	public string WeaponType { get; set; }

	/// <summary>
	///     Weapon tier (Refer to /meta/tier API)
	/// </summary>
	[JsonPropertyName("weapon_tier_id")]
	public string WeaponTierId { get; set; }

	/// <summary>
	///     Weapon rounds type
	/// </summary>
	[JsonPropertyName("weapon_rounds_type")]
	public string WeaponRoundsType { get; set; }

	/// <summary>
	///     List of unlockable core slots (Refer to the /meta/core-slot API)
	/// </summary>
	[JsonPropertyName("available_core_slot")]
	public ICollection<string> AvailableCoreSlot { get; set; }

	/// <summary>
	///     Weapon base spec information
	/// </summary>
	[JsonPropertyName("base_stat")]
	public ICollection<WeaponBaseStat> BaseStat { get; set; }

	/// <summary>
	///     Firearm attack power by level information
	/// </summary>
	[JsonPropertyName("firearm_atk")]
	public ICollection<FirearmAtk> FirearmAtk { get; set; }

	/// <summary>
	///     Unique Ability name
	/// </summary>
	[JsonPropertyName("weapon_perk_ability_name")]
	public string? WeaponPerkAbilityName { get; set; }

	/// <summary>
	///     Unique Ability description
	/// </summary>
	[JsonPropertyName("weapon_perk_ability_description")]
	public string? WeaponPerkAbilityDescription { get; set; }

	/// <summary>
	///     Unique Ability image path
	/// </summary>
	[JsonPropertyName("weapon_perk_ability_image_url")]
	public string? WeaponPerkAbilityImageUrl { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}