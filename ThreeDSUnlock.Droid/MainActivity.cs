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

		protected override void OnSaveInstanceState (Bundle outState)
		{
			outState.PutString ("editText", editText.Text);
			outState.PutString ("masterCodeText", masterCodeText.Text);
			outState.PutString ("serviceCodeText", serviceCodeText.Text);

			base.OnSaveInstanceState (outState);
		}

   }
}


