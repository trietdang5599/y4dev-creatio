namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: CopilotClientQuota

	/// <exclude/>
	public class CopilotClientQuota : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CopilotClientQuota(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CopilotClientQuota";
		}

		public CopilotClientQuota(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CopilotClientQuota";
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
		/// Tokens Limit.
		/// </summary>
		/// <remarks>
		/// The maximum number of allocated tokens.
		/// </remarks>
		public int TokensLimit {
			get {
				return GetTypedColumnValue<int>("TokensLimit");
			}
			set {
				SetColumnValue("TokensLimit", value);
			}
		}

		/// <summary>
		/// Tokens Usage.
		/// </summary>
		/// <remarks>
		/// The number of client tokens used.
		/// </remarks>
		public int TokensUsage {
			get {
				return GetTypedColumnValue<int>("TokensUsage");
			}
			set {
				SetColumnValue("TokensUsage", value);
			}
		}

		/// <summary>
		/// Tokens available.
		/// </summary>
		/// <remarks>
		/// The remaining number of available tokens.
		/// </remarks>
		public int TokensAvailable {
			get {
				return GetTypedColumnValue<int>("TokensAvailable");
			}
			set {
				SetColumnValue("TokensAvailable", value);
			}
		}

		/// <summary>
		/// Actions Usage.
		/// </summary>
		/// <remarks>
		/// The number of client actions used.
		/// </remarks>
		public int ActionsUsage {
			get {
				return GetTypedColumnValue<int>("ActionsUsage");
			}
			set {
				SetColumnValue("ActionsUsage", value);
			}
		}

		/// <summary>
		/// Actions Limit.
		/// </summary>
		/// <remarks>
		/// The maximum number of allocated actions.
		/// </remarks>
		public int ActionsLimit {
			get {
				return GetTypedColumnValue<int>("ActionsLimit");
			}
			set {
				SetColumnValue("ActionsLimit", value);
			}
		}

		/// <summary>
		/// Actions available.
		/// </summary>
		/// <remarks>
		/// The remaining number of available actions.
		/// </remarks>
		public int ActionsAvailable {
			get {
				return GetTypedColumnValue<int>("ActionsAvailable");
			}
			set {
				SetColumnValue("ActionsAvailable", value);
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

		#endregion

	}

	#endregion

}

