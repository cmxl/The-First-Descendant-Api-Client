using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class CoreOption
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     core type option identifier
	/// </summary>
	[JsonPropertyName("core_option_id")]
	public string CoreOptionId { get; set; }

	/// <summary>
	///     Detailed information on core type options
	/// </summary>
	[JsonPropertyName("detail")]
	public ICollection<Detail> Detail { get; set; }

	/// <summary>
	///     Item options
	/// </summary>
	[JsonPropertyName("available_item_option")]
	public ICollection<AvailableItemOption> AvailableItemOption { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}