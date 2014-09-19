using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace PclLib
{
	#if PORTABLE
	[DataContract]
	#else
	[Serializable]
	#endif
    public class Student
    {
		[DataMember]
        private string name;
		[DataMember]
        private int age;

        public Student()
            : this(null, 0)
        { }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}, {1}", name, age);
        }

//        [OnSerializing]
//        private void OnSerializing(StreamingContext context)
//        {
//            Debug.WriteLine("Student OnSerializing");
//        }
    }
}