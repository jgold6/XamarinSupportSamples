using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloTabsICS
{
    [Activity (Label = "HelloTabsICS", MainLauncher = true)]
	public class Activity1 : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab("Tab 1", Resource.Drawable.ic_tab_white);
			AddTab("Tab 2", Resource.Drawable.ic_tab_white);
		}

		void AddTab(string tabText, int iconResourceId)
		{

			var tab = this.ActionBar.NewTab();
			tab.SetText(tabText);
			tab.SetIcon(Resource.Drawable.ic_tab_white);

			// must set event handler before adding tab
			if (tabText == "Tab 1")
			{
				tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e)
				{
					e.FragmentTransaction.Replace(Resource.Id.fragmentContainer,new SampleTabFragment1(), "Tab1Frag"); 
				};
			}
			else
			{
				tab.TabSelected += delegate(object sender,	ActionBar.TabEventArgs e)
				{
					e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, new SampleTabFragment2(), "Tab2Frag");
				};
			};
			this.ActionBar.AddTab(tab);
		}

		class SampleTabFragment1 : Fragment
		{
			public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
			{
				base.OnCreateView(inflater, container, savedInstanceState);
				var view = inflater.Inflate(Resource.Layout.Tab, container,	false);
				var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
				sampleTextView.Text = "sample fragment text for Tab 1";
				return view;
			}
		}

		class SampleTabFragment2 : Fragment
		{
			public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
			{
				base.OnCreateView(inflater, container, savedInstanceState);
				var view = inflater.Inflate(Resource.Layout.Tab, container,	false);
				var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
				sampleTextView.Text = "sample fragment text for Tab 2";
				return view;

			}

		}
	}
}
