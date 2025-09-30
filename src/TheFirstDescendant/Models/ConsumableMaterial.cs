using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ConsumableMaterial
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Consumable Item identifier
	/// </summary>
	[JsonPropertyName("consumable_material_id")]
	public string ConsumableMaterialId { get; set; }

	/// <summary>
	///     Consumable Item image path
	/// </summary>
	[JsonPropertyName("image_url")]
	public string ImageUrl { get; set; }

	/// <summary>
	///     Consumable Item name
	/// </summary>
	[JsonPropertyName("consumable_material_name")]
	public string ConsumableMaterialName { get; set; }

	/// <summary>
	///     Required Mastery Rank
	/// </summary>
	[JsonPropertyName("required_mastery_rank_level")]
	public double? RequiredMasteryRankLevel { get; set; }

	/// <summary>
	///     Material type
	/// </summary>
	[JsonPropertyName("material_type")]
	public string MaterialType { get; set; }

	/// <summary>
	///     Acquisition source (refer to /meta/acquisition-detail API)
	/// </summary>
	[JsonPropertyName("acquisition_detail")]
	public ICollection<string> AcquisitionDetail { get; set; }

	/// <summary>
	///     Amorphous Material open reward (refer to /meta/amorphous-reward API)
	/// </summary>
	[JsonPropertyName("amorphous_reward")]
	public ICollection<string> AmorphousReward { get; set; }

	/// <summary>
	///     Amorphous Material opening location (refer to /meta/amorphous-open-condition-description API)
	/// </summary>
	[JsonPropertyName("amorphous_open_condition")]
	public ICollection<string> AmorphousOpenCondition { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}