namespace IntegrationV2.Files.cs.Domains.MeetingDomain.Client
{
	using IntegrationV2.Files.cs.Domains.MeetingDomain.Logger;
	using Microsoft.Exchange.WebServices.Data;

	#region Class: ExchangeTraceListener

	/// <summary>
	/// Implementation of <see cref="ITraceListener"/> for Exchange service.
	/// </summary>
	internal class ExchangeTraceListener : ITraceListener
	{

		#region Fields: Private

		private readonly ICalendarLogger _log;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="log"><see cref="ICalendarLogger"/> implementation instance.</param>
		public ExchangeTraceListener(ICalendarLogger log) {
			_log = log;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="ITraceListener.Trace(string, string)"/>
		public void Trace(string traceType, string traceMessage) {
			_log?.LogInfo($"ExchangeServiceTrace [{traceType}]: {traceMessage}");
		}

		#endregion

	}

	#endregion

}
