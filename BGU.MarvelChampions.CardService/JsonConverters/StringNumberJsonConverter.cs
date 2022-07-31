using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BGU.MarvelChampions.CardService.JsonConverters;

public class StringNumberJsonConverter : JsonConverter<string>
{
	public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value);
	}

	public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
        switch (reader.TokenType)
        {
            case JsonTokenType.Number: return Convert.ToString(reader.GetInt32());
            case JsonTokenType.String: return reader.GetString();
            default: throw new InvalidOperationException($"Cannot retrieve string value for type '{reader.TokenType}'.");
        }
	}
}
