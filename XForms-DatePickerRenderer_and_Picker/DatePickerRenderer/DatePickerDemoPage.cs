using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace DatePickerRenderer
{
    class DatePickerDemoPage : ContentPage
    {
        public DatePickerDemoPage()
        {
            Label header = new Label
            {
                Text = "DatePicker",
				Font = Font.SystemFontOfSize(50, FontAttributes.Bold),
                HorizontalOptions = LayoutOptions.Center
            };

            MyDatePicker datePickerStart = new MyDatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand, 
				Date = new DateTime(2014, 6, 6)
            };

			MyDatePicker datePickerEnd = new MyDatePicker
			{
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Date = new DateTime(2014, 7, 7)
			};

			Frame frameStart = new Frame(){
				Content = datePickerStart,
				WidthRequest = 100.0
			};

			Frame frameEnd = new Frame(){
				Content = datePickerEnd,
				WidthRequest = 100.0
			};

			Dictionary<string, Color> nameToColor = new Dictionary<string, Color> {
				{ "Aqua", Color.Aqua }, { "Black", Color.Black },
				{ "Blue", Color.Blue }, { "Fuschia", Color.Fuschia },
				{ "Gray", Color.Gray }, { "Green", Color.Green },
				{ "Lime", Color.Lime }, { "Maroon", Color.Maroon },
				{ "Navy", Color.Navy }, { "Olive", Color.Olive },
				{ "Purple", Color.Purple }, { "Red", Color.Red },
				{ "Silver", Color.Silver }, { "Teal", Color.Teal },
				{ "White", Color.White }, { "Yellow", Color.Yellow }
			};

			MyPicker picker = new MyPicker(){
				Title = "Color",
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};

			foreach (string colorName in nameToColor.Keys) {
				picker.Items.Add(colorName);
			}

			// Create BoxView for displaying picked Color
			BoxView boxView = new BoxView
			{
				WidthRequest = 150,
				HeightRequest = 150,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			picker.SelectedIndexChanged += (object sender, EventArgs e) => {
				if (picker.SelectedIndex == -1)
				{
					boxView.Color = Color.Default;
				}
				else
				{
					string colorName = picker.Items[picker.SelectedIndex];
					boxView.Color = nameToColor[colorName];
				}
			};

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			StackLayout dates = new StackLayout(){
				Orientation = StackOrientation.Horizontal,
				Children = {frameStart, frameEnd}
			};


            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    dates,
					picker,
					boxView
                }
            };
        }
    }
}
