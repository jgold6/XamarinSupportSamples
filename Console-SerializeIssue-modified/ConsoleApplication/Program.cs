using PclLib;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Student studentA = new Student("Student A", 18);
            Student studentB = null;
			const string xmlFilePath = "DataContractSerializerExample.xml";

			try
			{
				// WriteObject("DataContractSerializerExample.xml");
				Console.WriteLine(
					"Creating a Student object and serializing it.");
				FileStream writer = new FileStream(xmlFilePath, FileMode.Create);
				DataContractSerializer ser =
					new DataContractSerializer(typeof(Student));
				ser.WriteObject(writer, studentA);
				writer.Close();


				// ReadObject("DataContractSerializerExample.xml");
				Console.WriteLine("Deserializing an instance of the object.");
				FileStream fs = new FileStream(xmlFilePath,
					FileMode.Open);
				XmlDictionaryReader reader =
					XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
				DataContractSerializer des = new DataContractSerializer(typeof(Student));

				// Deserialize the data and read it from the instance.
				studentB = (Student)des.ReadObject(reader, true);
				reader.Close();
				fs.Close();
				Console.WriteLine(String.Format("{0} {1}", studentB.Name, studentB.Age));

			}

			catch (SerializationException serExc)
			{
				Console.WriteLine("Serialization Failed");
				Console.WriteLine(serExc.Message);
			}
			catch (Exception exc)
			{
				Console.WriteLine(
					"The serialization operation failed: {0} StackTrace: {1}",
					exc.Message, exc.StackTrace);
			}

			finally
			{
				Console.WriteLine("Press <Enter> to exit....");
				Console.ReadLine();
			}
//            BinaryFormatter binaryFormatter = new BinaryFormatter();
//            using (Stream stream = new MemoryStream())
//            {
//                binaryFormatter.Serialize(stream, studentA);
//                stream.Seek(0, SeekOrigin.Begin);
//                studentB = (Student)binaryFormatter.Deserialize(stream);
//            }
//			Console.WriteLine(studentB);
        }
    }
}