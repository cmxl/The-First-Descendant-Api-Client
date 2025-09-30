using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Title
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Title identifier
	/// </summary>
	[JsonPropertyName("title_id")]
	public string TitleId { get; set; }

	/// <summary>
	///     Title name
	/// </summary>
	[JsonPropertyName("title_name")]
	public string TitleName { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}