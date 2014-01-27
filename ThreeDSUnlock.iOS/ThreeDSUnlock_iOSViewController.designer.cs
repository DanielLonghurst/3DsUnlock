// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace ThreeDSUnlock.iOS
{
	[Register ("ThreeDSUnlock_iOSViewController")]
	partial class ThreeDSUnlock_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField editText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel serviceCodeText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton unlockButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel unlockCodeText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (editText != null) {
				editText.Dispose ();
				editText = null;
			}

			if (serviceCodeText != null) {
				serviceCodeText.Dispose ();
				serviceCodeText = null;
			}

			if (unlockButton != null) {
				unlockButton.Dispose ();
				unlockButton = null;
			}

			if (unlockCodeText != null) {
				unlockCodeText.Dispose ();
				unlockCodeText = null;
			}
		}
	}
}
