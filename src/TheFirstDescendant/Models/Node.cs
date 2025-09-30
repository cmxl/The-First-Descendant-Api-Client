using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class Node
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Node identifier (Refer to /meta/arche-tuning-node API)
	/// </summary>
	[JsonPropertyName("node_id")]
	public string NodeId { get; set; }

	/// <summary>
	///     Row coordinates of the node
	/// </summary>
	[JsonPropertyName("position_row")]
	public double PositionRow { get; set; }

	/// <summary>
	///     Column coordinates of the node
	/// </summary>
	[JsonPropertyName("position_column")]
	public double PositionColumn { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}