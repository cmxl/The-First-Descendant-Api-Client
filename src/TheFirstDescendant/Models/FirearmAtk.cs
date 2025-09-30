using System.Text.Json.Serialization;

namespace TheFirstDescendant.Models;

public class FirearmAtk
{
	private IDictionary<string, object>? _additionalProperties;

	/// <summary>
	///     Firearm level
	/// </summary>
	[JsonPropertyName("level")]
	public double Level { get; set; }

	/// <summary>
	///     Firearm ATK
	/// </summary>
	[JsonPropertyName("firearm")]
	public ICollection<Firearm> Firearm { get; set; }

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get => _additionalProperties ??= new Dictionary<string, object>();
		set => _additionalProperties = value;
	}
}