using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Medal
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Medal identifier
	/// </summary>
	[JsonPropertyName("medal_id")]
	public string MedalId { get; set; }

	/// <summary>
	///     Description by medal grade
	/// </summary>
	[JsonPropertyName("medal_detail")]
	public ICollection<MedalDetail> MedalDetail { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}