 namespace Terrasoft.Configuration
{
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: SysCultureEntityEventListener

	[EntityEventListener(SchemaName = "SysCulture")]
	public class SysCultureEntityEventListener : BaseEntityEventListener
	{

		#region Constants: Private

		private const int CultureCount = 36;

		#endregion

		#region Methods: Private

		private static void CheckSysCulturesCount(Entity entity) {
			var userConnection = entity.UserConnection;
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysCulture");
			esq.AddColumn("Id");
			var collection = esq.GetEntityCollection(userConnection);
			if (collection.Count < CultureCount) {
				return;
			}
			var errorTemplate = new LocalizableString(userConnection.ResourceStorage, "SysCultureEntityEventListener",
				"LocalizableStrings.CantAddCulture.Value").ToString();
			var errorMessage = string.Format(errorTemplate, string.Join(", ", CultureCount));
			throw new ValidateException(errorMessage);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			base.OnInserting(sender, e);
			CheckSysCulturesCount(sender as Entity);
		}

		#endregion

	}

	#endregion

	

}


