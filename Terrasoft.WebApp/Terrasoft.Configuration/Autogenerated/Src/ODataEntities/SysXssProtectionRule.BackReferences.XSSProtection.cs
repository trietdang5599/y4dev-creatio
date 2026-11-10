namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: SysXssProtectionRule

	/// <exclude/>
	public class SysXssProtectionRule : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysXssProtectionRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysXssProtectionRule";
		}

		public SysXssProtectionRule(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysXssProtectionRule";
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
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
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
		public Guid RuleTypeId {
			get {
				return GetTypedColumnValue<Guid>("RuleTypeId");
			}
			set {
				SetColumnValue("RuleTypeId", value);
				_ruleType = null;
			}
		}

		/// <exclude/>
		public string RuleTypeName {
			get {
				return GetTypedColumnValue<string>("RuleTypeName");
			}
			set {
				SetColumnValue("RuleTypeName", value);
				if (_ruleType != null) {
					_ruleType.Name = value;
				}
			}
		}

		private SysXssProtectRuleType _ruleType;
		/// <summary>
		/// Type.
		/// </summary>
		public SysXssProtectRuleType RuleType {
			get {
				return _ruleType ??
					(_ruleType = new SysXssProtectRuleType(LookupColumnEntities.GetEntity("RuleType")));
			}
		}

		/// <exclude/>
		public Guid ProtectionModeId {
			get {
				return GetTypedColumnValue<Guid>("ProtectionModeId");
			}
			set {
				SetColumnValue("ProtectionModeId", value);
				_protectionMode = null;
			}
		}

		/// <exclude/>
		public string ProtectionModeName {
			get {
				return GetTypedColumnValue<string>("ProtectionModeName");
			}
			set {
				SetColumnValue("ProtectionModeName", value);
				if (_protectionMode != null) {
					_protectionMode.Name = value;
				}
			}
		}

		private XssProtectionMode _protectionMode;
		/// <summary>
		/// Protection mode.
		/// </summary>
		public XssProtectionMode ProtectionMode {
			get {
				return _protectionMode ??
					(_protectionMode = new XssProtectionMode(LookupColumnEntities.GetEntity("ProtectionMode")));
			}
		}

		#endregion

	}

	#endregion

}

