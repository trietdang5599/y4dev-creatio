namespace Terrasoft.Configuration.Enrichment
{
	using System;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion;
	
	/// <summary>
	/// Custom JsonConverter for PropertyDefinition to handle $ref-only objects.
	/// </summary>
	public class PropertyDefinitionJsonConverter : JsonConverter<PropertyDefinition>
	{

		#region Properties: Public

		/// <inheritdoc />
		public override bool CanWrite => false;

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override PropertyDefinition ReadJson(JsonReader reader, Type objectType,
				PropertyDefinition existingValue, bool hasExistingValue, JsonSerializer serializer) {
			if (reader.TokenType == JsonToken.Null) {
				return null;
			}
			var jo = JObject.Load(reader);
			if (jo.TryGetValue("$ref", out var refToken) && jo.Count == 1) {
				return new PropertyDefinition { Ref = refToken.ToString() };
			}
			var result = new PropertyDefinition();
			serializer.Populate(jo.CreateReader(), result);
			return result;
		}

		/// <inheritdoc />
		public override void WriteJson(JsonWriter writer, PropertyDefinition value, JsonSerializer serializer) {
			serializer.Serialize(writer, value);
		}

		#endregion

	}
}

