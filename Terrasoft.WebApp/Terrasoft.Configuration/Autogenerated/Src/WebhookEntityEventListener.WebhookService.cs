using Terrasoft.Configuration;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Entities.Events;
using Terrasoft.Core.Factories;

/// <summary>
/// This class is used to handle events for the WebhookEntity.
/// </summary>
[EntityEventListener(SchemaName = "WebhookEntity")]
public class WebhookEntityEventListener : BaseEntityEventListener
{
	private IWebhookServiceApi _webhookServiceApi;
	 
	private IWebhookServiceApi WebhookServiceApi {
		get {
			if (_webhookServiceApi != null) {
				return _webhookServiceApi;
			}
			_webhookServiceApi = ClassFactory.Get<IWebhookServiceApi>();
			return _webhookServiceApi;
		}
	}

	/// <summary>
	/// This method is called when a WebhookEntity is updated.
	/// </summary>
	public override void OnSaved(object sender, EntityAfterEventArgs e) {
		base.OnSaved(sender, e);
		WebhookServiceApi.FlushWebhookEntitiesCache();
	}

	/// <summary>
	/// This method is called when a WebhookEntity is deleted.
	/// </summary>
	public override void OnDeleted(object sender, EntityAfterEventArgs e) {
		base.OnDeleted(sender, e);
		WebhookServiceApi.FlushWebhookEntitiesCache();
	}
}
