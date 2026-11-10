 namespace Terrasoft.Configuration.GenAI
{
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Core.Applications.Abstractions.Creation;
	using Terrasoft.Core.Factories;
	using Terrasoft.Enrichment.Interfaces.GenAI;
	using DataValueType=Terrasoft.Nui.ServiceModel.DataContract.DataValueType;

	public interface IGeneratedEntityConverter
	{
		List<GenAIEntity> ToGenAIEntities(List<GeneratedEntity> sections);
	}

	[DefaultBinding(typeof(IGeneratedEntityConverter))]
	public class GeneratedEntityConverter : IGeneratedEntityConverter
	{
		private GenAIEntityColumn CreateGenAIEntityColumn(GeneratedEntityColumn generatedEntityColumn) {
			var genAIEntityColumn = new GenAIEntityColumn {
				Name = generatedEntityColumn.Name,
				Caption = generatedEntityColumn.Caption,
				IsPrimaryDisplayColumn = generatedEntityColumn.IsPrimaryDisplayColumn,
				ReferenceEntityName = generatedEntityColumn.ReferenceSchemaName
			};
			SetGenAIEntityColumnType(genAIEntityColumn, generatedEntityColumn.Type);
			return genAIEntityColumn;
		}

		private static void SetGenAIEntityColumnType(GenAIEntityColumn genAIEntityColumn, int type) {
			GenAIEntityColumnType genAIEntityColumnType;
			var dataValueType = (DataValueType)type;
			switch (dataValueType) {
				case DataValueType.Boolean:
					genAIEntityColumnType = GenAIEntityColumnType.Bool;
					break;
				case DataValueType.DateTime:
					genAIEntityColumnType = GenAIEntityColumnType.DateTime;
					break;
				case DataValueType.Date:
					genAIEntityColumnType = GenAIEntityColumnType.Date;
					break;
				case DataValueType.Time:
					genAIEntityColumnType = GenAIEntityColumnType.Time;
					break;
				case DataValueType.Float:
					genAIEntityColumnType = GenAIEntityColumnType.Float;
					break;
				case DataValueType.Integer:
					genAIEntityColumnType = GenAIEntityColumnType.Integer;
					break;
				case DataValueType.Lookup:
					genAIEntityColumnType = GenAIEntityColumnType.Lookup;
					break;
				case DataValueType.EmailText:
					genAIEntityColumnType = GenAIEntityColumnType.String;
					genAIEntityColumn.IsEmail = true;
					break;
				case DataValueType.PhoneText:
					genAIEntityColumnType = GenAIEntityColumnType.String;
					genAIEntityColumn.IsPhone = true;
					break;
				case DataValueType.MediumText:
				default:
					genAIEntityColumnType = GenAIEntityColumnType.String;
					break;
			}
			genAIEntityColumn.Type = genAIEntityColumnType;
		}

		private GenAIEntity CreateGenAIEntity(GeneratedEntity generatedEntity, bool isMain = false) {
			var genAIEntity = new GenAIEntity {
				Name = generatedEntity.EntitySchemaName,
				Caption = generatedEntity.Caption,
				IsMain = isMain
			};
			foreach (GeneratedEntityColumn generatedEntityColumn in generatedEntity.Columns) {
				GenAIEntityColumn genAIEntityColumn = CreateGenAIEntityColumn(generatedEntityColumn);
				genAIEntity.Columns.Add(genAIEntityColumn);
			}
			return genAIEntity;
		}
		
		public List<GenAIEntity> ToGenAIEntities(List<GeneratedEntity> sections) {
			var result = new List<GenAIEntity>();
			foreach (GeneratedEntity section in sections) {
				result.Add(CreateGenAIEntity(section));
				result.AddRange(section.Lookups.Select(lookup => CreateGenAIEntity(lookup)));
				result.AddRange(section.Details.Select(detail => CreateGenAIEntity(detail)));
			}
			return result;
		}
	}
	
}
