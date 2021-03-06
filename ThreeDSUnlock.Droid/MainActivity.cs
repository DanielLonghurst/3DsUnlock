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
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ThreeDSUnlock.Droid
{
   [Activity (Label = "ThreeDSUnlock.Droid", MainLauncher = true)]
   public class MainActivity : Activity
   {
		EditText editText;
		Button button;
		TextView masterCodeText;
		TextView serviceCodeText;

      protected override void OnCreate (Bundle bundle)
      {
         base.OnCreate (bundle);

         // Set our view from the "main" layout resource
         SetContentView (Resource.Layout.Main);

         // Get our button from the layout resource,
         // and attach an event to it
			editText = FindViewById<EditText> (Resource.Id.editText1);
			button = FindViewById<Button> (Resource.Id.unlockButton);
			masterCodeText = FindViewById<TextView>(Resource.Id.masterCodeText);
			serviceCodeText = FindViewById<TextView>(Resource.Id.serviceCodeText);

         button.Click += delegate
         {
				string masterCode;
				string serviceCode;
				ulong userCode;
				if (ulong.TryParse(editText.Text, out userCode))
				{
					ThreeDSUnlockLib.Unlocker.GetUnlockKey(userCode, out masterCode, out serviceCode);
					masterCodeText.Text = masterCode;
					serviceCodeText.Text = serviceCode;
				}
         };

			if (bundle != null)
			{
				editText.Text = bundle.GetString ("editText");
				masterCodeText.Text = bundle.GetString ("masterCodeText");
				serviceCodeText.Text = bundle.GetString ("serviceCodeText");
			}
      }

		/// <Docs>Bundle in which to place your saved state.</Docs>
		/// <summary>
		/// Raises the save instance state event.
		/// </summary>
		/// <param name="outState"> Activity's bundle
		/// </param>
		protected override void OnSaveInstanceState (Bundle outState)
		{
			outState.PutString ("editText", editText.Text);
			outState.PutString ("masterCodeText", masterCodeText.Text);
			outState.PutString ("serviceCodeText", serviceCodeText.Text);

			base.OnSaveInstanceState (outState);
		}

   }
}


