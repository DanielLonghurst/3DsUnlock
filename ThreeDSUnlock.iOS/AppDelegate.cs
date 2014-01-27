// Copyright (c) 2014 InVision Automation, Inc., Dallas, Georgia
//
// 3DSUnlock(tm) is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// 3DSUnlock(tm) is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with the source code.  If not, see <http://www.gnu.org/licenses/>.
//
// Daniel V. Longhurst

using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ThreeDSUnlock.iOS
{
   // The UIApplicationDelegate for the application. This class is responsible for launching the
   // User Interface of the application, as well as listening (and optionally responding) to
   // application events from iOS.
   [Register ("AppDelegate")]
   public partial class AppDelegate : UIApplicationDelegate
   {
      // class-level declarations
      UIWindow window;
      ThreeDSUnlock_iOSViewController viewController;
      //
      // This method is invoked when the application has loaded and is ready to run. In this
      // method you should instantiate the window, load the UI into it and then make the window
      // visible.
      //
      // You have 17 seconds to return from this method, or iOS will terminate your application.
      //
      public override bool FinishedLaunching (UIApplication app, NSDictionary options)
      {
         window = new UIWindow (UIScreen.MainScreen.Bounds);
			
         viewController = new ThreeDSUnlock_iOSViewController ();
         window.RootViewController = viewController;
         window.MakeKeyAndVisible ();
			
         return true;
      }
   }
}

