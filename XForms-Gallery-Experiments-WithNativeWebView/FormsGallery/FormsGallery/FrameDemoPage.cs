﻿using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class FrameDemoPage : ContentPage
    {
        public FrameDemoPage()
        {
            Label header = new Label
            {
                Text = "Frame",
                Font = Font.BoldSystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center
            };

            Frame frame = new Frame
            {
                OutlineColor = Color.Accent,
                HasShadow = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "I've been framed!"
                }
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    frame
                }
            };
        }
    }
}
