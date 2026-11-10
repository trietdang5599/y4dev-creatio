namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: SysTranslationEventListener

	[EntityEventListener(SchemaName = "SysTranslation")]
	public class SysTranslationEventListener : BaseEntityEventListener
	{

		#region Fields

		private readonly string _keyColumnName = "Key";

		#endregion

		#region Methods: Private

		private bool GetIsRecordExists(UserConnection userConnection, string key) {
			var select = 
				new Select(userConnection)
					.Column(Func.Count(Column.Parameter(1)))
				.From("SysTranslation");
			if (userConnection.DBEngine.DBEngineType == DBEngineType.PostgreSql) {
				select.Where(Func.Upper(_keyColumnName))
					.IsEqual(Func.Upper(Column.Parameter(key)));
			} else {
				select.Where(_keyColumnName)
					.IsEqual(Column.Parameter(key));
			}
			return select.ExecuteScalar<int>() > 0;
		}

		#endregion

		#region Methods: Public

		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			var key = entity.GetTypedColumnValue<string>("Key");
			var recordExits = GetIsRecordExists(userConnection, key);
			if (recordExits) {
				throw new TranslationKeyAlreadyExistsException(key);
			}
			base.OnInserting(sender, e);
		}

		#endregion

	}

	#endregion

	#region Class: TranslationKeyAlreadyExistsException

	public class TranslationKeyAlreadyExistsException: Exception
	{

		#region Class: Constructors

		public TranslationKeyAlreadyExistsException(string translationKey)
		: base($"Translation key '{translationKey}' already exists") { }

		#endregion

	}

	#endregion

}
