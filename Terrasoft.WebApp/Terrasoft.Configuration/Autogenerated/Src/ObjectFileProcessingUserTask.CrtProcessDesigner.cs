namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.File;
	using Terrasoft.WebApp;

	#region Class: ObjectFileProcessingUserTask

	/// <summary>
	/// Represents user task to process object files.
	/// </summary>
	public partial class ObjectFileProcessingUserTask
	{

		#region Properties: Public

		private IFileProcessing _fileProcessing;

		/// <summary>
		/// Gets or sets instance that provides methods for the processing files.
		/// </summary>
		public IFileProcessing FileProcessing {
			get => _fileProcessing ?? (_fileProcessing = new FileProcessing(UserConnection, TargetDataEntitySchemaUId));
			set => _fileProcessing = value;
		}

		#endregion

		#region Methods: Private

		private void FillFileDataFilters(EntitySchemaQuery esq, EntitySchemaManager entitySchemaManager) {
			IEntitySchemaQueryFilterItem filterItem = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type",
				FileConsts.FileTypeUId);
			esq.Filters.Add(filterItem);
			if (SourceDataEntitySchemaUId.IsEmpty()) {
				return;
			}
			EntitySchema sourceDataSchema = entitySchemaManager.GetInstanceByUId(SourceDataEntitySchemaUId);
			filterItem = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "RecordSchemaName",
				sourceDataSchema.Name);
			esq.Filters.Add(filterItem);
		}

		private void SetCreatedObjectFileIds(IList<EntityFileLocator> createdFileLocators) {
			var compositeObjectList = new CompositeObjectList<CompositeObject>();
			foreach (EntityFileLocator createdFileLocator in createdFileLocators) {
				var compositeObject = new CompositeObject {
					{ "Id", createdFileLocator.RecordId }
				};
				compositeObjectList.Add(compositeObject);
			}
			CreatedObjectFileIds = compositeObjectList;
		}

		private void SetReadObjectFiles(IList<EntityFileLocator> fileLocators) {
			var compositeObjectList = new CompositeObjectList<CompositeObject>();
			foreach (EntityFileLocator fileLocator in fileLocators) {
				var compositeObject = new CompositeObject {
					{ "File",  fileLocator }
				};
				compositeObjectList.Add(compositeObject);
			}
			ObjectFiles = compositeObjectList;
		}

		private void ReadFiles(EntitySchemaQuery esq) {
			IList<EntityFileLocator> fileLocators = FileProcessing.GetFileLocators(esq);
			SetReadObjectFiles(fileLocators);
			SetCreatedObjectFileIds(new List<EntityFileLocator>());
		}

		private void CopyFiles(EntitySchemaQuery esq) {
			var settings = new ObjectFilesCopySettings {
				EntitySchemaQuery = esq,
				TargetEntitySchemaUId = TargetEntitySchemaUId,
				ConnectedObjectId = ConnectedObjectId,
				ConnectedObjectColumnUId = ConnectedObjectColumnUId
			};
			FileCopyResults fileCopyResults = FileProcessing.Copy(settings);
			SetReadObjectFiles(fileCopyResults.SourceFileLocators);
			SetCreatedObjectFileIds(fileCopyResults.TargetFileLocators);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema sourceSchema = entitySchemaManager.GetInstanceByUId(SourceEntitySchemaUId);
			ResultActionTypeEnum actionType = (ResultActionTypeEnum)ResultActionType;
			var esq = new EntitySchemaQuery(sourceSchema) {
				RowCount = RecordsToRead
			};
			ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, sourceSchema, esq, DataSourceFilters);
			ProcessUserTaskUtilities.SpecifyESQOrderByStatement(esq, OrderByInfo);
			FillFileDataFilters(esq, entitySchemaManager);
			if (actionType == ResultActionTypeEnum.SaveToFiles) {
				CopyFiles(esq);
			} else if (actionType == ResultActionTypeEnum.UseInProcess) {
				ReadFiles(esq);
			} else {
				throw new NotSupportedException(actionType.ToLocalizedString());
			}
			return true;
		}

		#endregion

	}

	#endregion

	#region Class: ObjectFileProcessingUserTaskSchemaExtension

	/// <exclude/>
	public class ObjectFileProcessingUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		/// <inheritdoc cref="ProcessUserTaskSchemaExtension.AnalyzePackageDependencies"/>
		public override void AnalyzePackageDependencies(ProcessSchemaUserTask schemaElement,
				IProcessSchemaPackageDependencyReporter dependencyReporter) {
			base.AnalyzePackageDependencies(schemaElement, dependencyReporter);
			ProcessSchemaParameterCollection parameters = schemaElement.Parameters;
			ProcessSchemaParameter sourceEntitySchemaUIdParameter = parameters.GetByName("SourceEntitySchemaUId");
			ProcessSchemaParameterValue sourceValue = sourceEntitySchemaUIdParameter.SourceValue;
			Guid.TryParse(sourceValue.Value, out Guid entitySchemaUId);
			ProcessSchemaParameter orderByInfoParameter = parameters.GetByName("OrderByInfo");
			AnalyzeOrderInfoParameterPackageDependencies(entitySchemaUId, schemaElement.Name, orderByInfoParameter,
				dependencyReporter);
		}

		#endregion

	}

	#endregion

}
