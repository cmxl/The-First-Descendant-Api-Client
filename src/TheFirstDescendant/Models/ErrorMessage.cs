using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ErrorMessage
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonPropertyName("error")] public Error Error { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}