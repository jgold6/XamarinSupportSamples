using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace NSTableViewTest
{
	[Register("Person")]
	public class Person : NSObject
	{
		public Person()
		{
			
		}

		public Person (IntPtr handle) : base(handle)
		{
			
		}

		private string m_name;
		private string m_surname;
		private int m_age;


		[Export("Name")]
		public string Name 
		{
			get { return m_name; }
			set 
			{ 
				WillChangeValue ("Name");
				m_name = value;
				DidChangeValue ("Name");
			}
		}


		[Export("Surname")]
		public string Surname 
		{
			get { return m_surname; }
			set 
			{ 
				WillChangeValue ("Surname");
				m_surname = value;
				DidChangeValue ("Surname");
			}
		}

		[Export("Age")]
		public int Age 
		{
			get { return m_age; }
			set 
			{ 
				WillChangeValue ("Age");
				m_age = value;
				DidChangeValue ("Age");
			}
		}

		public Person (string name, string surname, int age)
		{
			Name = name;
			Surname = surname;
			Age = age;
		}
	}
}

