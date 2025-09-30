using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Fellow
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Identifier for the fellow
	/// </summary>
	[JsonPropertyName("fellow_id")]
	public string FellowId { get; set; }

	/// <summary>
	///     Fellow name
	/// </summary>
	[JsonPropertyName("fellow_name")]
	public string FellowName { get; set; }

	/// <summary>
	///     Fellow level (refer to /meta/tier API)
	/// </summary>
	[JsonPropertyName("fellow_tier_id")]
	public string FellowTierId { get; set; }

	/// <summary>
	///     Details by fellow level
	/// </summary>
	[JsonPropertyName("fellow_detail")]
	public ICollection<FellowDetail> FellowDetail { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}