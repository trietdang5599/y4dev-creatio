namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: MockableServiceUrl

	/// <exclude/>
	public class MockableServiceUrl : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MockableServiceUrl(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MockableServiceUrl";
		}

		public MockableServiceUrl(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "MockableServiceUrl";
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
		/// HttpMethod.
		/// </summary>
		public string HttpMethod {
			get {
				return GetTypedColumnValue<string>("HttpMethod");
			}
			set {
				SetColumnValue("HttpMethod", value);
			}
		}

		/// <summary>
		/// Url.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <summary>
		/// ResponseCode.
		/// </summary>
		public int ResponseCode {
			get {
				return GetTypedColumnValue<int>("ResponseCode");
			}
			set {
				SetColumnValue("ResponseCode", value);
			}
		}

		/// <summary>
		/// ResponseBody.
		/// </summary>
		public string ResponseBody {
			get {
				return GetTypedColumnValue<string>("ResponseBody");
			}
			set {
				SetColumnValue("ResponseBody", value);
			}
		}

		/// <summary>
		/// ExecCount.
		/// </summary>
		public int ExecCount {
			get {
				return GetTypedColumnValue<int>("ExecCount");
			}
			set {
				SetColumnValue("ExecCount", value);
			}
		}

		/// <summary>
		/// RequestBodyPattern.
		/// </summary>
		public string RequestBodyPattern {
			get {
				return GetTypedColumnValue<string>("RequestBodyPattern");
			}
			set {
				SetColumnValue("RequestBodyPattern", value);
			}
		}

		/// <summary>
		/// RequestBodyAntiPattern.
		/// </summary>
		public string RequestBodyAntiPattern {
			get {
				return GetTypedColumnValue<string>("RequestBodyAntiPattern");
			}
			set {
				SetColumnValue("RequestBodyAntiPattern", value);
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

