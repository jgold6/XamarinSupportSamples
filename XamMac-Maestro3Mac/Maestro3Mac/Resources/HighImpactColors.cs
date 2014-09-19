using System;
using MonoMac.AppKit;
using MonoMac.CoreGraphics;

namespace Maestro3Mac
{
	public class HighImpactColors
	{
		#region High Impact Colors MAC
		public static CGColor HIGreen {
			get { return new CGColor (.1216f, .4980f, .3608f); }
		}
		public static CGColor HIForestGreen {
			get { return new CGColor (.1569f, .3216f, .3451f); }
		}
		public static CGColor HILightBlue {
			get { return new CGColor (.3529f, .6039f, .6588f); }
		}
		public static CGColor HIBlue {
			get { return new CGColor (.1412f, .5373f, .7725f);}
		}
		public static CGColor HIPurple { 
			get { return new CGColor (.4157f, .3529f, .5490f); }
		}
		public static CGColor HILavander {
			get { return new CGColor (.5490f, .3647f, .4745f); }
		}
		public static CGColor HIPink { 
			get { return new CGColor (.8980f, .4235f, .4118f); }
		}
		public static CGColor HIOrange { 
			get { return new CGColor (.8706f, .5255f, .313f); } 
		}
		public static CGColor HIRed { 
			get { return new CGColor (.4431f, .0862f, .0745f); }
		}
		public static CGColor HIGray00 {
			get{ return new CGColor (.9412f, .9412f, .9412f); } 
		}
		public static CGColor HIGray01 {
			get{ return new CGColor (.8235f, .8235f, .8235f); }
		}
		public static CGColor HIGray02 {
			get{ return new CGColor (.3137f, .3137f, .3137f); }
		}
		public static CGColor HIGray03 { 
			get{ return new CGColor (.1765f, .1765f, .1765f); }
		}
		public static CGColor HIGray04 { 
			get{ return new CGColor (.1373f, .1373f, .1373f); }
		}
		public static CGColor HIGray05 { 
			get{ return new CGColor (.09803f, .09803f, .09803f); }
		}
		public static CGColor HIGray06 { 
			get{ return new CGColor (0, 0, 0); }
		}
		public static CGColor HIGray30Percent {
			get{ return new CGColor (80, 80, 80); }
		}
		public static CGColor HIGray65Percent {
			get{ return new CGColor (166, 166, 166);}
		}
			
		#endregion

		#region Brushes
		#endregion

	}
}

