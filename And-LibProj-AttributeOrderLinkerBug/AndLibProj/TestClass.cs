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
using System.Runtime.Serialization;


namespace AndLibProj
{

	// Works, methods do not get linked away
//	[DataContract]
//	[Preserve(AllMembers=true)]
	// Doesn't work, methods get linked away
	[Preserve(AllMembers=true)] 
	[DataContract]
	public class TestClass
	{
		public void Foo(string first, string last){
			Console.WriteLine("Foo Called {0} {1}", first, last);
		}

		//[DataMember]
		public int Bar { get; set; }
	}
}

