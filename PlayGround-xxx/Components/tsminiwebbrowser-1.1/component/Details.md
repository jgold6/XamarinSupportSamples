# Features

TSMiniWebBrowser offers the following **features**:

* Back and forward buttons
* Reload button (*optional*)
* Activity indicator while page is loading
* Action button to open the current page in Safari (*optional*)
* Displays the page title at the navigation bar (*optional*)
* Displays the current URL at the top of the “Open in Safari” action sheet (*optional*)
* Customizable bar style: default, black, black translucent.

As you can see, there are some items that are “optional”. That means that you can configure the browser to display or not those items, depending on your app needs.

Moreover, TSMiniWebBrowser **supports 3 presentation modes**:

* **Navigation controller mode**. Using this mode you can push the browser to your navigation controller.
* **Modal mode**. Using this mode you can present the browser modally. A title bar with a dismiss button will be automatically added.
* **Tab bar mode**. Using this mode you can show the browser as a tab of a tab bar view controller. The toolbar with the navigation controls will be positioned at the top of the view automatically.

## Usage

You can simply use this snippet to create and display the browser:

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

