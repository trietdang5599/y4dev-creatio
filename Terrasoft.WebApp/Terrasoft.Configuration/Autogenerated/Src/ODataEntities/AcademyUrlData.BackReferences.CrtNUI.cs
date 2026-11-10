namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: AcademyUrlData

	/// <exclude/>
	public class AcademyUrlData : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AcademyUrlData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AcademyUrlData";
		}

		public AcademyUrlData(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "AcademyUrlData";
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
		/// Use Lms documentation.
		/// </summary>
		public bool UseLmsDocumentation {
			get {
				return GetTypedColumnValue<bool>("UseLmsDocumentation");
			}
			set {
				SetColumnValue("UseLmsDocumentation", value);
			}
		}

		/// <summary>
		/// Configuration Version.
		/// </summary>
		public string ConfigurationVersion {
			get {
				return GetTypedColumnValue<string>("ConfigurationVersion");
			}
			set {
				SetColumnValue("ConfigurationVersion", value);
			}
		}

		/// <summary>
		/// Product Edition.
		/// </summary>
		public string ProductEdition {
			get {
				return GetTypedColumnValue<string>("ProductEdition");
			}
			set {
				SetColumnValue("ProductEdition", value);
			}
		}

		/// <summary>
		/// Context Help Id.
		/// </summary>
		public string ContextHelpId {
			get {
				return GetTypedColumnValue<string>("ContextHelpId");
			}
			set {
				SetColumnValue("ContextHelpId", value);
			}
		}

		/// <summary>
		/// Enable context help.
		/// </summary>
		public bool EnableContextHelp {
			get {
				return GetTypedColumnValue<bool>("EnableContextHelp");
			}
			set {
				SetColumnValue("EnableContextHelp", value);
			}
		}

		/// <summary>
		/// Lms Url.
		/// </summary>
		public string LMSUrl {
			get {
				return GetTypedColumnValue<string>("LMSUrl");
			}
			set {
				SetColumnValue("LMSUrl", value);
			}
		}

		/// <summary>
		/// Context Help Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

	}

	#endregion

}

