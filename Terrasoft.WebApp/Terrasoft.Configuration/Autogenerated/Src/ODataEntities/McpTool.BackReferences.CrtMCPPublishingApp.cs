namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: McpTool

	/// <exclude/>
	public class McpTool : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public McpTool(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "McpTool";
		}

		public McpTool(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "McpTool";
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
		/// Enabled.
		/// </summary>
		/// <remarks>
		/// Whether the tool is exposed in the server tool list.
		/// </remarks>
		public bool IsEnabled {
			get {
				return GetTypedColumnValue<bool>("IsEnabled");
			}
			set {
				SetColumnValue("IsEnabled", value);
			}
		}

		/// <summary>
		/// Annotations.
		/// </summary>
		/// <remarks>
		/// JSON annotations object per the MCP tool spec.
		/// </remarks>
		public string Annotations {
			get {
				return GetTypedColumnValue<string>("Annotations");
			}
			set {
				SetColumnValue("Annotations", value);
			}
		}

		/// <summary>
		/// Output schema.
		/// </summary>
		/// <remarks>
		/// JSON output schema (manually edited).
		/// </remarks>
		public string OutputSchema {
			get {
				return GetTypedColumnValue<string>("OutputSchema");
			}
			set {
				SetColumnValue("OutputSchema", value);
			}
		}

		/// <summary>
		/// Input schema.
		/// </summary>
		/// <remarks>
		/// JSON input schema (manually edited).
		/// </remarks>
		public string InputSchema {
			get {
				return GetTypedColumnValue<string>("InputSchema");
			}
			set {
				SetColumnValue("InputSchema", value);
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
		/// External tool name.
		/// </summary>
		/// <remarks>
		/// Tool name exposed to the AI platform (MCP name).
		/// </remarks>
		public string ExternalName {
			get {
				return GetTypedColumnValue<string>("ExternalName");
			}
			set {
				SetColumnValue("ExternalName", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Source code action.
		/// </summary>
		public string SourceCodeAction {
			get {
				return GetTypedColumnValue<string>("SourceCodeAction");
			}
			set {
				SetColumnValue("SourceCodeAction", value);
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
		public Guid McpServerId {
			get {
				return GetTypedColumnValue<Guid>("McpServerId");
			}
			set {
				SetColumnValue("McpServerId", value);
				_mcpServer = null;
			}
		}

		/// <exclude/>
		public string McpServerName {
			get {
				return GetTypedColumnValue<string>("McpServerName");
			}
			set {
				SetColumnValue("McpServerName", value);
				if (_mcpServer != null) {
					_mcpServer.Name = value;
				}
			}
		}

		private McpServer _mcpServer;
		/// <summary>
		/// MCP Server.
		/// </summary>
		/// <remarks>
		/// Parent server this tool belongs to.
		/// </remarks>
		public McpServer McpServer {
			get {
				return _mcpServer ??
					(_mcpServer = new McpServer(LookupColumnEntities.GetEntity("McpServer")));
			}
		}

		/// <exclude/>
		public Guid ToolSourceTypeId {
			get {
				return GetTypedColumnValue<Guid>("ToolSourceTypeId");
			}
			set {
				SetColumnValue("ToolSourceTypeId", value);
				_toolSourceType = null;
			}
		}

		/// <exclude/>
		public string ToolSourceTypeName {
			get {
				return GetTypedColumnValue<string>("ToolSourceTypeName");
			}
			set {
				SetColumnValue("ToolSourceTypeName", value);
				if (_toolSourceType != null) {
					_toolSourceType.Name = value;
				}
			}
		}

		private McpToolSourceType _toolSourceType;
		/// <summary>
		/// Source type.
		/// </summary>
		public McpToolSourceType ToolSourceType {
			get {
				return _toolSourceType ??
					(_toolSourceType = new McpToolSourceType(LookupColumnEntities.GetEntity("ToolSourceType")));
			}
		}

		/// <exclude/>
		public Guid BusinessProcessId {
			get {
				return GetTypedColumnValue<Guid>("BusinessProcessId");
			}
			set {
				SetColumnValue("BusinessProcessId", value);
				_businessProcess = null;
			}
		}

		/// <exclude/>
		public string BusinessProcessCaption {
			get {
				return GetTypedColumnValue<string>("BusinessProcessCaption");
			}
			set {
				SetColumnValue("BusinessProcessCaption", value);
				if (_businessProcess != null) {
					_businessProcess.Caption = value;
				}
			}
		}

		private SysSchema _businessProcess;
		/// <summary>
		/// Source process.
		/// </summary>
		/// <remarks>
		/// Business process this tool is based on (process schema).
		/// </remarks>
		public SysSchema BusinessProcess {
			get {
				return _businessProcess ??
					(_businessProcess = new SysSchema(LookupColumnEntities.GetEntity("BusinessProcess")));
			}
		}

		#endregion

	}

	#endregion

}

