namespace Terrasoft.Configuration 
{
	using Terrasoft.Core;

	#region Interface: ICustomConfigurationScriptBuilder
	
	public interface ICustomConfigurationScriptBuilder
	{
		string BuildScript(UserConnection userConnection);
	}
	
	#endregion
	
}
