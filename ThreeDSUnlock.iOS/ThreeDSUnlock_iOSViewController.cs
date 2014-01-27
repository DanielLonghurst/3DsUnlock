using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ThreeDSUnlock.iOS
{
   public partial class ThreeDSUnlock_iOSViewController : UIViewController
   {
      public ThreeDSUnlock_iOSViewController () : base ("ThreeDSUnlock_iOSViewController", null)
      {
      }

      public override void DidReceiveMemoryWarning ()
      {
         // Releases the view if it doesn't have a superview.
         base.DidReceiveMemoryWarning ();
			
         // Release any cached data, images, etc that aren't in use.
      }

      public override void ViewDidLoad ()
      {
         base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.

			editText.ClearsOnBeginEditing = true;
			editText.ClearButtonMode = UITextFieldViewMode.Always;
			unlockButton.SetTitleColor(UIColor.Green, UIControlState.Normal);
			unlockButton.SetTitleColor(UIColor.DarkTextColor, UIControlState.Disabled);

			editText.EditingChanged += (object sender, EventArgs e) => {
				if (editText.Text.Length == 8)
				{
					unlockButton.Enabled = true;
				}
				else
				{
					unlockButton.Enabled = false;
				}
			};
      }

		/// <summary> The Unlock button was pressed by the user, calc and display results
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <remarks>
		/// This method is linked by an IBAction in the xib so must be exported here.  We are not
		/// A custom view controller as far as the xib is concerned
		/// </remarks>
		[Export ("unlockButtonPressed:")]
		public void UnlockButtonClicked(NSObject sender)
		{
			this.View.EndEditing(true);

			string masterCode;
			string serviceCode;
			ulong userCode;
			if (ulong.TryParse (editText.Text, out userCode))
			{
				ThreeDSUnlockLib.Unlocker.GetUnlockKey (userCode, out masterCode, out serviceCode);

				this.unlockCodeText.Text = masterCode;
				this.serviceCodeText.Text = serviceCode;
			}
		}
   }
}

