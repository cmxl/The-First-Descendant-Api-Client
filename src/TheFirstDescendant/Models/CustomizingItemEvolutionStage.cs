using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class CustomizingItemEvolutionStage
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Evolution stage of the customization item
	/// </summary>
	[JsonPropertyName("stage")]
	public double Stage { get; set; }

	/// <summary>
	///     Image path by customization item evolution stage
	/// </summary>
	[JsonPropertyName("customizing_item_image_url")]
	public string CustomizingItemImageUrl { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}