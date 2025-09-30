using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class SetOptionDetail
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     External component set option type
	/// </summary>
	[JsonPropertyName("set_option")]
	public string SetOption { get; set; }

	/// <summary>
	///     Number of external component sets
	/// </summary>
	[JsonPropertyName("set_count")]
	public double SetCount { get; set; }

	/// <summary>
	///     External component set option set effect
	/// </summary>
	[JsonPropertyName("set_option_effect")]
	public string SetOptionEffect { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}