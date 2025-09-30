using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ExternalComponent
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     External component identifier
	/// </summary>
	[JsonPropertyName("external_component_id")]
	public string ExternalComponentId { get; set; }

	/// <summary>
	///     External component name
	/// </summary>
	[JsonPropertyName("external_component_name")]
	public string ExternalComponentName { get; set; }

	/// <summary>
	///     External component image path
	/// </summary>
	[JsonPropertyName("image_url")]
	public string ImageUrl { get; set; }

	/// <summary>
	///     External component equipment part
	/// </summary>
	[JsonPropertyName("external_component_equipment_type")]
	public string ExternalComponentEquipmentType { get; set; }

	/// <summary>
	///     External components tier  (Refer to /meta/tier API)
	/// </summary>
	[JsonPropertyName("external_component_tier_id")]
	public string ExternalComponentTierId { get; set; }

	/// <summary>
	///     List of unlockable core slots (Refer to the /meta/core-slot API)
	/// </summary>
	[JsonPropertyName("available_core_slot")]
	public ICollection<string> AvailableCoreSlot { get; set; }

	/// <summary>
	///     External component effect by level information
	/// </summary>
	[JsonPropertyName("base_stat")]
	public ICollection<ExternalComponentBaseStat> BaseStat { get; set; }

	/// <summary>
	///     External component set option information
	/// </summary>
	[JsonPropertyName("set_option_detail")]
	public ICollection<SetOptionDetail> SetOptionDetail { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}