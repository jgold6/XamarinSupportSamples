using System;
using System.Reflection;
using Android.App;
using Android.Runtime;
using Xamarin.Android.NUnitLite;
namespace MyApp.Droid.Tests
{
	[Instrumentation]
	public class TestInstrumentation : TestSuiteInstrumentation
	{
		public TestInstrumentation(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
		protected override void AddTests()
		{
			//Xamarin.Forms.Forms.Init((Activity)this.Context, new Android.OS.Bundle());
			// tests can be inside the main assembly
			//AddTest(Assembly.GetExecutingAssembly());
			// or in any reference assemblies
			// AddTest (typeof (Your.Library.TestClass).Assembly);
			AddTest (Assembly.GetExecutingAssembly ());
		}
		// I tried adding an override to CallActivityOnCreate and that didn’t help so I removed it.
//		public override void CallActivityOnCreate(Activity activity, Bundle icicle)
//		{
//			Xamarin.Forms.Forms.Init(activity, icicle);
//			base.CallActivityOnCreate(activity, icicle);
//		}
	}
}

