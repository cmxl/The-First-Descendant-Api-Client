using System.Runtime.Serialization;

namespace TheFirstDescendant.Models;

public enum LanguageCode
{
	[EnumMember(Value = @"ko")] Ko = 0,

	[EnumMember(Value = @"en")] En = 1,

	[EnumMember(Value = @"de")] De = 2,

	[EnumMember(Value = @"fr")] Fr = 3,

	[EnumMember(Value = @"ja")] Ja = 4,

	[EnumMember(Value = @"zh-CN")] ZhCn = 5,

	[EnumMember(Value = @"zh-TW")] ZhTw = 6,

	[EnumMember(Value = @"it")] It = 7,

	[EnumMember(Value = @"pl")] Pl = 8,

	[EnumMember(Value = @"pt")] Pt = 9,

	[EnumMember(Value = @"ru")] Ru = 10,

	[EnumMember(Value = @"es")] Es = 11
}