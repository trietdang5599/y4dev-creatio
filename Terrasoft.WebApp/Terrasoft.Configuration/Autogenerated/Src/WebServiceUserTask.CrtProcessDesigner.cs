namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.IO;
	using System.Net;
	using System.Xml;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.UI.WebControls.Controls;

	#region Class: WebServiceUserTask

	/// <exclude/>
	public partial class WebServiceUserTask
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (ServiceUrl == Guid.Empty || string.IsNullOrEmpty(ServiceMethod)) {
				return true;
			}
			string serviceUrl = (new Select(UserConnection)
				.Column("URL")
				.From("WebServiceURL")
				.Where("Id").IsEqual(new QueryParameter("Id", ServiceUrl)) as Select)
				.ExecuteScalar<string>();
			HttpWebRequest webRequest = CreateWebRequest(serviceUrl, ServiceMethod);
			string Request = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:web=""http://www.webserviceX.NET/"">
			<soap:Header/>
				<soap:Body>";
			Request += RequestBodyInternal;
			Request += @"
				</soap:Body>
			</soap:Envelope>";
			webRequest.ContentLength = Request.Length;
			using (Stream stream = webRequest.GetRequestStream()) {
				using (StreamWriter streamWriter = new StreamWriter(stream)) {
					streamWriter.Write(Request);
					streamWriter.Close();
				}
			}
			using (WebResponse response = webRequest.GetResponse()) {
				using (StreamReader rd = new StreamReader(response.GetResponseStream())) { 
					Responce = rd.ReadToEnd();
				}
			}
			PrepareResponceResult();
			if (!IsLoggingRequestAndResponce) {
				Request = string.Empty;
				Responce = string.Empty;
			}
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public virtual HttpWebRequest CreateWebRequest(string url, string soapAction) {
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
			webRequest.ContentType = "application/soap+xml;charset=UTF-8;action=\"http://www.webserviceX.NET/" + soapAction + "\"";
			webRequest.Method = "POST";
			webRequest.KeepAlive = true;
			return webRequest;
		}

		public virtual string PrepareRequestParameters() {
			return @"
			<web:ConversionRate>
						<web:FromCurrency>USD</web:FromCurrency>
						<web:ToCurrency>UAH</web:ToCurrency>
					</web:ConversionRate>";
		}

		public virtual void PrepareResponceResult() {
		}

		#endregion

	}

	#endregion

}

