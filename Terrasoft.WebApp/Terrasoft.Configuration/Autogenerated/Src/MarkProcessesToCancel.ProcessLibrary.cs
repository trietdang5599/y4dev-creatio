namespace Terrasoft.Core.Process
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: MarkProcessesToCancelMethodsWrapper

	/// <exclude/>
	public class MarkProcessesToCancelMethodsWrapper : ProcessModel
	{

		public MarkProcessesToCancelMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScheduleCancellationJobScriptTaskExecute", ScheduleCancellationJobScriptTaskExecute);
			AddScriptTaskMethod("ReadProcessesToMarkScriptTaskExecute", ReadProcessesToMarkScriptTaskExecute);
			AddScriptTaskMethod("MarkProcessesToCancelScriptTaskExecute", MarkProcessesToCancelScriptTaskExecute);
		}

		#region Methods: Private

		private bool ScheduleCancellationJobScriptTaskExecute(ProcessExecutingContext context) {
			ProcessCancellationHelper.ScheduleCancellationJob(UserConnection);
			return true;
		}

		private bool ReadProcessesToMarkScriptTaskExecute(ProcessExecutingContext context) {
			var filesCollection = Get<CompositeObjectList<CompositeObject>>("FilesCollection");
			var helper = new ProcessCancellationHelper(UserConnection, filesCollection, CreateTempFile,
				context.Process.UId);
			var serializedFilters = Get<string>("SerializedFilters");
			var serializedSortingColumns = Get<string>("SerializedSortingColumns");
			var chunkSize = Get<int>("ChunkSize");
			var recordsOffset = Get<int>("RecordsOffset");
			var result = helper.WriteProcessIdsToFile(serializedFilters, serializedSortingColumns,
				chunkSize, recordsOffset, context.CancellationToken);
			Set("AllProcessIdsWritten", result.IsAllValuesProcessed);
			Set("RecordsOffset", recordsOffset + result.WrittenValues);
			Set("FilesCollection", filesCollection);
			return true;
		}

		private bool MarkProcessesToCancelScriptTaskExecute(ProcessExecutingContext context) {
			var filesCollection = Get<CompositeObjectList<CompositeObject>>("FilesCollection");
			var helper = new ProcessCancellationHelper(UserConnection, filesCollection, CreateTempFile,
				context.Process.UId);
			var chunkSize = Get<int>("ChunkSize");
			int recordsProcessed = helper.MarkProcessesToCancel(chunkSize, context.CancellationToken);
			Set("RecordsProcessed", recordsProcessed);
			return true;
		}

		#endregion

	}

	#endregion

}

