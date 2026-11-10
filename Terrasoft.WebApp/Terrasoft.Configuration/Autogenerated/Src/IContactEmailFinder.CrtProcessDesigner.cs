namespace Terrasoft.Configuration.CrtProcessDesigner
{
	using Terrasoft.Core;

	public interface IContactEmailFinder {
		string FindContactEmailValue(UserConnection userConnection, object contactGuid);
	}
}
