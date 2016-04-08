using System;
using UIKit;
using System.Collections.Generic;

namespace TableView.iOS
{
	public class TableItemGroup
	{
		public TableItemGroup ()
		{
		}

		public string Name { get; set; }
		public string Footer { get; set; }

		public List<TableItem> Items {
			get { return items; }
			set { items = value; }
		}
		protected List<TableItem> items = new List<TableItem> ();	
	}
}

