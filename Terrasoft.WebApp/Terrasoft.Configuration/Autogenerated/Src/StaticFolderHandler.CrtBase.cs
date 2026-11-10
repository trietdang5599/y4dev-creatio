namespace Terrasoft.Configuration.StaticFolder
{
	using Terrasoft.Configuration.RelatedRecords;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Interface: IStaticFolderHandler

	/// <summary>
	/// Interface of static folder handler.
	/// </summary>
	public interface IStaticFolderHandler : IRelatedRecordsHandler
	{

		#region Methods: Public

		/// <summary>
		/// Adds records to folders.
		/// </summary>
		/// <param name="handlerData"><see cref="RelatedRecordsHandlerData"/> for adding records.</param>
		/// <returns><see cref="RelatedRecordsHandlerResult"/> of added records.</returns>
		RelatedRecordsHandlerResult AddRecords(RelatedRecordsHandlerData handlerData);

		/// <summary>
		/// Removes records from folders.
		/// </summary>
		/// <param name="handlerData"><see cref="RelatedRecordsHandlerData"/> for removing records.</param>
		/// <returns><see cref="RelatedRecordsHandlerResult"/> of removed records.</returns>
		RelatedRecordsHandlerResult RemoveRecords(RelatedRecordsHandlerData handlerData);

		#endregion

	}

	#endregion

	#region Class: StaticFolderHandler

	/// <summary>
	/// Static folder handler.
	/// </summary>
	[DefaultBinding(typeof(IStaticFolderHandler), Name = nameof(StaticFolderHandler))]
	public class StaticFolderHandler : RelatedRecordsHandler, IStaticFolderHandler
	{

		#region Constructors: Public

		public StaticFolderHandler(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override IRelatedRecordsProvider GetAddRelatedRecordsProvider() {
			if (UserConnection.GetIsFeatureEnabled("UseServiceForIncludeEntitiesInFolder")) {
				return ClassFactory.Get<IORMRelatedRecordsProvider>(new ConstructorArgument("userConnection",
					UserConnection));
			}
			return ClassFactory.Get<IEntityRelatedRecordsProvider>(new ConstructorArgument("userConnection",
				UserConnection));
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public RelatedRecordsHandlerResult AddRecords(RelatedRecordsHandlerData handlerData) {
			return AddRelatedRecords(handlerData);
		}

		/// <inheritdoc />
		public RelatedRecordsHandlerResult RemoveRecords(RelatedRecordsHandlerData handlerData) {
			return RemoveRelatedRecords(handlerData);
		}

		#endregion

	}

	#endregion

}

