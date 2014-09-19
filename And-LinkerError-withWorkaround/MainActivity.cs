using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Linker
{
	[Activity (Label = "Linker", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate 
			{
				try
				{
				List<Data> collection = new List<Data>();
				collection.Add(new Data { FirstName = "Andry", LastName = "Soesilo" });
				collection.Add(new Data { FirstName = "Andrew", LastName = "Soesilo" });
				collection.Add(new Data { FirstName = "Andrew", LastName = "Fran" });

				collection.Where(o => o.LastName == "Soesilo").ToList();

				PropertyInfo propertyInfo = typeof(Data).GetProperty("LastName");

				ParameterExpression parameterExpression = Expression.Parameter(typeof(Data), "item");
				MemberExpression memberExpression = Expression.MakeMemberAccess(parameterExpression, propertyInfo);
				ConstantExpression valueExpression = Expression.Constant("Soesilo");
				BinaryExpression expression = Expression.Equal(memberExpression, valueExpression);

				Expression.Lambda(expression, new[] {parameterExpression});

				button.Text = string.Format ("{0} clicks!", count++);
				}
				catch (Exception ex)
				{
					button.Text = ex.Message;
				}
			};
		}
	}

	public class Data
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}


