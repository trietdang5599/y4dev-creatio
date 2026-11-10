namespace Terrasoft.Configuration.RelationshipDesigner
{
	using Terrasoft.Core;
	using Terrasoft.Core.Entities.AsyncOperations;
	using Terrasoft.Core.Entities.AsyncOperations.Interfaces;
	using Terrasoft.Core.Factories;

	#region Class: DeleteRelationshipEntityAsyncOperation

	public class DeleteRelationshipEntityAsyncOperation : IEntityEventAsyncOperation
	{

		#region Methods: Public

		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			var relationshipDiagramManager = ClassFactory.Get<IRelationshipDiagramManager>(
				new ConstructorArgument("userConnection", userConnection));
			relationshipDiagramManager.DeleteEntityByRecordId(arguments.EntityId);
		}

		#endregion

	}

	#endregion
}

