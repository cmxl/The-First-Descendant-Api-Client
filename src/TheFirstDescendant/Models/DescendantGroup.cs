using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class DescendantGroup
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Descendant group identifier
	/// </summary>
	[JsonPropertyName("descendant_group_id")]
	public string DescendantGroupId { get; set; }

	/// <summary>
	///     Descendant group name
	/// </summary>
	[JsonPropertyName("descendant_group_name")]
	public string DescendantGroupName { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}