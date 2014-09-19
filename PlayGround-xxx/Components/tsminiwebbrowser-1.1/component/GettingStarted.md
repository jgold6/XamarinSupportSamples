# Usage

If you are OK with the **TSMiniWebBrowser defaults**, you can simply use this snippet to create and display the browser:

```csharp
using TSMiniWebBrowser;
// ...

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	
	var browser = new MiniWebBrowser (new NSUrl ("http://xamarin.com"));
	NavigationController.PushViewController (browser, true);
}
```

If you prefer, you may **customize** the browser behavior. 

```csharp
using TSMiniWebBrowser;
// ...

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	
	var browser = new MiniWebBrowser (new NSUrl ("http://xamarin.com")) {
		ShowUrlstringOnActionSheetTitle = true,
		ShowPageTitleOnTitleBar = true,
		ShowActionButton = true,
		ShowReloadButton = true,
		BarStyle = UIBarStyle.Black,
		Delegate = new MyWebDelegate (),
		Mode = MiniWebBrowserMode.Modal
	}
	PresentViewController (browser, true, null);
}

class MyWebDelegate : MiniWebBrowserDelegate
{
	public override void DidDismiss ()
	{
		// This will get called when the browser is called modally.
		Console.WriteLine ("Mini Web Browser Did Dismiss");
	}
}
```

