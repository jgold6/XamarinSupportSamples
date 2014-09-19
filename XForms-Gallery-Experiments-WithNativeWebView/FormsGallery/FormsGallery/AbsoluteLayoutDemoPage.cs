﻿using System;
using Xamarin.Forms;

namespace FormsGallery
{
    class AbsoluteLayoutDemoPage : ContentPage
    {
        Label text1;
        Label text2;
        bool isCurrentPage;

        public AbsoluteLayoutDemoPage()
        {
            Label header = new Label
            {
                Text = "AbsoluteLayout",
                Font = Font.BoldSystemFontOfSize(40),
                HorizontalOptions = LayoutOptions.Center
            };

            AbsoluteLayout absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.Blue.WithLuminosity(0.9),
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Create two Labels for animating.
            text1 = new Label 
            { 
                Text = "AbsoluteLayout",
                TextColor = Color.Black
            };
            absoluteLayout.Children.Add(text1);
            AbsoluteLayout.SetLayoutFlags(text1,
                AbsoluteLayoutFlags.PositionProportional);

            text2 = new Label 
            { 
                Text = "AbsoluteLayout",
                TextColor = Color.Black
            };
            absoluteLayout.Children.Add(text2);
            AbsoluteLayout.SetLayoutFlags(text2,
                AbsoluteLayoutFlags.PositionProportional);

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = 
                {
                    header,
                    absoluteLayout
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isCurrentPage = true;
            DateTime beginTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1.0  / 30), () =>
            {
                double seconds = (DateTime.Now - beginTime).TotalSeconds;
                double offset = 1 - Math.Abs((seconds % 2) - 1);

                AbsoluteLayout.SetLayoutBounds(text1,
                    new Rectangle(offset, offset, 
                        AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

                AbsoluteLayout.SetLayoutBounds(text2,
                    new Rectangle(1 - offset, offset,
                        AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

                return isCurrentPage;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isCurrentPage = false;
        }
    }
}
