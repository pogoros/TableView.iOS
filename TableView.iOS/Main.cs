﻿using UIKit;
using Parse;

namespace TableView.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
