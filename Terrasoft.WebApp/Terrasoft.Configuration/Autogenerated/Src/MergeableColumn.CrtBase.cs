using System;
using Terrasoft.Common;
using Terrasoft.Core;

namespace Terrasoft.Configuration
{
	public class MergeableColumn
	{
		public string ColumnCaption {
			get;
			set;
		}
		
		public string ColumnName {
			get;
			set;
		}
		
		public bool IsAlwaysHidden {
			get;
			set;
		}
	}
}
