using System.Text.Json.Serialization;
using System.Text.Json;


namespace Sigma.Services.Common
{
    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token.");
            }

            int hour = 0;
            int minute = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName)
                    {
                        case "hour":
                            hour = reader.GetInt32();
                            break;
                        case "minute":
                            minute = reader.GetInt32();
                            break;
                        default:
                            throw new JsonException($"Unexpected property: {propertyName}");
                    }
                }
            }

            return new TimeOnly(hour, minute);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("hour", value.Hour);
            writer.WriteNumber("minute", value.Minute);
            writer.WriteEndObject();
        }
    }


}
