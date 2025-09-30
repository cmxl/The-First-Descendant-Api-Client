using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Module
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Module name
	/// </summary>
	[JsonPropertyName("module_name")]
	public string ModuleName { get; set; }

	/// <summary>
	///     Module identifier
	/// </summary>
	[JsonPropertyName("module_id")]
	public string ModuleId { get; set; }

	/// <summary>
	///     Module image path
	/// </summary>
	[JsonPropertyName("image_url")]
	public string? ImageUrl { get; set; }

	/// <summary>
	///     Module type
	/// </summary>
	[JsonPropertyName("module_type")]
	public string? ModuleType { get; set; }

	/// <summary>
	///     Module tier (Refer to /meta/tier API)
	/// </summary>
	[JsonPropertyName("module_tier_id")]
	public string ModuleTierId { get; set; }

	/// <summary>
	///     Module slot socket type
	/// </summary>
	[JsonPropertyName("module_socket_type")]
	public string ModuleSocketType { get; set; }

	/// <summary>
	///     Module class
	/// </summary>
	[JsonPropertyName("module_class")]
	public string ModuleClass { get; set; }

	/// <summary>
	///     List of weapon types that can equip modules (refer to /meta/weapon-type API)
	/// </summary>
	[JsonPropertyName("available_weapon_type")]
	public ICollection<string> AvailableWeaponType { get; set; }

	/// <summary>
	///     List of descendant identifiers that can equip modules (refer to /meta/descendant API)
	/// </summary>
	[JsonPropertyName("available_descendant_id")]
	public ICollection<string> AvailableDescendantId { get; set; }

	/// <summary>
	///     List of slot types that can equip modules
	/// </summary>
	[JsonPropertyName("available_module_slot_type")]
	public ICollection<string> AvailableModuleSlotType { get; set; }

	/// <summary>
	///     Module attribute information
	/// </summary>
	[JsonPropertyName("module_stat")]
	public ICollection<ModuleStat> ModuleStat { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}