namespace Terrasoft.Configuration.ServiceSchema
{
	using System.Collections.Generic;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Services;

	#region Interface: IServiceSchemaClient

	public interface IServiceSchemaClient
	{
		IServiceClientResponse Execute(
			UserConnection userConnection, 
			string serviceName, 
			string methodName, 
			Dictionary<string, object> parameters);
	}

	#endregion
	
	#region Class: ServiceSchemaClient

	[DefaultBinding(typeof(IServiceSchemaClient))]
	public class ServiceSchemaClient : IServiceSchemaClient
	{
		public IServiceClientResponse Execute(UserConnection userConnection, string serviceName, string methodName,
			Dictionary<string, object> parameters) {
			var manager =
				(Terrasoft.Services.ServiceSchemaManager)userConnection.GetSchemaManager("ServiceSchemaManager");
			var serviceSchemaInstance = manager.GetInstanceByName(serviceName);
			var serviceClient = serviceSchemaInstance.CreateServiceClient(userConnection);
			var serviceRequest = serviceClient.CreateRequest(methodName);
			serviceRequest.RequestParameters = parameters;
			return serviceClient.Execute(serviceRequest);
		}
	}

	#endregion

}
