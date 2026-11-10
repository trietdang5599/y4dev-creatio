 namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;

	#region Class: SysApprovalNotificationProvider

	/// <summary>
	/// Visas notification provider for sections.
	/// </summary>
	public class SysApprovalNotificationProvider : BaseVisaNotificationProvider, INotification
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="SysApprovalNotificationProvider"/> class with parameters.
		/// </summary>
		/// <param name="parameters">Parameters dictionary.</param>
		public SysApprovalNotificationProvider(Dictionary<string, object> parameters)
			: base(parameters) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SysApprovalNotificationProvider"/> class with parameters.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		public SysApprovalNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion
		
		#region Fields: Private

		private readonly string _approvalSchemaName = "SysApproval";

		private readonly string _referenceSchemaColumnName = "ReferenceSchemaName";

		#endregion

		#region Methods: Private

		private Select GetSysModuleSelect() {
			var schemaSelect =
				new Select(UserConnection).Distinct()
						.Column("SysSchema", "UId").As("EntitySchemaUId")
						.Column("SysModule", "Image32Id")
					.From("SysSchema")
					.LeftOuterJoin("SysModuleEntity").On("SysModuleEntity", "SysEntitySchemaUId")
						.IsEqual("SysSchema", "UId")
					.LeftOuterJoin("SysModule").On("SysModule", "SysModuleEntityId")
						.IsEqual("SysModuleEntity", "Id")
					.Where("SysSchema", "Name")
						.In(GetVisaEntitiesSelect())
					.And("SysSchema", "ExtendParent")
						.IsEqual(Column.Parameter(false))
					as Select;
			return schemaSelect;
		}
		
		private Select GetVisaEntitiesSelect() {
			var select =
				new Select(UserConnection)
					.Distinct()
					.Column(_referenceSchemaColumnName)
					.From(_approvalSchemaName) as Select;
			return select;
		}

		private void ClearApprovals() {
			Select referredRecordsSelect = null;
			var visaEntitiesSelect = GetVisaEntitiesSelect();
			visaEntitiesSelect.ExecuteReader(reader => {
				var refSchemaName = reader.GetColumnValue<string>(_referenceSchemaColumnName);
				var entitySelect = new Select(UserConnection)
					.Column("Id")
					.From(_approvalSchemaName).As("sa")
					.Where(_referenceSchemaColumnName).IsEqual(Column.Parameter(refSchemaName))
					.And().Not().Exists(
						new Select(UserConnection)
							.Column("Id")
							.From(refSchemaName)
							.Where("Id").IsEqual("sa", "EntityId")) as Select;
				if (referredRecordsSelect == null) {
					referredRecordsSelect = entitySelect;
				} else {
					referredRecordsSelect.UnionAll(entitySelect);
				}
			});
			if (referredRecordsSelect != null) {
				var delete = new Delete(UserConnection)
					.From(_approvalSchemaName)
					.Where("Id").In(referredRecordsSelect) as Delete;
				delete.Execute();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Return number of section notification.
		/// </summary>
		/// <returns>A number of notification.</returns>
		public override int GetCount() {
			Select entitySelect = GetEntitiesSelect();
			if (entitySelect == null) {
				return 0;
			}
			Select countSelect =
				new Select(UserConnection)
					.Column(Func.Count("Id"))
					.Distinct()
				.From(entitySelect).As("CountSelect") as Select;
			return countSelect.ExecuteScalar<int>();
		}

		/// <summary>
		/// Returns <see cref="Select"/> for section visas./>
		/// </summary>
		/// <returns>A <see cref="Select"/> instance.</returns>
		public override Select GetEntitiesSelect() {
			if (UserConnection.GetIsFeatureEnabled("ClearUnusedSysApprovals")) {
				ClearApprovals();
			}
			Select entitiesSelect = null;
			GetSysModuleSelect().ExecuteReader(reader => {
				Guid entitySchemaUId = reader.GetColumnValue<Guid>("EntitySchemaUId");
				Guid sysModuleImage32Id = reader.GetColumnValue<Guid>("Image32Id");
				EntitySchema entitySchema = EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
				var sysModuleVisaProvider = new BaseVisaNotificationProvider(parameters) {
					Name = entitySchema.Name,
					Caption = entitySchema.Caption,
					Visa = _approvalSchemaName,
					VisaMasterColumn = "EntityId",
					TitleColumn = entitySchema.PrimaryDisplayColumn?.ColumnValueName,
					ImageId = sysModuleImage32Id
				};
				Select sysModuleVisaSelect = sysModuleVisaProvider.GetEntitiesSelect();
				entitiesSelect = entitiesSelect == null
					? sysModuleVisaSelect
					: entitiesSelect.UnionAll(sysModuleVisaSelect) as Select;
			});
			return entitiesSelect;
		}

		/// <summary>
		/// Returns notification. Method is not implemented.
		/// </summary>
		public IEnumerable<INotificationInfo> GetNotifications() {
			throw new NotImplementedException();
		}

		#endregion

	}

	#endregion
}
