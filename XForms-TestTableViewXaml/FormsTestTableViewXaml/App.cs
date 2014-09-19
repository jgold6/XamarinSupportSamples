using System;
using Xamarin.Forms;

namespace FormsTestTableViewXaml
{
	public class App
	{
		public static Page GetMainPage()
		{	
			return new NavigationPage(new TableView1());
			// TableView1 in code
//			return new NavigationPage (new ContentPage {
//				Content = new TableView {
//					Intent = TableIntent.Settings,
//					Root = new TableRoot ("Settings") {
//						new TableSection ("Notifications") {
//							new ViewCell {
//								View = new StackLayout {
//									Padding = new Thickness(20.0, 0.0, 0.0, 0.0),
//									VerticalOptions = LayoutOptions.Start,
//									Orientation = StackOrientation.Horizontal,
//									Children = {
//										new Label {Text = "Notifications", WidthRequest = 100.0, YAlign = TextAlignment.Center},
//										new StackLayout {HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Orientation = StackOrientation.Vertical},
//										new Switch{IsToggled = true}
//									}
//								}
//							},
//							new ViewCell {
//								View = new StackLayout {
//									VerticalOptions = LayoutOptions.Start,
//									Orientation = StackOrientation.Horizontal,
//									Children = {
//										new Label {Text = "Max", WidthRequest = 100.0, YAlign = TextAlignment.Center},
//										new StackLayout {HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Orientation = StackOrientation.Vertical},
//										new Entry()
//									}
//								}
//							}
//
//						},
//						new TableSection ("Network") {
//							new TextCell {Text="To change a setting below, please change on your device.", IsEnabled = false},
//							new ViewCell {
//								View = new StackLayout {
//									HorizontalOptions = LayoutOptions.FillAndExpand,
//									VerticalOptions = LayoutOptions.FillAndExpand,
//									Children = {
//										new Label {Text = "IsWifi"}
//									}
//								}
//							},
//							new ViewCell {
//								View = new StackLayout {
//									Padding = new Thickness(20.0, 0.0, 0.0, 0.0),
//									VerticalOptions = LayoutOptions.Start,
//									Orientation = StackOrientation.Horizontal,
//									Children = {
//										new Label {Text = "IsWifi", WidthRequest = 100.0, YAlign = TextAlignment.Center},
//										new StackLayout {
//											HorizontalOptions = LayoutOptions.FillAndExpand,
//											VerticalOptions = LayoutOptions.FillAndExpand,
//											Orientation = StackOrientation.Vertical,
//											Children = {new Switch {IsToggled = false, IsEnabled = false}}
//										}
//									}
//								}
//							}
//						}
//					}
//				}
//			}); 
			// TableView2 in code
//			return new NavigationPage (new ContentPage {
//				Content = new StackLayout {
//					Children = {
//						new TableView {
//							Intent = TableIntent.Settings,
//							Root = new TableRoot ("Settings") {
//							new TableSection ("Notifications") {
//									new ViewCell {
//										View = new StackLayout {
//											Padding = new Thickness(20.0, 0.0, 0.0, 0.0),
//											VerticalOptions = LayoutOptions.Start,
//											Orientation = StackOrientation.Horizontal,
//											Children = {
//												new Label {Text = "Notifications", WidthRequest = 100.0, YAlign = TextAlignment.Center},
//												new StackLayout {HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Orientation = StackOrientation.Vertical},
//												new Switch{IsToggled = true}
//											}
//										}
//									},
//									new ViewCell {
//										View = new StackLayout {
//											VerticalOptions = LayoutOptions.Start,
//											Orientation = StackOrientation.Horizontal,
//											Children = {
//												new Label {Text = "Max", WidthRequest = 100.0, YAlign = TextAlignment.Center},
//												new StackLayout {HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Orientation = StackOrientation.Vertical},
//												new Entry()
//											}
//										}
//									}
//								},
//								new TableSection ("Network") {
//									new TextCell {Text="To change a setting below, please change on your device.", IsEnabled = false},
//									new SwitchCell {Text = "test1", On = true},
//									new SwitchCell {Text = "test2", On = true},
//									new SwitchCell {Text = "test3", On = true},
//									new SwitchCell {Text = "test4", On = true}
//								}
//							}
//						}
//					}
//				}
//			}); 
		}
	}
}

