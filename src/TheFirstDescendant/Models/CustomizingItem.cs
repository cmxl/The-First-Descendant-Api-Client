using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class CustomizingItem
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Customization item identifier
	/// </summary>
	[JsonPropertyName("customizing_item_id")]
	public string CustomizingItemId { get; set; }

	/// <summary>
	///     Customization item name
	/// </summary>
	[JsonPropertyName("customizing_item_name")]
	public string CustomizingItemName { get; set; }

	/// <summary>
	///     Customization item type
	/// </summary>
	[JsonPropertyName("customizing_item_type")]
	public string CustomizingItemType { get; set; }

	/// <summary>
	///     Customization item tier (Refer to /meta/tier API)
	/// </summary>
	[JsonPropertyName("customizing_item_tier_id")]
	public string CustomizingItemTierId { get; set; }

	/// <summary>
	///     Customization item description
	/// </summary>
	[JsonPropertyName("customizing_item_description")]
	public string CustomizingItemDescription { get; set; }

	/// <summary>
	///     Customization item image path
	/// </summary>
	[JsonPropertyName("customizing_item_image_url")]
	public string CustomizingItemImageUrl { get; set; }

	/// <summary>
	///     Evolution stage information of the customization item
	/// </summary>
	[JsonPropertyName("customizing_item_evolution_stage")]
	public ICollection<CustomizingItemEvolutionStage> CustomizingItemEvolutionStage { get; set; }

	/// <summary>
	///     Applicable descendant list (Refer to /meta/descendant API)
	/// </summary>
	[JsonPropertyName("available_descendant")]
	public ICollection<string> AvailableDescendant { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}