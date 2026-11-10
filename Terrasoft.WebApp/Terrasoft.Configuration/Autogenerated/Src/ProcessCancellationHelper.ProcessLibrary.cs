namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.ServiceModelContract;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions;

	#region Class: ProcessCancellationHelper

	/// <summary>
	/// Represents a set of utility methods to cancel process execution.
	/// </summary>
	public class ProcessCancellationHelper
	{

		#region Constants: Private

		private const int MaximumFileSize = 5_000_000;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly CompositeObjectList<CompositeObject> _filesCollection;
		private readonly Func<IFile> _fileFactory;
		private readonly Guid _processId;
		private readonly DataContractQueryExecutorFactory _executorFactory;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessCancellationHelper"/> type.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="filesCollection">An instance of the <see cref="CompositeObjectList{CompositeObject}"/>
		/// to store files in.</param>
		/// <param name="fileFactory">Factory method used to get an instance of the <see cref="IFile"/> implementing
		/// type.</param>
		/// <param name="processId">Process identifier.</param>
		/// <param name="dataContractQueryExecutorFactory">Data contract query executor factory.</param>
		public ProcessCancellationHelper(UserConnection userConnection,
				CompositeObjectList<CompositeObject> filesCollection, Func<IFile> fileFactory, Guid processId,
				DataContractQueryExecutorFactory dataContractQueryExecutorFactory) {
			_userConnection = userConnection;
			_filesCollection = filesCollection;
			_fileFactory = fileFactory;
			_processId = processId;
			_executorFactory = dataContractQueryExecutorFactory;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessCancellationHelper" /> type.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="filesCollection">An instance of the <see cref="CompositeObjectList{CompositeObject}"/>
		/// to store files in.</param>
		/// <param name="fileFactory">Factory method used to get an instance of the <see cref="IFile"/> implementing
		/// type.</param>
		/// <param name="processId">Process identifier.</param>
		public ProcessCancellationHelper(UserConnection userConnection,
				CompositeObjectList<CompositeObject> filesCollection, Func<IFile> fileFactory, Guid processId)
			: this(userConnection, filesCollection, fileFactory, processId, 
			ClassFactory.Get<DataContractQueryExecutorFactory>()){
		}

		#endregion

		#region Methods: Private

		private static List<Guid> ReadIdList(IFile file) {
			var ids = new List<Guid>();
			using (Stream stream = file.Read()) {
				using (var streamReader = new StreamReader(stream, Encoding.UTF8)) {
					while (!streamReader.EndOfStream) {
						string idString = streamReader.ReadLine();
						if (string.IsNullOrWhiteSpace(idString)) {
							continue;
						}
						ids.Add(Guid.Parse(idString));
					}
				}
			}
			return ids;
		}

		private IFile CreateFileToWrite() {
			IFile file = _fileFactory();
			file.Name = $"RecordsToUpdate_{_filesCollection.Count}";
			_filesCollection.Add(new CompositeObject {
				["File"] = file.FileLocator
			});
			return file;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules the process cancellation job.
		/// <param name="userConnection">User connection.</param>
		/// </summary>
		public static void ScheduleCancellationJob(UserConnection userConnection) {
			BatchProcessCancellationJob.Register(userConnection);
		}

		/// <summary>
		/// Reads process Ids and saves them to file.
		/// </summary>
		/// <param name="serializedFilters">Serialized filters config.</param>
		/// <param name="serializedSortingColumns">Serialized sorting columns config.</param>
		/// <param name="chunkSize">Chunk size.</param>
		/// <param name="recordsOffset">Records offset.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <returns>How many processes was read.</returns>
		public WritePrimaryColumnValuesResult WriteProcessIdsToFile(string serializedFilters,
				string serializedSortingColumns, int chunkSize, int recordsOffset,
				CancellationToken cancellationToken) {
			cancellationToken.ThrowIfCancellationRequested();
			IFile file = CreateFileToWrite();
			var dataContractQuery = new DataContractQuery {
				SchemaName = "VwSysProcessLog",
				SerializedFilters = serializedFilters,
				SerializedSortingColumns = serializedSortingColumns,
				SkipRecords = recordsOffset,
				ExcludedPrimaryColumnValues = new [] { _processId }
			};
			IDataContractQueryExecutor executor = _executorFactory(_userConnection);
			return executor.WritePrimaryColumnValues(new WritePrimaryColumnValuesArguments {
				File = file,
				DataContractQuery = dataContractQuery,
				ChunkSize = chunkSize,
				CancellationToken = cancellationToken,
				MaximumFileSize = MaximumFileSize
			});
		}

		/// <summary>
		/// Marks processes to cancel.
		/// </summary>
		/// <param name="chunkSize">Chunk size.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <returns>How many processes was marked.</returns>
		public int MarkProcessesToCancel(int chunkSize, CancellationToken cancellationToken) {
			IFile file = _filesCollection
				.Select(c => _userConnection.GetFile(c["File"] as IFileLocator))
				.FirstOrDefault(f => f.Exists);
			if (file == null) {
				return 0;
			}
			int markedCount = 0;
			List<Guid> idList = ReadIdList(file);
			IProcessExecutor processExecutor = _userConnection.ProcessEngine.ProcessExecutor;
			foreach (IEnumerable<Guid> chunk in idList.SplitOnChunks(chunkSize)) {
				List<Guid> chunkList = chunk.ToList();
				cancellationToken.ThrowIfCancellationRequested();
				processExecutor.MarkProcessesToCancel(chunkList, cancellationToken);
				markedCount += chunkList.Count;
			}
			file.Delete();
			return markedCount;
		}

		#endregion

	}

	#endregion

}

