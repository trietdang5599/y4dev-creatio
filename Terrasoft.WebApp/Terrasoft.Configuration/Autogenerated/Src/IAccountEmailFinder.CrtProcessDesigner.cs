namespace Terrasoft.Configuration.CrtProcessDesigner
{
	using Terrasoft.Core;

	public interface IAccountEmailFinder {
		string FindAccountEmailValue(UserConnection userConnection, object contactGuid);
	}
}
