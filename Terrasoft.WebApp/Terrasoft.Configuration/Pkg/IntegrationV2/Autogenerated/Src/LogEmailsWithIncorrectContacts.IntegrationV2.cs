namespace Terrasoft.Core.Process
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: LogEmailsWithIncorrectContactsMethodsWrapper

	/// <exclude/>
	public class LogEmailsWithIncorrectContactsMethodsWrapper : ProcessModel
	{

		public LogEmailsWithIncorrectContactsMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var emailTypeId = new Guid("E2831DEC-CFC0-DF11-B00F-001D60E938C6");
			var likeExpression = new ConcatQueryFunction(new QueryColumnExpressionCollection {
				Column.Parameter("%"), Column.SourceColumn("cc", "Number"), Column.Parameter("%")
			});
			Select select = new Select(UserConnection).Top(20)
				.Column("a", "Id")
			.From("Activity").As("a")
			.Where("a", "TypeId").IsEqual(Column.Parameter(emailTypeId))
			.And("a", "CreatedOn").IsGreater(Column.Const(DateTime.Now.AddMonths(-1)))
				.And().Not().Exists(
					new Select(UserConnection).Top(1)
						.Column(Column.Const(1))
					.From("ContactCommunication").As("cc")
					.Where("cc", "ContactId").IsEqual("a", "ContactId").And()
						.OpenBlock("a", "Sender").IsLike(likeExpression)
							.Or("a", "Recepient").IsLike(likeExpression)
							.Or("a", "CopyRecepient").IsLike(likeExpression)
							.Or("a", "BlindCopyRecepient").IsLike(likeExpression)
						.CloseBlock()
					) as Select;
			var logger = global::Common.Logging.LogManager.GetLogger("Common");
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var emailId = DBUtilities.GetColumnValue<Guid>(dataReader, "Id");
						logger.InfoFormat($"Email has incorrect contact: (id '{emailId}')");
					}
				}
			}
			return true;
		}

		#endregion

	}

	#endregion

}

