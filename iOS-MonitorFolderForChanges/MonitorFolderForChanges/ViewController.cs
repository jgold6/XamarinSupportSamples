using System;

using UIKit;
using System.IO;
using CoreFoundation;

namespace MonitorFolderForChanges
{
	public partial class ViewController : UIViewController
	{
		string documentsPath;
		DispatchSource dispatchSource;

		public ViewController (IntPtr handle) : base (handle)
		{
			documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments); 
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			dispatchSource = new DispatchSource.VnodeMonitor (documentsPath, VnodeMonitorKind.Delete | VnodeMonitorKind.Extend | VnodeMonitorKind.Write, DispatchQueue.MainQueue);
			dispatchSource.SetRegistrationHandler (() => { 
				Console.WriteLine("Vnode monitor registered");
			});
			dispatchSource.SetEventHandler (() => {
				UpdateFilesList();
			});

			dispatchSource.Resume ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			dispatchSource.Cancel ();
			dispatchSource.Dispose ();
			dispatchSource = null;
		}

		partial void BtnAddFile_TouchUpInside (UIButton sender)
		{
			if (txtFieldAddFile.Text != "") {
				var filename = Path.Combine (documentsPath, txtFieldAddFile.Text);
				if (File.Exists(filename)) {
					UIAlertController alert = UIAlertController.Create("File Exists", "There is already a file with name " + txtFieldAddFile.Text + ". Please choose a new name.", UIAlertControllerStyle.Alert);
					UIAlertAction defaultAction = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);
					alert.AddAction(defaultAction);
					this.PresentViewController(alert, true, null);
				}
				else {
					File.WriteAllText(filename, "Write this text into a file");
				}
			}

		}

		partial void BtnDeleteFile_TouchUpInside (UIButton sender)
		{
			if (txtFieldDeleteFile.Text != "") {
				var filename = Path.Combine (documentsPath, txtFieldDeleteFile.Text);
				if (File.Exists(filename)) {
					File.Delete(filename);
				}
				else {
					UIAlertController alert = UIAlertController.Create("File does not exists", "There is no file with name " + txtFieldDeleteFile.Text + ".", UIAlertControllerStyle.Alert);
					UIAlertAction defaultAction = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);
					alert.AddAction(defaultAction);
					this.PresentViewController(alert, true, null);
				}
			}

		}

		void UpdateFilesList() 
		{
			var files = Directory.GetFiles(documentsPath);
			textViewFiles.Text = "";
			foreach (string file in files) {
				var name = file.Split (new char[]{ '/' }, StringSplitOptions.RemoveEmptyEntries);
				textViewFiles.Text +=  name[name.Length-1] + "\n";
			}
		}
	}
}

