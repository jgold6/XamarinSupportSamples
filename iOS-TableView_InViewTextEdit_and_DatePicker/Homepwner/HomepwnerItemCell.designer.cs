// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Homepwner
{
	[Register ("HomepwnerItemCell")]
	partial class HomepwnerItemCell
	{
		[Outlet]
		public MonoTouch.UIKit.UITextField dateField { get; private set; }

		[Outlet]
		public MonoTouch.UIKit.UITextField nametextField { get; private set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (nametextField != null) {
				nametextField.Dispose ();
				nametextField = null;
			}

			if (dateField != null) {
				dateField.Dispose ();
				dateField = null;
			}
		}
	}
}
