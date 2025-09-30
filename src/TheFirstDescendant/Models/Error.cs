using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Error
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Error name
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; }

	/// <summary>
	///     Error message
	/// </summary>
	[JsonPropertyName("message")]
	public string Message { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}