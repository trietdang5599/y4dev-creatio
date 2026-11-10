namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Configuration.FileUpload;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;
	using Terrasoft.Web.Http.Abstractions;

	#region Class: FileApiService

	[DefaultServiceRoute, SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class FileApiService : BaseService, IReadOnlySessionState
	{

		#region Constructors: Public

		public FileApiService():base() {
			_fileUploadInfoFactory = GetFileUploadInfo;
		}

		public FileApiService(UserConnection userConnection, FileRepository fileRepository,
				Func<Stream, IFileUploadInfo> fileUploadInfoFactory,
				FileSchemaProvider fileSchemaProvider) : base(userConnection) {
			_fileSchemaProvider = fileSchemaProvider;
			_fileRepository = fileRepository;
			_fileUploadInfoFactory = fileUploadInfoFactory;
		}
		
		#endregion
		
		#region Properties: Private

		private FileRepository _fileRepository;

		/// <summary>
		/// File manager.
		/// </summary>
		private FileRepository FileRepository {
			get {
				if (_fileRepository == null) {
					_fileRepository = ClassFactory.Get<FileRepository>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _fileRepository;
			}
		}

		private FileSchemaProvider _fileSchemaProvider;

		/// <summary>
		/// File schema provider.
		/// </summary>
		private FileSchemaProvider FileSchemaProvider {
			get {
				if (_fileSchemaProvider == null) {
					_fileSchemaProvider = ClassFactory.Get<FileSchemaProvider>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _fileSchemaProvider;
			}
		}

		private readonly Func<Stream, IFileUploadInfo> _fileUploadInfoFactory;
		
		#endregion

		#region Methods: Private

		private IFileUploadInfo GetFileUploadInfo(Stream fileContent) {
			IFileUploadInfo fileUploadInfo = ClassFactory.Get<FileUploadInfo>(
				new ConstructorArgument("fileContent", fileContent),
#if NETSTANDARD2_0 // TODO CRM-46497
				new ConstructorArgument("request", HttpContext.Current.Request),
#else
				new ConstructorArgument("request", new System.Web.HttpRequestWrapper(System.Web.HttpContext.Current.Request)),
#endif
				new ConstructorArgument("storage", UserConnection.Workspace.ResourceStorage));
			return fileUploadInfo;
		}

		#endregion

		#region Methods: Public
		
		/// <summary>
		/// Uploads file.
		/// </summary>
		/// <param name="fileContent">File data stream.</param>
		/// <returns>Upload result.</returns>
		[Obsolete("7.19.0| Use \"UploadFile\" instead")]
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Upload", ResponseFormat = WebMessageFormat.Json)]
		public string Upload(Stream fileContent) {
			IFileUploadInfo fileUploadInfo = _fileUploadInfoFactory(fileContent);
			if (FileRepository.UploadFile(fileUploadInfo)) {
				return "Ok";
			}
			return string.Empty;
		}
		
		/// <summary>
		/// Uploads file.
		/// </summary>
		/// <param name="fileContent">File data stream.</param>
		/// <returns>Upload result.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UploadFile(Stream fileContent) {
			IFileUploadInfo fileUploadInfo = _fileUploadInfoFactory(fileContent);
			var response = new ConfigurationServiceResponse();
			try {
				response.Success = FileRepository.UploadFile(fileUploadInfo);
			} catch (Exception e) {
				response.Exception = e;
				response.Success = false;
			}
			return response;
		}

		/// <summary>
		/// Uploads file and links it with the specified record by creating a file attachment.
		/// </summary>
		/// <param name="fileContent">File data stream.</param>
		/// <returns>Upload result.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UploadAndAttachFile(Stream fileContent) {
			IFileUploadInfo fileUploadInfo = _fileUploadInfoFactory(fileContent);
			var response = new ConfigurationServiceResponse();
			try {
				response.Success = FileRepository.UploadAndAttachFile(fileUploadInfo);
			} catch (Exception e) {
				response.Exception = e;
				response.Success = false;
			}
			return response;
		}

		/// <summary>
		/// Retrieves the list of File schema successors.
		/// </summary>
		/// <returns>List of File schemas.</returns>
		[OperationContract]
		[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public List<FileSchemaInfo> GetAllFileSchemas() {
			return FileSchemaProvider.GetAllSchemas();
		}

		#endregion

	}

	#endregion

}
