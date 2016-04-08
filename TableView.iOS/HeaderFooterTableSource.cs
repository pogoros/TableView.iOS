using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TableView.iOS
{

	public class HeaderFooterTableSource : UITableViewSource 

	{

		protected string cellIdentifier = "TableCell";

		Dictionary <string, List<TableItem>> indexedTableItems;
		string[] keys;

		public HeaderFooterTableSource (List<TableItem> items)

		{

			indexedTableItems = new Dictionary<string, List<TableItem>>();
			foreach (var t in items) {

				if (indexedTableItems.ContainsKey (t.SubHeading)) {
					indexedTableItems[t.SubHeading].Add(t);

				} 
				else {

					indexedTableItems.Add (t.SubHeading, new List<TableItem>() {t});
				}
			}
				keys = indexedTableItems.Keys.ToArray ();
		}
				public override nint NumberOfSections (UITableView tableView)
		{
			return keys.Length;
		}

				public override nint RowsInSection (UITableView tableview, nint section)
					{
						return indexedTableItems[keys[section]].Count;
					}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return keys [section];
		}

		public override string TitleForFooter (UITableView tableView, nint section)
		{
			return indexedTableItems[keys[section]].Count + " items";
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			new UIAlertView("Row Selected"
				, indexedTableItems[keys[indexPath.Section]][indexPath.Row].Heading
				, null, "OK", null).Show();
			tableView.DeselectRow (indexPath, true);

		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			TableItem item = indexedTableItems [keys [indexPath.Section]] [indexPath.Row];

			if (cell == null) {
				cell = new UITableViewCell (item.CellStyle, cellIdentifier); 
			}

			cell.BackgroundColor = UIColor.Blue;
			cell.TextLabel.Text = item.Heading;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		
		}
		}
}