using System;
using System.Linq;
using System.Collections.Generic;

namespace XamarinUniversity
{
	public static class InstructorData
	{
		public static List<Instructor> Instructors { get; private set; }

		static InstructorData()
		{
			var temp = new List<Instructor>();

			AddInstructors(temp);
			//AddInstructors(temp);
			//AddInstructors(temp);
			//AddInstructors(temp);
			//AddInstructors(temp);

			Instructors = temp.OrderBy(i => i.Name).ToList();
		}

		static void AddInstructors(List<Instructor> instructors)
		{
			instructors.Add(new Instructor()
			{
				Name      = "Adrian Stevens",
				Specialty = "C# and C++ cross-platform development",
				ImageUrl  = "images/adrian-stevens.jpg",
				Biography = "Adrian Stevens has over 14 years of experience developing mobile applications; specializing in C# & C++ cross platform development.  Prior to join Xamarin as an instructor, Adrian had released several very successful mobile applications developed using Xamarin.iOS & Xamarin.Android."
			});

			instructors.Add(new Instructor()
			{
				Name      = "Chris Van Wyk",
				Specialty = "iOS and Windows Phone",
				ImageUrl  = "images/chris-van-wyk.jpg",
				Biography = "Chris van Wyk started his developer career in 1997 mainly developing and teaching Delphi and Pascal. He switched to C# and Mono in 2004, getting involved in both back and front-end development. Since then, he has worked with both dynamic and static languages, but always came back to C#. With the release of MonoTouch initially under Novell, the development story was just too enticing not to explore and he's been hooked since then."
			});

			instructors.Add(new Instructor()
			{
				Name      = "Glenn Stephens",
				Specialty = "iOS and Android",
				ImageUrl  = "images/glenn-stephens.jpg",
				Biography = "Glenn Stephens has been writing software commercially for over 22 years. A published author, he has worked in teams large and small as well as a range of industries including health, security, finance and education, Glenn's key areas include iOS, Android, Back-end Integration and Architecture. Glenn holds a Bachelor of Computer Science and an MBA with a ebusiness specialization."
			});

			instructors.Add(new Instructor()
			{
				Name      = "Mark Smith",
				Specialty = "Mobile development with Xamarin tools",
				ImageUrl  = "images/mark-smith.jpg",
				Biography = "Mark Smith has been crafting software for more than 20 years. He spent many years working on distributed systems with C/C++ and COM, and moved to .NET when Microsoft shipped the first preview at the PDC in 2000. Today, Mark focuses on mobile development with Xamarin tools and on building and designing curriculum for Xamarin University."
			});

			instructors.Add(new Instructor()
			{
				Name      = "Michael Stonis",
				Specialty = "Xamarin.Android and Xamarin.iOS",
				ImageUrl  = "images/michael-stonis.jpg",
				Biography = "Michael Stonis is a partner at Eight-Bot, a software consultancy in Chicago, where he focuses on mobile and integration solutions for enterprises using .Net. He loves mobile technology and how it has opened up our world in new and interesting ways that seemed like an impossibility just a few years ago. He is always looking for new challenges and ways to make things better."
			});

			instructors.Add(new Instructor()
			{
				Name      = "René Ruppert",
				Specialty = "iOS APIs",
				ImageUrl  = "images/rene-ruppert.jpg",
				Biography = "René started to program games in Turbo Pascal back in the 1990s and later studied and became MSc in Computer Science. He built highly interactive web applications before the term \"Web 2.0\" was used. Over the years it turned out that C# is the language he loves and used it a lot while working on an online document collaboration platform using ASP.Net with a strong focus on security, encryption and performance."
			});

			instructors.Add(new Instructor()
			{
				Name      = "Rob Gibbens",
				Specialty = "Hacking",
				ImageUrl  = "images/rob-gibbens.jpg",
				Biography = "Rob Gibbens is a community advocate, a Xamarin University trainer, a Spartan, a long time .net developer, cofounder of Detroit Mobile .Net User Group, and owner of Artek Software. When he is not creating applications for the man or cheering for the Green and White, he is hacking is own world, spawning a passion for mobile app development to hack his devices, creation of TekConf.com to hack his community, and a never-ending drive to level up."
			});

			instructors.Add(new Instructor()
			{
				Name      = "Roger Peters",
				Specialty = "All things mobile",
				ImageUrl  = "images/roger-peters.jpg",
				Biography = "Roger Peters is an independent mobile strategist and developer, and the owner of All Mobile Everything, his personal mobile consultancy in Atlanta. Roger (aka @SmartyP) has been blogging on app and game development at SmartyPantsCoding.com since 2008, and has created digital experiences for nearly 20 years."
			});
		}
	}
}