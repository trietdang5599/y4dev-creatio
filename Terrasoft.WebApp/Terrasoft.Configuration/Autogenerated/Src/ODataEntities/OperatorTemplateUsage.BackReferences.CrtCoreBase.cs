namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: OperatorTemplateUsage

	/// <exclude/>
	public class OperatorTemplateUsage : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OperatorTemplateUsage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OperatorTemplateUsage";
		}

		public OperatorTemplateUsage(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OperatorTemplateUsage";
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
		/// UsageCount.
		/// </summary>
		/// <remarks>
		/// Number of times the template was used by the operator.
		/// </remarks>
		public int UsageCount {
			get {
				return GetTypedColumnValue<int>("UsageCount");
			}
			set {
				SetColumnValue("UsageCount", value);
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
		public Guid TemplateId {
			get {
				return GetTypedColumnValue<Guid>("TemplateId");
			}
			set {
				SetColumnValue("TemplateId", value);
				_template = null;
			}
		}

		/// <exclude/>
		public string TemplateName {
			get {
				return GetTypedColumnValue<string>("TemplateName");
			}
			set {
				SetColumnValue("TemplateName", value);
				if (_template != null) {
					_template.Name = value;
				}
			}
		}

		private EmailTemplate _template;
		/// <summary>
		/// Template.
		/// </summary>
		public EmailTemplate Template {
			get {
				return _template ??
					(_template = new EmailTemplate(LookupColumnEntities.GetEntity("Template")));
			}
		}

		/// <exclude/>
		public Guid OperatorId {
			get {
				return GetTypedColumnValue<Guid>("OperatorId");
			}
			set {
				SetColumnValue("OperatorId", value);
				_operator = null;
			}
		}

		/// <exclude/>
		public string OperatorName {
			get {
				return GetTypedColumnValue<string>("OperatorName");
			}
			set {
				SetColumnValue("OperatorName", value);
				if (_operator != null) {
					_operator.Name = value;
				}
			}
		}

		private SysAdminUnit _operator;
		/// <summary>
		/// Operator.
		/// </summary>
		/// <remarks>
		/// Id of Operator.
		/// </remarks>
		public SysAdminUnit Operator {
			get {
				return _operator ??
					(_operator = new SysAdminUnit(LookupColumnEntities.GetEntity("Operator")));
			}
		}

		#endregion

	}

	#endregion

}

