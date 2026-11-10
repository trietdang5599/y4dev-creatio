namespace Terrasoft.Configuration.RelatedRecords
{
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: IRelatedRecordsManager

	/// <summary>
	/// Interface of related records manager.
	/// </summary>
	public interface IRelatedRecordsManager
	{

		#region Methods: Public

		/// <summary>
		/// Adds related records.
		/// </summary>
		/// <param name="managerData"><see cref="RelatedRecordsManagerData"/> for adding related records.</param>
		/// <returns>Count of processed records.</returns>
		int AddRelatedRecords(RelatedRecordsManagerData managerData);

		/// <summary>
		/// Remove related records.
		/// </summary>
		/// <param name="managerData"><see cref="RelatedRecordsManagerData"/> for removing related records.</param>
		/// <returns>Count of processed records.</returns>
		int RemoveRelatedRecords(RelatedRecordsManagerData managerData);

		#endregion

	}

	#endregion

	#region Class: RelatedRecordsManager

	/// <summary>
	/// Related records manager.
	/// </summary>
	[DefaultBinding(typeof(IRelatedRecordsManager), Name = nameof(RelatedRecordsManager))]
	public class RelatedRecordsManager : IRelatedRecordsManager
	{

		#region Properties: Private

		private IRelatedRecordsProvider RelatedRecordsProvider { get; set; }

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Constructors: Public

		public RelatedRecordsManager(UserConnection userConnection, IRelatedRecordsProvider relatedRecordsProvider) {
			this.UserConnection = userConnection;
			this.RelatedRecordsProvider = relatedRecordsProvider;
		}

		#endregion

		#region Methods: Private

		private AddRelatedRecordsProviderData CreateAddRelatedRecordsData(RelatedRecordsManagerData managerData) {
			var baseRelatedRecordsPrivderData = CreateBaseRelatedRecordsProviderData(managerData);
			var addRelatedRecordsProviderData = new AddRelatedRecordsProviderData(baseRelatedRecordsPrivderData);
			SetDefaultValuesToAddRelatedRecordsProviderData(addRelatedRecordsProviderData, managerData);
			return addRelatedRecordsProviderData;
		}

		private RemoveRelatedRecordsProviderData CreateRemoveRelatedRecordsData(RelatedRecordsManagerData managerData) {
			var baseRelatedRecordsPrivderData = CreateBaseRelatedRecordsProviderData(managerData);
			return new RemoveRelatedRecordsProviderData(baseRelatedRecordsPrivderData);
		}

		private BaseRelatedRecordsProviderData CreateBaseRelatedRecordsProviderData(
			RelatedRecordsManagerData managerData) {
			var mainRecordsSchemaQuery = GetMainRecordsEntitySchemaQuery(managerData);
			var relatedRecordsSchemaQuery = GetRelatedRecordsEntitySchemaQuery(managerData);
			return new BaseRelatedRecordsProviderData {
				MainRecordsSchemaQuery = mainRecordsSchemaQuery,
				RelatedRecordsSchemaQuery = relatedRecordsSchemaQuery,
				RelatedInMainRecordsSchemaName = managerData.RelatedInMainRecordsSchemaName,
				MainRecordColumnName = managerData.MainRecordColumnName,
				RelatedRecordColumnName = managerData.RelatedRecordColumnName
			};
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets main records entity schema query.
		/// </summary>
		/// <param name="managerData"><see cref="RelatedRecordsManagerData"/>.</param>
		/// <returns><see cref="EntitySchemaQuery"/> of main records.</returns>
		protected virtual EntitySchemaQuery GetMainRecordsEntitySchemaQuery(RelatedRecordsManagerData managerData) {
			return managerData.MainRecordsSchemaQuery;
		}

		/// <summary>
		/// Gets related records entity schema query.
		/// </summary>
		/// <param name="managerData"><see cref="RelatedRecordsManagerData"/>.</param>
		/// <returns><see cref="EntitySchemaQuery"/> of related records.</returns>
		protected virtual EntitySchemaQuery GetRelatedRecordsEntitySchemaQuery(RelatedRecordsManagerData managerData) {
			return managerData.RelatedRecordsSchemaQuery;
		}

		/// <summary>
		/// Sets default value to <see cref="AddRelatedRecordsProviderData"/>.
		/// </summary>
		/// <param name="providerData"><see cref="AddRelatedRecordsProviderData"/>.</param>
		/// <param name="managerData"><see cref="RelatedRecordsManagerData"/>.</param>
		protected virtual void SetDefaultValuesToAddRelatedRecordsProviderData(
			AddRelatedRecordsProviderData providerData, RelatedRecordsManagerData managerData) {
			providerData.DefaultValues = managerData.DefaultValues ?? new Dictionary<string, string>();
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public int AddRelatedRecords(RelatedRecordsManagerData managerData) {
			var addRelatedRecordsData = CreateAddRelatedRecordsData(managerData);
			return RelatedRecordsProvider.AddRelatedRecords(addRelatedRecordsData);
		}

		/// <inheritdoc />
		public int RemoveRelatedRecords(RelatedRecordsManagerData managerData) {
			var removeRelatedRecordsData = CreateRemoveRelatedRecordsData(managerData);
			return RelatedRecordsProvider.RemoveRelatedRecords(removeRelatedRecordsData);
		}

		#endregion

	}

	#endregion

}

