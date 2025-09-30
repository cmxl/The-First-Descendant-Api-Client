using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class AcquisitionDetail
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Identifier of the acquisition source
	/// </summary>
	[JsonPropertyName("acquisition_detail_id")]
	public string AcquisitionDetailId { get; set; }

	/// <summary>
	///     Acquisition source name
	/// </summary>
	[JsonPropertyName("acquisition_detail_name")]
	public string AcquisitionDetailName { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}