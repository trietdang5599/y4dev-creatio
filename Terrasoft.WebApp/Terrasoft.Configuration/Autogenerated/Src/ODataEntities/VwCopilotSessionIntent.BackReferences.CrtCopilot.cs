namespace Terrasoft.Configuration.OData
{

	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.Extensions;

	#region Class: VwCopilotSessionIntent

	/// <exclude/>
	public class VwCopilotSessionIntent : Terrasoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwCopilotSessionIntent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwCopilotSessionIntent";
		}

		public VwCopilotSessionIntent(Terrasoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwCopilotSessionIntent";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Total Tokens.
		/// </summary>
		public int TotalTokens {
			get {
				return GetTypedColumnValue<int>("TotalTokens");
			}
			set {
				SetColumnValue("TotalTokens", value);
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
		/// Total Actions.
		/// </summary>
		public int TotalActions {
			get {
				return GetTypedColumnValue<int>("TotalActions");
			}
			set {
				SetColumnValue("TotalActions", value);
			}
		}

		/// <exclude/>
		public Guid IntentId {
			get {
				return GetTypedColumnValue<Guid>("IntentId");
			}
			set {
				SetColumnValue("IntentId", value);
				_intent = null;
			}
		}

		/// <exclude/>
		public string IntentCaption {
			get {
				return GetTypedColumnValue<string>("IntentCaption");
			}
			set {
				SetColumnValue("IntentCaption", value);
				if (_intent != null) {
					_intent.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _intent;
		/// <summary>
		/// Skill.
		/// </summary>
		public VwSysSchemaInfo Intent {
			get {
				return _intent ??
					(_intent = new VwSysSchemaInfo(LookupColumnEntities.GetEntity("Intent")));
			}
		}

		/// <exclude/>
		public Guid CopilotSessionId {
			get {
				return GetTypedColumnValue<Guid>("CopilotSessionId");
			}
			set {
				SetColumnValue("CopilotSessionId", value);
				_copilotSession = null;
			}
		}

		/// <exclude/>
		public string CopilotSessionTitle {
			get {
				return GetTypedColumnValue<string>("CopilotSessionTitle");
			}
			set {
				SetColumnValue("CopilotSessionTitle", value);
				if (_copilotSession != null) {
					_copilotSession.Title = value;
				}
			}
		}

		private CopilotSessionEnt _copilotSession;
		/// <summary>
		/// Creatio.ai Session.
		/// </summary>
		public CopilotSessionEnt CopilotSession {
			get {
				return _copilotSession ??
					(_copilotSession = new CopilotSessionEnt(LookupColumnEntities.GetEntity("CopilotSession")));
			}
		}

		#endregion

	}

	#endregion

}

