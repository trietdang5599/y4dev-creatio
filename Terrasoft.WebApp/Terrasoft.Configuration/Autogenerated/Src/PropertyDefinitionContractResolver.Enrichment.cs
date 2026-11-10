namespace Terrasoft.Configuration.Enrichment
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;
	using System.Reflection;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion;
	
	/// <summary>
	/// Custom contract resolver for <see cref="PropertyDefinition"/> to handle specific serialization requirements.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class PropertyDefinitionContractResolver : DefaultContractResolver
	{
		/// <inheritdoc />
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
			var prop = base.CreateProperty(member, memberSerialization);
			if (prop.DeclaringType == typeof(PropertyDefinition)
				&& prop.UnderlyingName == nameof(PropertyDefinition.TypeList)) {
				prop.Converter = new TypeStringOrArrayConverter();
			}
			return prop;
		}

		/// <inheritdoc />
		protected override JsonContract CreateContract(Type objectType) {
			var contract = base.CreateContract(objectType);
			if (objectType == typeof(PropertyDefinition)) {
				contract.Converter = new PropertyDefinitionJsonConverter();
			}
			return contract;
		}
	}
}

