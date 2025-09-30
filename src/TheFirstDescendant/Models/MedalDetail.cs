using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class MedalDetail
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Medal grade
	/// </summary>
	[JsonPropertyName("medal_level")]
	public double MedalLevel { get; set; }

	/// <summary>
	///     Medal name
	/// </summary>
	[JsonPropertyName("medal_name")]
	public string MedalName { get; set; }

	/// <summary>
	///     Medal grade (Refer to /meta/tier API)
	/// </summary>
	[JsonPropertyName("medal_tier_id")]
	public string MedalTierId { get; set; }

	/// <summary>
	///     Medal image path
	/// </summary>
	[JsonPropertyName("medal_image_url")]
	public string MedalImageUrl { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}