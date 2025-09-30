using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class CoreType
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Core type identifier
	/// </summary>
	[JsonPropertyName("core_type_id")]
	public string TypeId { get; set; }

	/// <summary>
	///     Core type
	/// </summary>
	[JsonPropertyName("core_type")]
	public string Type { get; set; }

	/// <summary>
	///     core type options
	/// </summary>
	[JsonPropertyName("core_option")]
	public ICollection<CoreOption> CoreOption { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}