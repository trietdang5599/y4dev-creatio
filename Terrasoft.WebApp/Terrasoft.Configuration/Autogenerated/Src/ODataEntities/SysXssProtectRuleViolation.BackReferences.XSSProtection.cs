namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysXssProtectRuleViolation

	/// <exclude/>
	public class SysXssProtectRuleViolation : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysXssProtectRuleViolation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysXssProtectRuleViolation";
		}

		public SysXssProtectRuleViolation(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysXssProtectRuleViolation";
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
		/// Blocked URL.
		/// </summary>
		public string BlockedUrl {
			get {
				return GetTypedColumnValue<string>("BlockedUrl");
			}
			set {
				SetColumnValue("BlockedUrl", value);
			}
		}

		/// <summary>
		/// Agent.
		/// </summary>
		public string Agent {
			get {
				return GetTypedColumnValue<string>("Agent");
			}
			set {
				SetColumnValue("Agent", value);
			}
		}

		/// <summary>
		/// IP address.
		/// </summary>
		public string IPAddress {
			get {
				return GetTypedColumnValue<string>("IPAddress");
			}
			set {
				SetColumnValue("IPAddress", value);
			}
		}

		/// <summary>
		/// User login.
		/// </summary>
		public string UserLogin {
			get {
				return GetTypedColumnValue<string>("UserLogin");
			}
			set {
				SetColumnValue("UserLogin", value);
			}
		}

		/// <summary>
		/// Violation date.
		/// </summary>
		public DateTime ViolationDate {
			get {
				return GetTypedColumnValue<DateTime>("ViolationDate");
			}
			set {
				SetColumnValue("ViolationDate", value);
			}
		}

		/// <summary>
		/// Entity schema name.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
			}
		}

		/// <summary>
		/// Violated rule.
		/// </summary>
		public string ViolatedRule {
			get {
				return GetTypedColumnValue<string>("ViolatedRule");
			}
			set {
				SetColumnValue("ViolatedRule", value);
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
		public Guid ViolatedRuleTypeId {
			get {
				return GetTypedColumnValue<Guid>("ViolatedRuleTypeId");
			}
			set {
				SetColumnValue("ViolatedRuleTypeId", value);
				_violatedRuleType = null;
			}
		}

		/// <exclude/>
		public string ViolatedRuleTypeName {
			get {
				return GetTypedColumnValue<string>("ViolatedRuleTypeName");
			}
			set {
				SetColumnValue("ViolatedRuleTypeName", value);
				if (_violatedRuleType != null) {
					_violatedRuleType.Name = value;
				}
			}
		}

		private SysXssProtectRuleType _violatedRuleType;
		/// <summary>
		/// Violated rule type.
		/// </summary>
		public SysXssProtectRuleType ViolatedRuleType {
			get {
				return _violatedRuleType ??
					(_violatedRuleType = new SysXssProtectRuleType(LookupColumnEntities.GetEntity("ViolatedRuleType")));
			}
		}

		#endregion

	}

	#endregion

}

