namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: ApplicationSection

	/// <exclude/>
	public class ApplicationSection : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ApplicationSection(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ApplicationSection";
		}

		public ApplicationSection(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ApplicationSection";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Application Id.
		/// </summary>
		public Guid ApplicationId {
			get {
				return GetTypedColumnValue<Guid>("ApplicationId");
			}
			set {
				SetColumnValue("ApplicationId", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
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
		/// Schema type.
		/// </summary>
		public string SchemaType {
			get {
				return GetTypedColumnValue<string>("SchemaType");
			}
			set {
				SetColumnValue("SchemaType", value);
			}
		}

		/// <summary>
		/// Section schema UId.
		/// </summary>
		public Guid SectionSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SectionSchemaUId");
			}
			set {
				SetColumnValue("SectionSchemaUId", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Logo id.
		/// </summary>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// ModifiedOn.
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
		/// Icon background.
		/// </summary>
		/// <remarks>
		/// Icon background.
		/// </remarks>
		public string IconBackground {
			get {
				return GetTypedColumnValue<string>("IconBackground");
			}
			set {
				SetColumnValue("IconBackground", value);
			}
		}

		/// <summary>
		/// PackageId.
		/// </summary>
		public Guid PackageId {
			get {
				return GetTypedColumnValue<Guid>("PackageId");
			}
			set {
				SetColumnValue("PackageId", value);
			}
		}

		/// <summary>
		/// Application client type.
		/// </summary>
		public Guid ClientTypeId {
			get {
				return GetTypedColumnValue<Guid>("ClientTypeId");
			}
			set {
				SetColumnValue("ClientTypeId", value);
			}
		}

		#endregion

	}

	#endregion

}

