using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace TestYouTube
{
	public class YouTubeViewer : UIWebView
	{
		public YouTubeViewer(string url, RectangleF frame)
		{
			string youTubeVideoHTML = @"<object width=""{1}"" height=""{2}""><param name=""movie""
value=""{0}""></param><embed
src=""{0}"" type=""application/x-shockwave-flash"" 
width=""{1}"" height=""{2}""</embed></object>"; 

			string html = string.Format(youTubeVideoHTML, url, frame.Size.Width, frame.Size.Height);
			this.LoadHtmlString(html, null);
			this.Frame = frame;
		}
	} 
}

