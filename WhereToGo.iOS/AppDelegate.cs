﻿using Foundation;

using System;
using System.IO;

using UIKit;

namespace WhereToGo.iOS {
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            Xamarin.Forms.Forms.Init();
            Xamarin.Forms.FormsMaterial.Init();

            string dbName = "MyAddresses_db.sqlite";


            /* This is used because if we are going to publish this pap to IOS, Apple doesn't allow you to store data in a personal folder,
             * so we have to navigate back by using to dots
             */

            string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");
            string fullPath = Path.Combine(FolderPath, dbName);


            LoadApplication(new App(fullPath));

            return base.FinishedLaunching(app, options);
        }
    }
}
