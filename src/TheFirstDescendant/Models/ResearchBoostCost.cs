using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class ResearchBoostCost
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Currency type
	/// </summary>
	[JsonPropertyName("currency_type")]
	public string CurrencyType { get; set; }

	/// <summary>
	///     Currency amount
	/// </summary>
	[JsonPropertyName("currency_value")]
	public double CurrencyValue { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}