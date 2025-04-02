using Newtonsoft.Json;

namespace NutriCenter.Aplication.Utilities;

public class TimeSpanConverter : JsonConverter<TimeSpan>
{
	public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		return TimeSpan.Parse(reader.Value.ToString());
	}

	public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
	{
		writer.WriteValue(value.ToString(@"hh\:mm\:ss"));
	}
}
