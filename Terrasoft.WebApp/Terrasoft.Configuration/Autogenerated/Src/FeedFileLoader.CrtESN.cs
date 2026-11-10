namespace Terrasoft.Configuration.ESN
{
	using System;
	using Terrasoft.Configuration.FileLoad;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: FeedFileLoader

	public class FeedFileLoader : FileLoader
	{
		#region Constants: Private

		private readonly IEsnFileRepository _fileRepository;

		#endregion

 		#region Constructors: Public

		/// <summary>
		/// Creates a new instance of the <see cref="FeedFileLoader"/> type.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public FeedFileLoader(UserConnection userConnection) : base(userConnection) {
			var userConnectionArgument = new ConstructorArgument("userConnection", userConnection);
			_fileRepository = ClassFactory.Get<IEsnFileRepository>(userConnectionArgument);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc cref="FileLoader.CheckReadFileAccess(EntitySchema, Guid)"/>
		protected override bool CheckReadFileAccess(EntitySchema entitySchema, Guid fileId) {
			return _fileRepository.CheckReadFileAccess(entitySchema, fileId);
		}

		#endregion

	}

	#endregion

}

