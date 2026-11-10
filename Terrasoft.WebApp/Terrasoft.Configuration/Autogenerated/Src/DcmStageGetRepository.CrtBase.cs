namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Common;
	using Core;
	using Core.Factories;
	using Terrasoft.Core.DcmProcess;

	#region Class: GetStageRepository

	/// <summary>
	/// Provides methods to obtain dcm stages.
	/// </summary>
	/// <typeparam name="CommonStageData">Stage data</typeparam>
	[DefaultBinding(typeof(IGetRepository<CommonStageData>), Name = nameof(DcmStageGetRepository))]
	public class DcmStageGetRepository : IGetRepository<CommonStageData> 
	{

		#region Constructors: Public

		public DcmStageGetRepository(UserConnection userConnection, DcmSchema dcmSchema) {
			dcmSchema.CheckArgumentNull(nameof(dcmSchema));
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
			DcmSchema = dcmSchema;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }
		
		protected DcmSchema DcmSchema { get;}

		#endregion
		
		#region Methods: Private
		
		private bool IsStageIsInLastGroup(DcmSchemaStage dcmStage) {
			return dcmStage.ParentStageUId.IsNotEmpty() && 
				DcmSchema.Stages.Last().ParentStageUId == dcmStage.ParentStageUId;
		}

		private bool IsStageIsLast(DcmSchemaStage dcmStage) {
			return DcmSchema.Stages.Last().StageRecordId == dcmStage.StageRecordId;
		}
		
		#endregion
		
		#region Methods: Public

		/// <summary>
		/// Gets entity data by identifier.
		/// </summary>
		/// <param name="id">The item identifier.</param>
		/// <returns>The entity data.</returns>
		public CommonStageData Get(Guid id) {
			var dcmStage = DcmSchema.Stages.Find((stage) => stage.StageRecordId == id);
			var parentStage = DcmSchema.Stages.FindByUId(dcmStage.ParentStageUId);
			return new CommonStageData {
				Id = dcmStage.StageRecordId,
				ParentStageId = parentStage?.StageRecordId ?? Guid.Empty,
				DisplayValue = dcmStage.Caption,
				IsSuccessful = dcmStage.IsSuccessful,
				IsEnd = IsStageIsLast(dcmStage) || IsStageIsInLastGroup(dcmStage)
			};
		}

		/// <summary>
		/// Gets all entity data.
		/// </summary>
		/// <returns>Collection of entity data.</returns>
		public IEnumerable<CommonStageData> GetAll() {
			var stages = new List<CommonStageData>();
			int index = 0;
			DcmSchema.Stages.ForEach((stage) => {
				var parentStage = DcmSchema.Stages.FindByUId(stage.ParentStageUId);
				stages.Add(new CommonStageData {
					Id = stage.StageRecordId,
					Number = index,
					ParentStageId = parentStage?.StageRecordId ?? Guid.Empty,
					DisplayValue = stage.Caption
				});
				index++;
			});
			var lastStage = stages.LastOrDefault();
			if (lastStage == null) {
				return stages;
			}
			if (lastStage.ParentStageId.IsNotEmpty()) {
				var lastGroupedStages = stages.Where(stage =>
					stage.ParentStageId == lastStage.ParentStageId || stage.Id == lastStage.ParentStageId);
				lastGroupedStages.ForEach(stage => {
					stage.IsSuccessful = DcmSchema.Stages.Find(dcmStage => dcmStage.StageRecordId == stage.Id).IsSuccessful;
					stage.IsEnd = true;
				});
			} else {
				lastStage.IsEnd = true;
				lastStage.IsSuccessful = DcmSchema.Stages.Find(dcmStage => dcmStage.StageRecordId == lastStage.Id)
					.IsSuccessful;
			}
			return stages;
		}
		
		#endregion

	}

	#endregion

}

