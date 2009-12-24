//using System;
//using System.IO;
//using NUnit.Framework;
//
//namespace LatteDB.Tests
//{
//	[TestFixture()]
//	public class LatteDB_when_reading_from_a_file
//	{
//		[Test()]
//		public void should_read_json_from_a_stream ()
//		{
//			Stream fakeStream = new MemoryStream();
//			var streamWriter = new StreamWriter(fakeStream);
//			streamWriter.WriteLine("{\"Brand\":\"Volvo\"}");
//			
//			var database = new MockLatteDB();
//			database.SetStream(fakeStream);
//			
//			Assert.AreEqual("{\"Brand\":\"Volvo\"}", database.ReadLine();
//		}
//	}
//	
//	class MockLatteDB : LatteDB
//	{
//		public void SetStream(Stream fakeStream)
//		{
//			store = fakeStream;
//		}
//		
//		public override string ReadLine (StreamReader streamReader)
//		{
//			return base.ReadLine (streamReader);
//		}
//
//	}
//}