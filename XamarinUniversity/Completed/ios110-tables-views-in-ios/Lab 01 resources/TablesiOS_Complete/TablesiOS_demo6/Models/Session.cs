//
// Sessions.cs: Defines the Sessions class used for the table cells
//
// Copyright (C) 2013 Xamarin, Inc (http://www.xamarin.com)
//
using System;

namespace TablesDemo
{
	public class Session
	{
		public string Speaker { get; set; }

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

