using System;
//TODO: Step 4a - Using SQLite in Speaker model
using SQLite.Net.Attributes;

namespace Xamarin.Data.Core.Model
{
	public class Speaker
	{
		//TODO: Step 4b - Add a primary key in Speaker model
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Company { get; set; }

		public string Bio { get; set; }

		public string TwitterHandle { get; set; }

		public string ImageUrl { get; set; }

		public Speaker ()
		{
		}
	}
}

