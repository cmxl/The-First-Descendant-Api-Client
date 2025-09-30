using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ArcheTuningBoardGroup
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Arche tuning board group identifier
	/// </summary>
	[JsonPropertyName("arche_tuning_board_group_id")]
	public string ArcheTuningBoardGroupId { get; set; }

	/// <summary>
	///     Descendant group identifier (Refer to meta/descendant-group API)
	/// </summary>
	[JsonPropertyName("descendant_group_id")]
	public string DescendantGroupId { get; set; }

	/// <summary>
	///     Arche board identifier (Refer to /meta/arche-tuning-board API)
	/// </summary>
	[JsonPropertyName("arche_tuning_board_id")]
	public string ArcheTuningBoardId { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}