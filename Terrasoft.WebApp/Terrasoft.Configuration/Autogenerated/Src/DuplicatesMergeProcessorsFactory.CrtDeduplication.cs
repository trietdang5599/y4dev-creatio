namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Reflection;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: IDuplicatesSchemaMergeProcessor

	/// <summary>
	/// Interface for base merge processor class.
	/// </summary>
	public interface IDuplicatesSchemaMergeProcessor
	{
		/// <summary>
		/// Master entity schema name.
		/// /// </summary>
		string EntitySchemaName { get;}

		/// <summary>
		/// Process merge actions.
		/// </summary>
		/// <param name="duplicates">Duplicates collection.</param>
		/// <param name="goldenRecord">Gold record Id</param>
		/// <param name="dbExecutor">DBExecutor instance.</param>
		void Process(List<Guid> duplicates, Guid goldenRecord, DBExecutor dbExecutor);
	}
	
	#endregion
	
	#region Interface: IDuplicatesSchemaMergePreProcessor

	public interface IDuplicatesSchemaMergePreProcessor : IDuplicatesSchemaMergeProcessor
	{
	}
	
	#endregion
	
	#region Interface: IDuplicatesSchemaMergePostProcessor

	public interface IDuplicatesSchemaMergePostProcessor : IDuplicatesSchemaMergeProcessor
	{
	}
	
	#endregion

	#region Interface: IDuplicatesMergeProcessorsFactory

	public interface IDuplicatesMergeProcessorsFactory
	{
		ICollection<IDuplicatesSchemaMergePreProcessor> GetPreProcessors(string schemaName);

		ICollection<IDuplicatesSchemaMergePostProcessor> GetPostProcessors(string schemaName);
	}

	#endregion

	#region Class: DuplicatesMergeProcessorsFactory
	
	/// <summary>
	/// Implement merge preprocessing and postprocessing actions. 
	/// </summary>
	[DefaultBinding(typeof(IDuplicatesMergeProcessorsFactory))]
	public class DuplicatesMergeProcessorsFactory: IDuplicatesMergeProcessorsFactory
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Methods: Private
		
		private ICollection<Type> GetTypes(Type baseType) {
			var workspaceTypeProvider = ClassFactory.Get<IWorkspaceTypeProvider>();
			return workspaceTypeProvider.GetTypes().Where(baseType.IsAssignableFrom).ToList();
		}

		private ICollection<T> GetProcessors<T>(string schemaName)
			where T : class {
			var instances = new Collection<T>();
			Type baseType = typeof(T);
			ICollection<Type> types = GetTypes(baseType);
			foreach (Type type in types) {
				if (!type.IsInterface && ClassFactory.HasBinding(typeof(T), type.Name)) {
					T handler = ClassFactory.Get<T>(type.Name);
					if (handler.TryGetPropertyValue("EntitySchemaName", out object entitySchemaName) &&
						(string)entitySchemaName == schemaName) {
						instances.Add(handler);
					}
				}
			}
			return instances;
		}
		
		#endregion

		#region Constructors: Public

		public DuplicatesMergeProcessorsFactory(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns collection of registered preprocessor classes.
		/// </summary>
		/// <param name="schemaName">Master schema name.</param>
		/// <returns>IDuplicatesSchemaMergePreProcessor class collection.</returns>
		public ICollection<IDuplicatesSchemaMergePreProcessor> GetPreProcessors(string schemaName) {
			return GetProcessors<IDuplicatesSchemaMergePreProcessor>(schemaName);
		}

		/// <summary>
		/// Returns collection of registered postprocessor classes.
		/// </summary>
		/// <param name="schemaName">Master schema name.</param>
		/// <returns>IDuplicatesSchemaMergePostProcessor class collection.</returns>
		public ICollection<IDuplicatesSchemaMergePostProcessor> GetPostProcessors(string schemaName) {
			return GetProcessors<IDuplicatesSchemaMergePostProcessor>(schemaName);
		}

		#endregion

	}
	
	#endregion
}
