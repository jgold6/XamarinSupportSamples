using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using SysSound.Extensions;
using MonoTouch.AudioToolbox;
using MonoTouch.AVFoundation;

namespace SysSound {
	
	public partial class SysSoundViewController : UIViewController {
		
		//loads the SysSoundViewController.xib file and connects it to this object
		public SysSoundViewController () 
			: base ("SysSoundViewController", null) {
		}
		
		//holds the sound to play
//		private SystemSound Sound; // Deprecated
		AVAudioPlayer player; // new API for Audio playback

		//prepares the audio
		public override void ViewDidLoad () {
			base.ViewDidLoad ();
			
			//enable audio
//			AudioSession.Initialize(); // Deprecated
			AVAudioSession audioSess = AVAudioSession.SharedInstance(); // New API for Audio Sessions

			//load the sound
//			Sound = SystemSound.FromFile("Sounds/tap.aif"); // Deprecated
			player = AVAudioPlayer.FromUrl(new NSUrl("Sounds/tap.aif")); // new Audio PLayer API
			player.PrepareToPlay();
		}
		
		partial void playSystemSound(NSObject sender) {
//			Sound.PlaySystemSound();  // Deprecated
			player.Play();
		}
		
		partial void playAlertSound (NSObject sender) {
//			Sound.PlaySystemSound();  // Deprecated
			player.Play();
		}

		partial void vibrate (NSObject sender) {
			SystemSound.Vibrate.PlaySystemSound();
		}
		
	}

	
}
