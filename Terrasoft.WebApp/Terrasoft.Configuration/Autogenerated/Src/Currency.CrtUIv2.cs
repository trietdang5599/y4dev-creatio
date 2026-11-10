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
	using Terrasoft.Core.Store;
	using Terrasoft.GlobalSearch.Indexing;
	using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Currency_UIv2EventsProcess

	public partial class Currency_CrtUIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void OnCurrencySavedHandler() {
			var currRateSchema = UserConnection.EntitySchemaManager.GetInstanceByName("CurrencyRate");
			var currencyRateStorage = Terrasoft.Core.Factories.ClassFactory.Get<Terrasoft.Configuration.CurrencyRateStorage>(
				new Terrasoft.Core.Factories.ConstructorArgument("userConnection", UserConnection),
				new Terrasoft.Core.Factories.ConstructorArgument("schema", currRateSchema));
			List<CurrencyRateInfo> rates = currencyRateStorage.GetActualCurrencyRates(Entity.PrimaryColumnValue);
			CurrencyRateInfo currentCurrenyRate = rates.FirstOrDefault();
			if (currentCurrenyRate != null) {
				OldCurrencyRate = CurrencyRateHelper.SetMantissaToRate(currentCurrenyRate.Rate, currentCurrenyRate.RateMantissa);
			}
			if (CurrencyRate > 0.00m && OldCurrencyRate != CurrencyRate) {
				currencyRateStorage.SaveRates(new CurrencyRateInfo() {
					CurrencyId = Entity.PrimaryColumnValue, 
					Rate = CurrencyRate
				});
			}
		}

		public virtual void OnCurrencySavingHandler() {
			var columns = Entity.GetChangedColumnValues();
			var rateColumnName = Entity.Schema.Columns.GetByName("Rate").ColumnValueName;
			CurrencyRate = Entity.GetTypedColumnValue<decimal>(rateColumnName);
			Entity.SetColumnValue("Rate", 0.00m);
		}

		#endregion

	}

	#endregion

}

