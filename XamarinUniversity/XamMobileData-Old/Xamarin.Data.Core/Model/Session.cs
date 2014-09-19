using System;
//TODO: Step 3a - Using SQLite in Session model
using SQLite.Net.Attributes;

namespace Xamarin.Data.Core.Model
{
	public class Session
	{
		//TODO: Step 3b - Add a primary key in Session model
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

		//TODO: Step 3c - Mark column that you will not persist
        [Ignore()]
		public Speaker Speaker { get; set; }

		public string SpeakerName { get; set; }

		public string Title { get; set; }

		public string Abstract { get; set; }

		public string Location { get; set; }

		public DateTime Begins { get; set; }

		public DateTime Ends { get; set; }

		public Session ()
		{
		}
	}
}