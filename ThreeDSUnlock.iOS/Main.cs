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
   public class Application
   {
      // This is the main entry point of the application.
      static void Main (string[] args)
      {
         // if you want to use a different Application Delegate class from "AppDelegate"
         // you can specify it here.
         UIApplication.Main (args, null, "AppDelegate");
      }
   }
}
