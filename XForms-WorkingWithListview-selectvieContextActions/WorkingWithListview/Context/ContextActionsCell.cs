using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
	/// <summary>
	/// Demonstrates the new ContextActions property introduced in Xamarin.Forms 1.3
	/// </summary>
	public class ContextActionsCell : ViewCell
	{
		public Label Label1 {get; set;}

		public ContextActionsCell ()
		{
			Label1 = new Label { Text = "Label 1", Font = Font.SystemFontOfSize(NamedSize.Small), FontAttributes = FontAttributes.Bold };
			Label1.SetBinding(Label.TextProperty, new Binding("."));
			var hint = Device.OnPlatform ("Tip: swipe left for context action", "Tip: long press for context action", "Tip: long press for context action");
			var label2 = new Label { Text = hint, Font = Font.SystemFontOfSize(NamedSize.Micro) };




			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (15, 5, 5, 15),
				Children = {
					new StackLayout {
						Orientation = StackOrientation.Vertical,
						Children = { Label1, label2 }
					}
				}
			};
		}
	}
}


