  namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.Factories;
	 
	#region Interface: IServerInfoProvider

	/// <summary>
	/// Provides utility methods to get server info.
	/// </summary>
	public interface IServerInfoProvider
	{

		#region Properties : Public

		bool IsLinux { get; }

		bool IsWindows { get; }

		#endregion

	}

	#endregion
	 
	 
	#region Class: ServerInfoProvider

	/// <summary>
	/// Implementation of <see cref="IServerInfoProvider"/>.
	/// </summary>
	[DefaultBinding(typeof(IServerInfoProvider))]
	public class ServerInfoProvider : IServerInfoProvider
	{

		#region Fields: Private

		private static readonly PlatformID _currentPlatform = Environment.OSVersion.Platform;
		
		#endregion

		#region Properties: Public
		
		public bool IsLinux {
			get {
				return _currentPlatform == PlatformID.Unix || _currentPlatform == PlatformID.MacOSX;
			}
		}

		public bool IsWindows {
			get {
				return !IsLinux;
			}
		}

		#endregion

	}

	#endregion

}
