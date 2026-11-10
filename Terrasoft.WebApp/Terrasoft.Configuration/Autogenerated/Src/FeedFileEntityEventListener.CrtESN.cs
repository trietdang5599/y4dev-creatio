namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.DB;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;
	using Terrasoft.Configuration.ESN;

	#region Class: FeedFileEventListener
	/// <summary>
	/// Class provides event listening for FeedFile entity.
	/// </summary>
	[EntityEventListener(SchemaName = "FeedFile")]
	public class FeedFileEventListener : BaseEntityEventListener
	{
		#region Methods: Public

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var feedFile = sender as Entity;
			var uc = feedFile.UserConnection;
			Entity socialMessageEntity;
			var socialMessageId = feedFile.GetTypedColumnValue<Guid>("RecordId");
			var esnMessageReader = ClassFactory.Get<IEsnMessageReader>(new ConstructorArgument("userConnection", uc));
			if (uc.GetIsFeatureEnabled("DoNotListenFeedFileNotification") ||
				(socialMessageEntity = esnMessageReader.ReadMessage(socialMessageId)) == null) {
				return;
			}
			var feedNotifier = ClassFactory.Get<FeedNotifier>(new ConstructorArgument("entity", socialMessageEntity));
			feedNotifier.SendUpdateDeleteSocialMessage("forceUpdate");
		}

		/// <inheritdoc/>

		#endregion

	}

	#endregion

}

