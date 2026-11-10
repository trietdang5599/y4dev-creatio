namespace Terrasoft.Configuration
{
	using System;
	using System.IO;
	using Terrasoft.Configuration.FileUpload;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Configuration.ESN;

	#region Class: FeedFileRepository

	[DefaultBinding(typeof(IFeedFileRepository))]
	public class FeedFileRepository: FileRepository, IFeedFileRepository
	{

		#region Fields: Private

		private FeedFileLoader _feedFileLoader;

		#endregion

		#region Fields: Private

		private FeedFileLoader FeedFileLoader => _feedFileLoader ?? (_feedFileLoader = ClassFactory.Get<FeedFileLoader>(new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of type <see cref="FeedFileRepository"/>.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public FeedFileRepository(UserConnection userConnection) : base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads file.
		/// </summary>
		/// <param name="entitySchemaUId">Entity schema instance UId.</param>
		/// <param name="fileId">File identifier.</param>
		/// <param name="binaryWriter">File content binary writer.</param>
		/// <returns>Loaded file information.</returns>
		public override IFileUploadInfo LoadFile(Guid entitySchemaUId, Guid fileId, BinaryWriter binaryWriter) {
			return FeedFileLoader.LoadFile(entitySchemaUId, fileId, binaryWriter);
		}

		#endregion

	}

	#endregion
}

