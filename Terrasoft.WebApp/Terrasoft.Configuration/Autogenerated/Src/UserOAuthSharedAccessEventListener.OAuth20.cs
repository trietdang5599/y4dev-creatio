namespace Terrasoft.Configuration
{
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: UserOAuthSharedAccessEventListener

	[EntityEventListener(SchemaName = "UserOAuthSharedAccess")]
	public class UserOAuthSharedAccessEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void ThrowReadonlyException(object sender) {
			var entity = (Entity)sender;
			if (!entity.UseAdminRights) {
				return;
			}
			var schemaCaption = entity.Schema.Caption;
			throw new ObjectIsReadOnlyException(objectName: schemaCaption);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			ThrowReadonlyException(sender);
		}

		/// <inheritdoc />
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			ThrowReadonlyException(sender);
		}

		/// <inheritdoc />
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			ThrowReadonlyException(sender);
		}

		/// <inheritdoc />
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			ThrowReadonlyException(sender);
		}

		#endregion

	}

	#endregion

}

