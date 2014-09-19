
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.AVFoundation;
using System.IO;

namespace XamMacAudio
{
    public partial class MainWindowController : MonoMac.AppKit.NSWindowController
    {
		private bool isPlaying;
		private bool isRecording;
		private bool hasRecorded;
		string path;
		string fileName;

		AVAudioRecorder recorder;
		AVAudioPlayer player;
		NSError error = new NSError(new NSString("com.rpr.mobile.ios"), 1);
		NSUrl url;
		NSDictionary settings;

        #region Constructors

        // Called when created from unmanaged code
        public MainWindowController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        
        // Call to load from the XIB/NIB file
        public MainWindowController() : base("MainWindow")
        {
            Initialize();
        }
        
        // Shared initialization code
        void Initialize()
        {
        }

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			this.init();

		}

		partial void btnPlay_Click (NSObject sender)
		{
			Console.WriteLine("Play");
			this.play();
		}

		partial void btnRecord_Click (NSObject sender)
		{
			Console.WriteLine("Record");
			this.record();
		}

		partial void btnStop_Click (NSObject sender)
		{
			Console.WriteLine("Stop");
			this.stop();
		}

        #endregion

        //strongly typed window accessor
        public new MainWindow Window
        {
            get
            {
                return (MainWindow)base.Window;
            }
        }


		private void init() {

			var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			var library = Path.Combine (documents, "Library");
			this.path = new DirectoryInfo (Path.Combine (library, "Caches")).FullName;
			//Declare string for application temp path and tack on the file extension
			this.fileName = String.Format ("audionote{0}.mp4", DateTime.Now.Ticks.ToString ());
			string audioFilePath = Path.Combine(path, fileName);
			var fi = new FileInfo (audioFilePath);
			if (!fi.Exists)
				fi.Create ();

			url = NSUrl.FromFilename(audioFilePath);

			//set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
			NSObject[] values = new NSObject[]
			{
				NSNumber.FromFloat (8000.0f), //Sample Rate
				NSNumber.FromInt32 ((int)MonoMac.AudioToolbox.AudioFormatType.MPEG4AAC), //AVFormat
				NSNumber.FromInt32 (1), //Channels
				NSNumber.FromInt32 (8), //PCMBitDepth
				NSNumber.FromBoolean (false), //IsBigEndianKey
				NSNumber.FromBoolean (false) //IsFloatKey
			};

			//Set up the NSObject Array of keys that will be combined with the values to make the NSDictionary
			NSObject[] keys = new NSObject[]
			{
				AVAudioSettings.AVSampleRateKey,
				AVAudioSettings.AVFormatIDKey,
				AVAudioSettings.AVNumberOfChannelsKey,
				AVAudioSettings.AVLinearPCMBitDepthKey,
				AVAudioSettings.AVLinearPCMIsBigEndianKey,
				AVAudioSettings.AVLinearPCMIsFloatKey
			};

			//Set Settings with the Values and Keys to create the NSDictionary
			settings = NSDictionary.FromObjectsAndKeys (values, keys);

			//Set recorder parameters
			recorder = AVAudioRecorder.ToUrl(url, settings, out error);

			if (error != null) {
				Console.Write("There was an error attempting to initialize the recorder for a new audio recording. Dismiss this view and try again. ");
			} else {
				recorder.PrepareToRecord ();
			}
		}

		private void record() {
			Console.WriteLine ("Starting recording...");
			if (!this.isRecording) {
				this.isRecording = true;
				try {
					this.recorder.Record ();
					this.player = null;
				} catch (Exception ex) {
					Console.WriteLine (ex.ToString ());
				}
			}
		}

		private void stop() {
			Console.WriteLine ("Stopping recording...");
			if (recorder != null) {
				recorder.Stop ();

				this.isRecording = false;
				this.hasRecorded = true;
			}
			if (player != null) {
				this.isPlaying = false;
				player.Stop ();
			}
		}

		private void play() {
			if (this.hasRecorded) {
				Console.WriteLine ("Starting playback...");
				this.isPlaying = true;
				if (this.player == null) {
					try {
						this.player = AVAudioPlayer.FromUrl (this.url, out error);
						this.player.FinishedPlaying += (object s, AVStatusEventArgs e) => {
							this.isPlaying = false;
						};
					} catch (Exception exc) {
						Console.WriteLine (exc.ToString ());
					}
				}
				if (this.player != null) {

					this.player.Play ();
				}
			}
		}

    }
}

