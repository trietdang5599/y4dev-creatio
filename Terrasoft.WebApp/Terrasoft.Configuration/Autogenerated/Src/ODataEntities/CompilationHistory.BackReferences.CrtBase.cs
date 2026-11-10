namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: CompilationHistory

	/// <exclude/>
	public class CompilationHistory : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CompilationHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CompilationHistory";
		}

		public CompilationHistory(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CompilationHistory";
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
		/// Errors or warnings.
		/// </summary>
		public string ErrorsWarnings {
			get {
				return GetTypedColumnValue<string>("ErrorsWarnings");
			}
			set {
				SetColumnValue("ErrorsWarnings", value);
			}
		}

		/// <summary>
		/// Result.
		/// </summary>
		public bool Result {
			get {
				return GetTypedColumnValue<bool>("Result");
			}
			set {
				SetColumnValue("Result", value);
			}
		}

		/// <summary>
		/// Project name.
		/// </summary>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
			}
		}

		/// <summary>
		/// Duration in seconds.
		/// </summary>
		public int DurationInSeconds {
			get {
				return GetTypedColumnValue<int>("DurationInSeconds");
			}
			set {
				SetColumnValue("DurationInSeconds", value);
			}
		}

		/// <summary>
		/// ConfActivityLog.
		/// </summary>
		public Guid ConfActivityLog {
			get {
				return GetTypedColumnValue<Guid>("ConfActivityLog");
			}
			set {
				SetColumnValue("ConfActivityLog", value);
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
		public Guid StartedById {
			get {
				return GetTypedColumnValue<Guid>("StartedById");
			}
			set {
				SetColumnValue("StartedById", value);
				_startedBy = null;
			}
		}

		/// <exclude/>
		public string StartedByName {
			get {
				return GetTypedColumnValue<string>("StartedByName");
			}
			set {
				SetColumnValue("StartedByName", value);
				if (_startedBy != null) {
					_startedBy.Name = value;
				}
			}
		}

		private SysAdminUnit _startedBy;
		/// <summary>
		/// Started by.
		/// </summary>
		public SysAdminUnit StartedBy {
			get {
				return _startedBy ??
					(_startedBy = new SysAdminUnit(LookupColumnEntities.GetEntity("StartedBy")));
			}
		}

		#endregion

	}

	#endregion

}

