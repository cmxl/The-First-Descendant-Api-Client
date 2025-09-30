using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class CoreSlot
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Core slot identifier
	/// </summary>
	[JsonPropertyName("core_slot_id")]
	public string CoreSlotId { get; set; }

	/// <summary>
	///     List of weapons that can unlock this core slot (refer to /meta/weapon API)
	/// </summary>
	[JsonPropertyName("available_weapon_id")]
	public ICollection<string> AvailableWeaponId { get; set; }

	/// <summary>
	///     List of external component that can unlock this core slot (refer to /meta/external-component API)
	/// </summary>
	[JsonPropertyName("available_external_component_id")]
	public ICollection<string> AvailableExternalComponentId { get; set; }

	/// <summary>
	///     List of specified core types (refer to /meta/core-type API)
	/// </summary>
	[JsonPropertyName("available_core_type")]
	public ICollection<string> AvailableCoreType { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}