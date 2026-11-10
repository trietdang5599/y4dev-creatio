 namespace Terrasoft.Configuration
{
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: CompilationHistoryEventListener

	[EntityEventListener(SchemaName = "CompilationHistory")]
	public class CompilationHistoryEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void ThrowReadonlyException(object sender) {
			var schemaCaption = ((Entity)sender).Schema.Caption;
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
