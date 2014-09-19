using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace xxx
{
	public enum CAlertViewType { ProgressBar, ActivityIndicator };

	[MonoTouch.Foundation.Register("CAlertView")]
	public class CAlertView : UIAlertView
	{
		public CAlertViewType AlertViewType { get; set; }
		public UIProgressView ProgressView { get; set; }
		
		public UIActivityIndicatorView ActivityIndicator { get; set; }
		
		public CAlertView (IntPtr handle) : base(handle)
		{
		}

		[Export("CAlertView:")]
		public CAlertView (NSCoder coder) : base(coder)
		{
		}
		
		public CAlertView ()
		{
			ProgressView = new UIProgressView();
		}
		
		private bool setUpComplete = false;

		public override void Draw (RectangleF rect)
		{
			if (setUpComplete==false) {
			switch (this.AlertViewType) {
			case CAlertViewType.ProgressBar:
			    if (this.ProgressView==null) {
					this.ProgressView = new UIProgressView();
					ProgressView.Style = UIProgressViewStyle.Default;
					ProgressView.Progress = 0f;
			    }
			    this.ProgressView.Frame = new RectangleF(30.0f, rect.Height - 50f, 225.0f, 11f);
			    this.AddSubview(this.ProgressView);
				break;
			case CAlertViewType.ActivityIndicator:
				if (this.ActivityIndicator==null) {
					this.ActivityIndicator = new UIActivityIndicatorView();
					this.ActivityIndicator.Frame = new RectangleF(139.0f-18.0f, rect.Height - 63f, 37.0f, 37.0f);
				}
				this.AddSubview(this.ActivityIndicator);
				this.ActivityIndicator.StartAnimating();
				break;
			}
				setUpComplete=true;
			}
			base.Draw (rect);
		}
		
		private void UpdateProgressBar() {
			this.ProgressView.SetNeedsDisplay();
			this.SetNeedsDisplay();
		}
		
		/// <summary>
		/// Updates the layout using the mainThread
		/// </summary>
		public void Update() {
			if (this.ProgressView!=null) {
			   this.InvokeOnMainThread(UpdateProgressBar);
			}
		}
		
		public void UpdateIndicator()
		{
			if (this.ProgressView!=null) {
			   this.InvokeOnMainThread(UpdateProgressIndicator);
			}
		}
		
		private void UpdateProgressIndicator() {
			this.ActivityIndicator.SetNeedsDisplay();
			this.SetNeedsDisplay();
		}
		
		public void Hide(bool animated) {
			try
			{
				this.DismissWithClickedButtonIndex(0,animated);
			}
			catch(Exception ex)
			{
				//Log.LogError("error in Hide ",ex);
			}
		}

	}		
}

