namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: Webhook

	/// <exclude/>
	public class Webhook : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Webhook(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Webhook";
		}

		public Webhook(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Webhook";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<WebhookLog> WebhookLogCollectionByWebhook {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Active processes.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		/// <summary>
		/// API key.
		/// </summary>
		public string ApiKey {
			get {
				return GetTypedColumnValue<string>("ApiKey");
			}
			set {
				SetColumnValue("ApiKey", value);
			}
		}

		/// <summary>
		/// SourceUrl.
		/// </summary>
		public string SourceUrl {
			get {
				return GetTypedColumnValue<string>("SourceUrl");
			}
			set {
				SetColumnValue("SourceUrl", value);
			}
		}

		/// <summary>
		/// Webhook source.
		/// </summary>
		/// <remarks>
		/// Indicates the external platform or system that triggered the webhook, helping teams trace data origin and monitor integration performance.
		/// </remarks>
		public string WebhookSource {
			get {
				return GetTypedColumnValue<string>("WebhookSource");
			}
			set {
				SetColumnValue("WebhookSource", value);
			}
		}

		/// <summary>
		/// Content type.
		/// </summary>
		public string ContentType {
			get {
				return GetTypedColumnValue<string>("ContentType");
			}
			set {
				SetColumnValue("ContentType", value);
			}
		}

		/// <summary>
		/// Headers.
		/// </summary>
		/// <remarks>
		/// Specifies the data format used in the webhook payload, ensuring recipients know how to interpret and process incoming information.
		/// </remarks>
		public string Headers {
			get {
				return GetTypedColumnValue<string>("Headers");
			}
			set {
				SetColumnValue("Headers", value);
			}
		}

		/// <summary>
		/// Query parameters.
		/// </summary>
		public string QueryParameters {
			get {
				return GetTypedColumnValue<string>("QueryParameters");
			}
			set {
				SetColumnValue("QueryParameters", value);
			}
		}

		/// <summary>
		/// Request body.
		/// </summary>
		/// <remarks>
		/// Contains the full data payload sent by the webhook, showing the information passed from the source system to support event handling or record updates.
		/// </remarks>
		public string RequestBody {
			get {
				return GetTypedColumnValue<string>("RequestBody");
			}
			set {
				SetColumnValue("RequestBody", value);
			}
		}

		/// <summary>
		/// Batch Id.
		/// </summary>
		public Guid BatchId {
			get {
				return GetTypedColumnValue<Guid>("BatchId");
			}
			set {
				SetColumnValue("BatchId", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private WebhookStatus _status;
		/// <summary>
		/// Status.
		/// </summary>
		public WebhookStatus Status {
			get {
				return _status ??
					(_status = new WebhookStatus(LookupColumnEntities.GetEntity("Status")));
			}
		}

		#endregion

	}

	#endregion

}

