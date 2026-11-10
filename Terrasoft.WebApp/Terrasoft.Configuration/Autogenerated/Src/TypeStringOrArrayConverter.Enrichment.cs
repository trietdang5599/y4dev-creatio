namespace Terrasoft.Configuration.Enrichment
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;

	/// <summary>
	/// Handles deserialization/serialization of a property that can be a string or string array.
	/// <example>Example JSON:
	/// <code>
	/// {
	///   "type": "exampleType"
	/// // or
	///   "type": ["type1", "type2"]
	/// }
	/// </code>
	/// Will be deserialized to:
	/// <code>
	/// new [] { "exampleType" }
	/// // or
	/// new [] { "type1", "type2" }
	/// </code>
	/// </example>
	/// </summary>
	public class TypeStringOrArrayConverter : JsonConverter<IList<string>>
	{

		/// <summary>
		/// Reads the JSON representation of the value.
		/// </summary>
		public override IList<string> ReadJson(JsonReader reader, Type objectType, IList<string> existingValue,
				bool hasExistingValue, JsonSerializer serializer) {
			switch (reader.TokenType) {
				case JsonToken.String:
					return new List<string> { (string)reader.Value };
				case JsonToken.StartArray: {
					JArray array = JArray.Load(reader);
					return array.ToObject<List<string>>();
				}
				case JsonToken.Null:
					return null;
				default:
					throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing type property.");
			}
		}

		/// <summary>
		/// Writes the JSON representation of the value.
		/// </summary>
		public override void WriteJson(JsonWriter writer, IList<string> value, JsonSerializer serializer) {
			switch (value) {
				case null:
					writer.WriteNull();
					break;
				default: {
					if (value.Count == 1) {
						writer.WriteValue(value[0]);
					} else {
						writer.WriteStartArray();
						foreach (var item in value) {
							writer.WriteValue(item);
						}
						writer.WriteEndArray();
					}
					break;
				}
			}
		}
	}
}
