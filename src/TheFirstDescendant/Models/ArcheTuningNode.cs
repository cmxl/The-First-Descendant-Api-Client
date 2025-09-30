using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ArcheTuningNode
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Node identifier
	/// </summary>
	[JsonPropertyName("node_id")]
	public string NodeId { get; set; }

	/// <summary>
	///     Node name
	/// </summary>
	[JsonPropertyName("node_name")]
	public string NodeName { get; set; }

	/// <summary>
	///     Node image URL
	/// </summary>
	[JsonPropertyName("node_image_url")]
	public string NodeImageUrl { get; set; }

	/// <summary>
	///     Node type
	/// </summary>
	[JsonPropertyName("node_type")]
	public string NodeType { get; set; }

	/// <summary>
	///     Node tier identifier (Refer to /meta/tier API)
	/// </summary>
	[JsonPropertyName("tier_id")]
	public string TierId { get; set; }

	/// <summary>
	///     Required points
	/// </summary>
	[JsonPropertyName("required_tuning_point")]
	public double RequiredTuningPoint { get; set; }

	[JsonPropertyName("node_effect")] public ICollection<NodeEffect> NodeEffect { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}