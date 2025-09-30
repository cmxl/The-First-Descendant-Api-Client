using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ArcheTuningBoard
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Arche board identifier
	/// </summary>
	[JsonPropertyName("arche_tuning_board_id")]
	public string ArcheTuningBoardId { get; set; }

	/// <summary>
	///     Row size
	/// </summary>
	[JsonPropertyName("row_size")]
	public double RowSize { get; set; }

	/// <summary>
	///     Column size
	/// </summary>
	[JsonPropertyName("column_size")]
	public double ColumnSize { get; set; }

	[JsonPropertyName("node")] public ICollection<Node> Node { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}