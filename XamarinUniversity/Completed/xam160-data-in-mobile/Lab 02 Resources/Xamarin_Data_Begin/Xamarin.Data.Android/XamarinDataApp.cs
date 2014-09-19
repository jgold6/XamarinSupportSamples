using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Data.Core;

namespace Xamarin.Data.Droid
{
    [Application]
    class XamarinDataApp : Application
    {
        private static DataManager _DataManager;
        public static DataManager DataManager
        {
            get {
                //TODO: Step 12a - Android - Remove placeholder return
                return null;
                //TODO: Step 12b - Android - Provide an instance of DataManager
//                return _DataManager ?? (_DataManager = new DataManager(new Platform()));
            }
        }

        public XamarinDataApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}