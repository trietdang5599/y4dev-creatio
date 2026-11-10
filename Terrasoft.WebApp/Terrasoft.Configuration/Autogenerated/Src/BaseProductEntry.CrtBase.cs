namespace Terrasoft.Configuration
{

	using DataContract = Terrasoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.DcmProcess;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: BaseProductEntry_CrtBaseEventsProcess

	public partial class BaseProductEntry_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual decimal Division(decimal arg1, decimal arg2) {
			decimal result = 0;
			if (arg2 > 0) {
				result = arg1 / arg2;
			}
			return result;
		}

		public virtual decimal Multiply(decimal arg1, decimal arg2) {
			var result = arg1* arg2;
			return result;
		}

		public virtual void UpdatePrimaryAmounts() {
			if (Terrasoft.Core.Configuration.SysSettings.TryGetValue(UserConnection, "CalcBaseProductAmountsWithProcess",
					out var calcWithProcess) && (bool)calcWithProcess) {
				return;
			}
			decimal price = this.Entity.GetTypedColumnValue<decimal>("Price");
			decimal amount = this.Entity.GetTypedColumnValue<decimal>("Amount");
			decimal discountAmount = this.Entity.GetTypedColumnValue<decimal>("DiscountAmount");
			decimal taxAmount  = this.Entity.GetTypedColumnValue<decimal>("TaxAmount");
			decimal totalAmount  = this.Entity.GetTypedColumnValue<decimal>("TotalAmount");
			this.Entity.SetColumnValue("PrimaryPrice", Division(price, CurrencyRate));
			this.Entity.SetColumnValue("PrimaryAmount", Division(amount, CurrencyRate));
			this.Entity.SetColumnValue("PrimaryDiscountAmount", Division(discountAmount, CurrencyRate));
			this.Entity.SetColumnValue("PrimaryTaxAmount", Division(taxAmount, CurrencyRate));
			this.Entity.SetColumnValue("PrimaryTotalAmount", Division(totalAmount, CurrencyRate));
		}

		#endregion

	}

	#endregion

}

