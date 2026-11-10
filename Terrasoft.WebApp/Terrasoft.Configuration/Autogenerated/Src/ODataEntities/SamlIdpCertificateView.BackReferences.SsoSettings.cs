namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SamlIdpCertificateView

	/// <exclude/>
	public class SamlIdpCertificateView : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SamlIdpCertificateView(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SamlIdpCertificateView";
		}

		public SamlIdpCertificateView(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SamlIdpCertificateView";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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
		/// Valid from.
		/// </summary>
		public DateTime NotBefore {
			get {
				return GetTypedColumnValue<DateTime>("NotBefore");
			}
			set {
				SetColumnValue("NotBefore", value);
			}
		}

		/// <summary>
		/// Certificate subject.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Thumbprint.
		/// </summary>
		public string Thumbprint {
			get {
				return GetTypedColumnValue<string>("Thumbprint");
			}
			set {
				SetColumnValue("Thumbprint", value);
			}
		}

		/// <summary>
		/// Valid untill.
		/// </summary>
		public DateTime NotAfter {
			get {
				return GetTypedColumnValue<DateTime>("NotAfter");
			}
			set {
				SetColumnValue("NotAfter", value);
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
		public Guid SsoSamlSettingsId {
			get {
				return GetTypedColumnValue<Guid>("SsoSamlSettingsId");
			}
			set {
				SetColumnValue("SsoSamlSettingsId", value);
				_ssoSamlSettings = null;
			}
		}

		private SsoSamlSettings _ssoSamlSettings;
		/// <summary>
		/// SsoSamlSettings.
		/// </summary>
		public SsoSamlSettings SsoSamlSettings {
			get {
				return _ssoSamlSettings ??
					(_ssoSamlSettings = new SsoSamlSettings(LookupColumnEntities.GetEntity("SsoSamlSettings")));
			}
		}

		#endregion

	}

	#endregion

}

