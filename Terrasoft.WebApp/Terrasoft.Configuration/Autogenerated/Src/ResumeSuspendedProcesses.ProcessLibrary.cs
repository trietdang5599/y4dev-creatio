namespace Terrasoft.Core.Process
{

	using global::Common.Logging;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: ResumeSuspendedProcessesMethodsWrapper

	/// <exclude/>
	public class ResumeSuspendedProcessesMethodsWrapper : ProcessModel
	{

		public ResumeSuspendedProcessesMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("PerformActionExecute", PerformActionExecute);
		}

		#region Methods: Private

		private bool PerformActionExecute(ProcessExecutingContext context) {
			Action<string, Exception> logEx = (string message, Exception e) =>
				ProcessLog.Error($"[{context.Process.Name}@{context.Process.UId}] {message}", e);
			Action<string> log = (string message) => logEx(message, null);
			log("Start");
			var userConnection = Get<UserConnection>("UserConnection");
			IProcessEngine processEngine = userConnection.ProcessEngine;
			var lastProcessId = Get<Guid>("LastProcessId");
			var minStartDate = Get<DateTime>("ParametersPage.MinStartDate");
			var skipLastNMinutes = Get<int>("ParametersPage.SkipLastNMinutes");
			DateTime maxStartDate = DateTime.UtcNow.AddMinutes(-1*skipLastNMinutes);
			var batchSize = Get<int>("ParametersPage.BatchSize");
			var processSchemaUId = Get<Guid>("ParametersPage.ProcessId");
			Guid processSchemaId = Guid.Empty;
			if (processSchemaUId.IsNotEmpty()) {
				processSchemaId = userConnection.ProcessSchemaManager.FindItemByUId(processSchemaUId).Id;
			}
			var select = (Select)new Select(userConnection).Top(batchSize)
					.Column("SPL", "Id").As("ProcessId")
				.From("SysProcessLog").As("SPL").WithHints(Hints.NoLock)
				.Where("SPL", "StatusId").IsEqual(Column.Parameter(new Guid("ED2AE277-B6E2-DF11-971B-001D60E938C6")))
					.And("SPL", "StartDate").IsGreaterOrEqual(Column.Parameter(minStartDate))
					.And("SPL", "StartDate").IsLessOrEqual(Column.Parameter(maxStartDate))
					.And("SPL", "Id").IsGreater(Column.Parameter(lastProcessId))
					.And().OpenBlock("SysSchemaId").IsEqual(Column.Parameter(processSchemaId))
						.Or(Column.Parameter(processSchemaId)).IsEqual(Column.Parameter(Guid.Empty)).CloseBlock()
					.And().Not().Exists(new Select(userConnection)
							.Column("SPEL", "Id")
						.From("SysProcessElementLog").As("SPEL").WithHints(Hints.NoLock)
						.Where("SPEL", "SysProcessId").IsEqual("SPL", "Id"))
				.OrderByAsc("SPL", "Id");
			var processesUIds = new List<Guid>(batchSize);
			using (DBExecutor executor = userConnection.EnsureDBConnection()) {
				using (System.Data.IDataReader reader = select.ExecuteReader(executor)) {
					while (reader.Read()) {
						processesUIds.Add(reader.GetColumnValue<Guid>("ProcessId"));
					}
				}
			}
			log($"Found {processesUIds.Count} processes to kickstart.");
			var completeBackgroundTokenMethodInfo = ReflectionUtilities.GetMethodInfo(typeof(ProcessComponentSet),
				"CompleteBackgroundToken", BindingFlags.Instance | BindingFlags.NonPublic);
			var onProcessFlowElementExecutedMethodInfo = ReflectionUtilities.GetMethodInfo(typeof(ProcessComponentSet),
				"OnProcessFlowElementExecuted", BindingFlags.Instance | BindingFlags.NonPublic);
			foreach (Guid processUId in processesUIds) {
				try {
					log($"Going to kickstart process {processUId}");
					lastProcessId = processUId;
					context.CancellationToken.ThrowIfCancellationRequested();
					Process process = processEngine.GetProcessByUId(processUId.ToString(), true);
					var backgroundTokens = (System.Collections.IEnumerable)process.GetPropertyValue("BackgroundTokens",
						BindingFlags.Instance | BindingFlags.NonPublic);
					bool hasNoBackgroundTokens = true;
					foreach (var token in backgroundTokens) {
						hasNoBackgroundTokens = false;
						var tokenId = token.GetType().GetProperty("Key").GetValue(token);
						completeBackgroundTokenMethodInfo.Invoke(process, new[] { tokenId });
						break;
					}
					if (hasNoBackgroundTokens) {
						string backgroundTokenName = FindFlowBackgroundTokenName(process);
						if (backgroundTokenName.IsNotNullOrEmpty()) {
							process.ShowExecutionPage = false;
							process.InternalContext.SenderName = backgroundTokenName;
							var activityAfterEventArgs = new ProcessActivityAfterEventArgs {
								Context = process.InternalContext,
								Result = true,
								FlowContextId = Guid.Empty
							};
							onProcessFlowElementExecutedMethodInfo.Invoke(process,
								new object[] { process, activityAfterEventArgs });
						}
					}
				} catch (Exception e) {
					logEx($"Error during starting of process {processUId}", e);
				}
			}
			Set("LastProcessId", lastProcessId);
			int iterationsCount = Get<int>("IterationsCount") + processesUIds.Count;
			Set("IterationsCount", iterationsCount);
			if (processesUIds.Count < batchSize || iterationsCount >= Get<int>("ParametersPage.MaxIterationsCount")) {
				Set("Continue", false);
				log("Finished.");
				return true;
			}
			log("Going to next batch.");
			return true;
		}

			private static FlowSchema FindFlowSchema(Process process) {
				PropertyInfo flowSchemaProperty = typeof(ProcessComponentSet).GetProperty("FlowSchema",
					BindingFlags.NonPublic | BindingFlags.Instance);
				FlowSchema flowSchemaInstance = (FlowSchema)flowSchemaProperty.GetValue(process);
				return flowSchemaInstance;
			}
			
			private static ILog _processLog;
			private static ILog ProcessLog {
				get {
					if (_processLog != null) {
						return _processLog;
					}
					_processLog = _processLog ?? LogManager.GetLogger("Process");
					return _processLog;
				}
			}
			
			private static readonly string[] _startElementNames = new [] {"SS", "STE", "SM", "SE"};
			
			private static IEnumerable<ProcessFlowElement> FindStartElements(Process process, FlowSchema flowSchema) {
				var startElements = flowSchema.FlowElements.Where(w => _startElementNames.Contains(w.BpmnElementName));
				foreach (FlowElement startElement in startElements) {
					if (process.FlowElements.TryGetValue(startElement.UId, out Collection<ProcessFlowElement> processFlowElements)) {
						var flowElement = processFlowElements.FirstOrDefault();
						if (flowElement != null) {
							yield return flowElement;
						}
					}
				}
			}
			
			private static string FindFlowBackgroundTokenName(Process process) {
				FlowSchema flowSchema = FindFlowSchema(process);
				var startEvents = FindStartElements(process, flowSchema).ToList();
				Type backgroundTokenType = Type.GetType("Terrasoft.Core.Process.FlowBackgroundToken, Terrasoft.Core");
				var backgroundTokens = flowSchema.FlowElements.Where(w => w.GetType() == backgroundTokenType).ToList();
				foreach (var backgroundToken in backgroundTokens) {
					string name = (string)backgroundToken.GetPropertyValue("Name");
					if (startEvents.Any(s => s.Name == name.Replace("FlowBackgroundToken_", ""))) {
						return name;
					}
				}
				return null;
			}

		#endregion

	}

	#endregion

}

