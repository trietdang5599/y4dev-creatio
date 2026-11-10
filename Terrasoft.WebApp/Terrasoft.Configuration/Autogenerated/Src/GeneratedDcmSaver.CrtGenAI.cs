namespace Terrasoft.Configuration.GenAI
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions.Creation;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using DataValueType = Terrasoft.Nui.ServiceModel.DataContract.DataValueType;

	public interface IGeneratedDcmSaver
	{
		GeneratedDcm CreateGeneratedDcm(List<string> stagesCaptions, GeneratedEntity generatedEntity);
		void SetStageColumnDefaultValue(GeneratedDcm generatedDcm, GeneratedEntity generatedEntity);
		void SaveDcmSchema(GeneratedDcm generatedDcm, GeneratedEntity generatedEntity, Guid packageUId);
		IEnumerable<(string SchemaName, IEnumerable<Guid> RecordIds)> SaveDcmSettings(GeneratedDcm generatedDcm);
		(string SchemaName, IEnumerable<Guid> RecordIds) SaveDcmStagesData(GeneratedDcm generatedDcm);
	}

	[DefaultBinding(typeof(IGeneratedDcmSaver))]
	public class GeneratedDcmSaver : IGeneratedDcmSaver
	{

		#region Constants: Private

		private const string DefStageColor = "#54AA4D"; // Green

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public GeneratedDcmSaver(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private GeneratedEntityColumn GenerateColumnForDcmStages(GeneratedEntity generatedEntity) {
			string prefix = _userConnection.SchemaNamePrefix;
			GeneratedEntity stagesLookup = new GeneratedEntity {
				EntitySchemaName = generatedEntity.EntitySchemaName + "Stages",
				Caption = generatedEntity.Caption + " Stages",
				Columns = new List<GeneratedEntityColumn> {
					new GeneratedEntityColumn {
						Name = prefix + "Name",
						Caption = "Name",
						Type = (int)DataValueType.MediumText
					}
				}
			};
			generatedEntity.Lookups.Add(stagesLookup);
			var stageColumn = new GeneratedEntityColumn {
				Name = prefix + "DcmStage",
				Caption = "Stage",
				Type = (int)DataValueType.Lookup,
				ReferenceSchemaName = stagesLookup.EntitySchemaName
			};
			generatedEntity.Columns.Add(stageColumn);
			return stageColumn;
		}

		#endregion

		#region Methods: Public

		public GeneratedDcm CreateGeneratedDcm(List<string> stagesCaptions, GeneratedEntity generatedEntity) {
			if (stagesCaptions.IsNullOrEmpty()) {
				return null;
			}
			var stageColumn = generatedEntity.Columns.FirstOrDefault(col =>
				(col.Name.EndsWith("Status") || col.Name.EndsWith("Stage")) && col.Type == (int)DataValueType.Lookup);
			if (stageColumn == null) {
				stageColumn = GenerateColumnForDcmStages(generatedEntity);
			}
			var generatedDcm = new GeneratedDcm {
				Stages = stagesCaptions.Select(caption => (Guid.NewGuid(), caption)).ToList(),
				StageColumnName = stageColumn.Name 
			};
			return generatedDcm;
		}

		public void SetStageColumnDefaultValue(GeneratedDcm generatedDcm, GeneratedEntity generatedEntity) {
			if (generatedDcm == null || generatedDcm.Stages.Count == 0) {
				return;
			}
			GeneratedEntityColumn stageColumn =
				generatedEntity.Columns.FirstOrDefault(column => column.Name == generatedDcm.StageColumnName);
			if (stageColumn == null) {
				return;
			}
			stageColumn.DefaultValue = generatedDcm.Stages.First().Id;
		}

		public void SaveDcmSchema(GeneratedDcm generatedDcm, GeneratedEntity generatedEntity, Guid packageUId) {
			if (generatedDcm?.StageColumnName == null) {
				return;
			}
			ISchemaManagerItem<EntitySchema> mainSectionManagerItem =
				_userConnection.EntitySchemaManager.GetItemByName(generatedEntity.EntitySchemaName);
			var mainSectionEntitySchema =
				_userConnection.EntitySchemaManager.GetDesignInstance(_userConnection, mainSectionManagerItem.RealUId);
			var stageColumn = mainSectionEntitySchema.Columns.FirstOrDefault(column =>
				column.Name == generatedDcm.StageColumnName);
			if (stageColumn == null) {
				return;
			}
			var dcmSchemaManager = _userConnection.DcmSchemaManager;
			generatedDcm.DcmSchemaUId = Guid.NewGuid();
			generatedDcm.EntitySchemaUId = mainSectionEntitySchema.UId;
			generatedDcm.StageColumnUId = stageColumn.UId;
			generatedDcm.StagesEntitySchemaUId = stageColumn.ReferenceSchemaUId;
			var dcmSchema = new DcmSchema(dcmSchemaManager) {
				Name = generatedEntity.EntitySchemaName + "Case",
				Caption = generatedEntity.Caption + " Case",
				EntitySchemaUId = generatedDcm.EntitySchemaUId,
				StageColumnUId = generatedDcm.StageColumnUId,
				UId = generatedDcm.DcmSchemaUId,
				Id = generatedDcm.DcmSchemaUId,
				PackageUId = packageUId
			};
			int i = 1;
			foreach ((Guid Id, string Caption) stage in generatedDcm.Stages) {
				dcmSchema.Stages.Add(new DcmSchemaStage {
					UId = stage.Id,
					Name = $"Stage{i}",
					Caption = stage.Caption,
					StageRecordId = stage.Id,
					IsDefault = i == 1,
					Color = DefStageColor
				});
				i++;
				generatedDcm.Stages.Select(kv => kv.Id).Where(id => id != stage.Id).ForEach(targetStageId => {
					dcmSchema.StageConnections.Connections.Add(new DcmSchemaStageConnection {
						Source = stage.Id,
						Target = targetStageId
					});
				});
			}
			var managerItem = new DcmSchemaManagerItem(dcmSchemaManager) {
				Instance = dcmSchema,
				PackageUId = dcmSchema.PackageUId
			};
			dcmSchema.ManagerItem = managerItem;
			managerItem.Assign(dcmSchema);
			managerItem.Id = dcmSchema.Id;
			managerItem.Descriptor = new SchemaManagerItemDescriptor();
			dcmSchemaManager.SaveSchema(managerItem, _userConnection);
		}

		public IEnumerable<(string SchemaName, IEnumerable<Guid> RecordIds)> SaveDcmSettings(GeneratedDcm generatedDcm) {
			if (generatedDcm == null) {
				return null;
			}
			var dcmSettingsId = Guid.NewGuid();
			var dcmSettingsEntity = _userConnection.EntitySchemaManager.GetEntityByName("SysDcmSettings", _userConnection);
			dcmSettingsEntity.SetColumnValue(dcmSettingsEntity.Schema.PrimaryColumn, dcmSettingsId);
			dcmSettingsEntity.SetColumnValue("SysSchemaUId", generatedDcm.EntitySchemaUId);
			dcmSettingsEntity.SetColumnValue("StageColumnUId", generatedDcm.StageColumnUId);
			dcmSettingsEntity.Save();
			Guid dcmSchemaInSettingsId = Guid.NewGuid();
			var dcmSchemaInSettingsEntity =
				_userConnection.EntitySchemaManager.GetEntityByName("SysDcmSchemaInSettings", _userConnection);
			dcmSchemaInSettingsEntity.SetColumnValue(dcmSchemaInSettingsEntity.Schema.PrimaryColumn, dcmSchemaInSettingsId);
			dcmSchemaInSettingsEntity.SetColumnValue("SysDcmSettingsId", dcmSettingsId);
			dcmSchemaInSettingsEntity.SetColumnValue("SysDcmSchemaUId", generatedDcm.DcmSchemaUId);
			dcmSchemaInSettingsEntity.Save();
			return new (string SchemaName, IEnumerable<Guid> RecordIds)[] {
				("SysDcmSettings", new List<Guid> { dcmSettingsId }),
				("SysDcmSchemaInSettings", new List<Guid> { dcmSchemaInSettingsId })
			};
		}

		public (string SchemaName, IEnumerable<Guid> RecordIds) SaveDcmStagesData(GeneratedDcm generatedDcm) {
			if (generatedDcm == null || generatedDcm.StagesEntitySchemaUId == Guid.Empty) {
				return (null, null);
			}
			EntitySchema stagesEntitySchema = _userConnection.EntitySchemaManager
				.GetDesignInstance(_userConnection, generatedDcm.StagesEntitySchemaUId);
			foreach (var stage in generatedDcm.Stages) {
				var stagesEntity = stagesEntitySchema.CreateEntity(_userConnection);
				stagesEntity.PrimaryColumnValue = stage.Id;
				stagesEntity.PrimaryDisplayColumnValue = stage.Caption;
				stagesEntity.Save();
			}
			return (stagesEntitySchema.Name, generatedDcm.Stages.Select(stages => stages.Id));
		}

		#endregion

	}
}

