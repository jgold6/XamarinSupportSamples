using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Homepwner
{
	public partial class DetailViewController : UIViewController, IUITextFieldDelegate, IUIImagePickerControllerDelegate, IUIPopoverControllerDelegate
	{

		UIPopoverController imagePickerPopover;
//		UIPopoverController assetTypePopover; // Bronze, asset type picker popover on iPad

		UIAlertView av;
		UIView dpSuperView;
		UIDatePicker dp;
		UIViewController dpvc;

		BNRItem item;

		public BNRItem Item {
			get {
				return item;
			} 
			set {
				item = value;
				this.NavigationItem.Title = item.itemName;
			}
		}

		public DetailViewController()
		{
			throw new Exception("Wrong initializer. Use overload with isNew parameter.");
		}

		public DetailViewController(bool isNew) : base("DetailViewController", null)
		{
			if (isNew) {
				UIBarButtonItem doneItem = new UIBarButtonItem(UIBarButtonSystemItem.Done);
				this.NavigationItem.RightBarButtonItem = doneItem;
				doneItem.Clicked += (sender, e) => {
					this.PresentingViewController.DismissViewController(true, null);

					var vcs = this.PresentingViewController.ChildViewControllers;
					var ivc = vcs[0] as ItemsViewController;
					ivc.TableView.ReloadData();
					Console.WriteLine("allItems: {0}, tableViewRows: {1}", BNRItemStore.allItems.Count, ivc.TableView.NumberOfRowsInSection(0));
				};

				UIBarButtonItem cancelItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel);
				this.NavigationItem.LeftBarButtonItem = cancelItem;
				cancelItem.Clicked += (sender, e) => {
					// If the user cancelled, then remove the BNRItem from the store
					BNRItemStore.RemoveItem(Item);
					this.PresentingViewController.DismissViewController(true, null);

					var vcs = this.PresentingViewController.ChildViewControllers;
					var ivc = vcs[0] as ItemsViewController;
					Console.WriteLine("allItems: {0}, tableViewRows: {1}", BNRItemStore.allItems.Count, ivc.TableView.NumberOfRowsInSection(0));
				};
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			UIImage image = UIImage.FromBundle("tvBgImage.png");
			UIImageView iv = new UIImageView(image);
			iv.AutoresizingMask = (UIViewAutoresizing.All);
			View.Add(iv);
			View.SendSubviewToBack(iv);

			UIColor clr = null;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				clr = UIColor.FromRGBA(0.875f, 0.88f, 9.1f, 1f);
			} else {
				clr = UIColor.GroupTableViewBackgroundColor;
			}
			this.View.BackgroundColor = clr;

			changeDate.TouchUpInside += (sender, e)  => {
				av.Show();
			};

			dpSuperView = new UIView(this.View.Frame);
			dpSuperView.BackgroundColor = UIColor.White;
			dp = new UIDatePicker();
			dp.Mode = UIDatePickerMode.Date;
			dpSuperView.Add(dp);
			dpvc = new UIViewController();
			dpvc.View = dpSuperView;
			dpvc.EdgesForExtendedLayout = UIRectEdge.None;

			av = new UIAlertView(
				NSBundle.MainBundle.LocalizedString("Do you really want to change the date?", "Confirm Date Change"),
				NSBundle.MainBundle.LocalizedString("Modifying the date of an acquired item can result in charges of insurance fraud.", "Change Warning"),
				null, 
				NSBundle.MainBundle.LocalizedString("This is correcting an error.", "Correct Error"),
				null);
			av.Clicked += (object sender, UIButtonEventArgs e) => {
				dp.Date = item.dateCreated;

				dpvc.EdgesForExtendedLayout = UIRectEdge.None;

				UINavigationController navController = new UINavigationController(dpvc);
				navController.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
				navController.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;

				UIBarButtonItem doneItem = new UIBarButtonItem(UIBarButtonSystemItem.Done);
				dpvc.NavigationItem.SetRightBarButtonItem(doneItem, true);
				doneItem.Clicked += (sender2, e2) => {
					this.NavigationController.DismissViewController(true, null);
					DateTime newDate = dp.Date;
					dateLabel.Text = newDate.ToLocalTime().ToShortDateString();
				};
				this.PresentViewController(navController, true, null);
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
					//navController.View.Bounds = new RectangleF(50.0f, 50.0f, 320.0f, 260.0f);
					navController.View.Superview.Bounds = new RectangleF(0.0f, 0.0f, 480.0f, 260.0f);
					dp.Bounds = new RectangleF(-100.0f, 0.0f, 0.0f, 0.0f);
				}
			};
			dp.ValueChanged += (object sender, EventArgs e) => {
				DateTime newDate = dp.Date;
				Console.WriteLine("test dp: " +  newDate.ToLocalTime());
				item.dateCreated = newDate.ToLocalTime();
			};
			nameField.EditingChanged += (object sender, EventArgs e) => {
				this.NavigationItem.Title = nameField.Text;
			};

			takePicture.Clicked += (sender, e) => {
				if (imagePickerPopover != null && imagePickerPopover.PopoverVisible) {
					// if the popover is already up, get rid of it
					imagePickerPopover.Dismiss(true);
					imagePickerPopover = null;
					return;
				}

				UIImagePickerController imagePicker = new UIImagePickerController();

				// If device has camera, take picture, else pick from photo library
				if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
					imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
				else
					imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

				imagePicker.WeakDelegate = this;

				// Place the image picker on the screen
				//this.PresentViewController(imagePicker, true, null);
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
					if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera)) {
						this.PresentViewController(imagePicker, true, null);
						return;
					}
					imagePickerPopover = new UIPopoverController(imagePicker);
					imagePickerPopover.WeakDelegate = this;

					// Diaplay the popover controller
					// sender is the camera bar button item
					imagePickerPopover.PresentFromBarButtonItem((UIBarButtonItem)sender, UIPopoverArrowDirection.Any, true);
				} else {
					this.PresentViewController(imagePicker, true, null);
				}

			};

			nameField.ShouldReturn += ((textField) => {
				textField.ResignFirstResponder();
				return true;
			});

			serialNumberField.ShouldReturn += ((textField) => {
				textField.ResignFirstResponder();
				return true;
			});

			valueField.ShouldReturn += ((textField) => {
				textField.ResignFirstResponder();
				return true;
			});
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			nameField.Text = item.itemName;
			serialNumberField.Text = item.serialNumber;
			valueField.Text = item.valueInDollars.ToString();
			valueField.KeyboardType = UIKeyboardType.NumberPad;
			dateLabel.Text = item.dateCreated.ToShortDateString();

			string imageKey = item.imageKey;

			if (imageKey != null) {
				// Get image for image key from image store
				UIImage imageToDisplay = BNRImageStore.imageForKey(imageKey);

				// Use that image to put on the screen in imageView
				imageView.Image = imageToDisplay;
			} else {
				// Clear the imageView
				imageView.Image = null;
			}
			assetTypeBtn.SetTitle(
				NSBundle.MainBundle.LocalizedString(((item.assetType == "" || item.assetType == null) ? "None" : item.assetType), "Asset Type"), 
				UIControlState.Normal);
		}

		partial void backgroundTapped (MonoTouch.Foundation.NSObject sender)
		{
			this.View.EndEditing(true);
		}

		partial void assetTypeTapped (MonoTouch.Foundation.NSObject sender)
		{
			this.View.EndEditing(true);
			AssetTypePicker atp = new AssetTypePicker();
			atp.item = this.Item;
//			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {  // Bronze
//				UIButton btn = sender as UIButton;// Bronze
//				assetTypePopover = new UIPopoverController(atp);// Bronze
//				atp.popoverController = assetTypePopover;// Bronze
//				atp.controller = this;// Bronze
//
//				assetTypePopover.PopoverContentSize = new SizeF(600, 450);// Bronze
//				assetTypePopover.WeakDelegate = this;// Bronze
//				assetTypePopover.PresentFromRect(btn.Frame, this.View, UIPopoverArrowDirection.Any, true);// Bronze
//			} else {// Bronze
				this.NavigationController.PushViewController(atp, true);
//			} // Bronze
		}

		public void updateAssetType()
		{
			assetTypeBtn.SetTitle(item.assetType, UIControlState.Normal);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			// Clear first responder
			this.View.EndEditing(true);

			// "Save" changes to item
			item.itemName = nameField.Text;
			item.serialNumber = serialNumberField.Text;
			item.valueInDollars = Convert.ToInt32(valueField.Text);
			BNRItemStore.updateDBItem(item);
		}



		[Export("imagePickerController:didFinishPickingMediaWithInfo:")]
		public void FinishedPickingMedia (UIImagePickerController picker, NSDictionary info)
		{
			string oldKey = item.imageKey;

			// Did the item already have an image?
			if (oldKey != null) {
				// Delete the old image
				BNRImageStore.deleteImageForKey(oldKey);
				BNRImageStore.deleteImageForKey(oldKey+ ".thumbnail");
			}


			// Get the picked picture from the event args
			UIImage image = info.ObjectForKey(UIImagePickerController.OriginalImage) as UIImage;

//			item.getThumbnailFromImage(image); // For Archive method of saving

			// Get thumbnail // For SQL saving
			UIImage thumbnailImage = item.getThumbnailFromImage(image); // For SQL saving

			// Create a GUID string - it iknows how to create unique identifier strings
			string key = Guid.NewGuid().ToString();
			item.imageKey = key;
			BNRItemStore.updateDBItem(item);
			string thumbKey = key + ".thumbnail"; // For SQL saving

			// Store image and thumbnail in the BNRIMmageStore with this key
			BNRImageStore.setImage(image, item.imageKey);
			BNRImageStore.setImage(thumbnailImage, thumbKey);

			// Put that image onto the screen in our image view
			imageView.Image = image;

			// Take the image picker off the screen - 
			// You must call this dismiss method
			//this.DismissViewController(true, null);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				// if on the phone, the image picker os presented modally. Dismiss it.
				this.DismissViewController(true, null);
			} else if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera) && UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				this.DismissViewController(true, null);
			} else {
				// If on the iPad, the image picker is in the popover. Dismiss the popover.
				imagePickerPopover.Dismiss(true);
				imagePickerPopover = null;
			}
		}

		partial void deletePicture (MonoTouch.Foundation.NSObject sender)
		{
			if (item.imageKey != null) {
				string key = item.imageKey;
				BNRImageStore.deleteImageForKey(key);
				imageView.Image = null;
				item.imageKey = null;
			}
		}

		[Export("popoverControllerDidDismissPopover:")]
		public void PopoverControllerDidDismissPopover(UIPopoverController popoverController)
		{
			Console.WriteLine("User dismissed popover");
			imagePickerPopover = null;
//			assetTypePopover = null; // Bronze
		}

		public override bool ShouldAutorotate()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				return true;
			} else {
				return false;
			}
		}
	}
}

