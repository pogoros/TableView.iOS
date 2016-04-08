using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using Parse;

namespace TableView.iOS
{
	partial class ListController : UITableViewController
	{
		public ListController (IntPtr handle) : base (handle)
		{
			
		}

		UITableView table;

		public async override void ViewDidLoad ()

		{

			base.ViewDidLoad ();

			{
				table = new UITableView(View.Bounds, UITableViewStyle.Grouped); // change
				table.AutoresizingMask = UIViewAutoresizing.All;

				List<TableItem> tableItems = new List<TableItem>();

				// build a query to get a list of records from the FavoriteFoods class in Parse
				// and sort the results by the ItemName column

				var query = from favFood in ParseObject.GetQuery("FavoriteFoods")
					orderby favFood["ItemName"] ascending
					select favFood;

				// make an asynchronous call to Parse to get the contents of the query above
				IEnumerable<ParseObject> favFoodListResult = await query.FindAsync();


				// if the returned list from Parse is not empty
				if (favFoodListResult != null)
				{
					// loop through the results and set the object properties
					foreach (var favFoodItem in favFoodListResult)

					{

						var foodItem = new FavFood ()
						{

							ItemName = favFoodItem.Get<string> ("ItemName"), 
							ItemGroup = favFoodItem.Get<string> ("ItemGroup"), 
							ItemIcon = favFoodItem.Get<string> ("ItemIcon"),
							Description = favFoodItem.Get<string> ("Description"), 
							IsFavorite = favFoodItem.Get<bool> ("IsFavorite")

						} ;

						// assign the retrieved properties to the TableItem’s properties
						tableItems.Add 

						(

							new TableItem(foodItem.ItemName) 

							{
								SubHeading=foodItem.ItemGroup, 
								ImageName = foodItem.ItemIcon,
								AddFavorite = foodItem.IsFavorite,
								Description = foodItem.Description

							}
						);

					}
			}

			table.Source = new ImageTableSource (tableItems); 

			Add (table); 
		}
	}
}
}
