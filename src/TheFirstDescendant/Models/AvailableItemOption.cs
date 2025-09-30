using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class AvailableItemOption
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Option name
	/// </summary>
	[JsonPropertyName("item_option")]
	public string ItemOption { get; set; }

	/// <summary>
	///     Option category
	/// </summary>
	[JsonPropertyName("option_type")]
	public string OptionType { get; set; }

	/// <summary>
	///     Option grade&lt;br&gt;- Higher grades provide better effect values.
	/// </summary>
	[JsonPropertyName("option_grade")]
	public string OptionGrade { get; set; }

	[JsonPropertyName("option_effect")] public OptionEffect OptionEffect { get; set; }

	/// <summary>
	///     Probability of the option appearing
	/// </summary>
	[JsonPropertyName("rate")]
	public double Rate { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}