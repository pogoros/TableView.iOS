﻿using System;
using UIKit;
using Foundation;

namespace TableView.iOS
{
	public class TableSource : UITableViewSource 
	{


		string[] TableItems;
		string CellIdentifier = "TableCell" ; // NOTE: this matches the CellIdentifier set in the StoryBoard

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)

		{

			new UIAlertView("Row Selected", TableItems[indexPath.Row], null,
				"OK", null).Show();
			tableView.DeselectRow (indexPath, true); 

			// normal iOS behavior is to remove the blue highlight
		}

		public TableSource(string[] items)
		{
			TableItems = items;
		}
			
			public override nint RowsInSection (UITableView tableview, nint section)
		{
			return TableItems.Length;
		}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);
			string item = TableItems[indexPath.Row];

			if (cell == null)
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier); 

			}

			cell.TextLabel.Text = item;
			return cell;

		}


	}
}
