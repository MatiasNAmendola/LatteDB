using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LatteDB.Tests
{
	[TestFixture()]
	public class LatteDB_when_reading_from_a_file
	{
		[Test()]
		public void should_extract_type_name_from_line()
		{
			var line = typeof(Car) + ":";
			var database = new LatteDB();
			var returnedTypeName = database.GetTypeNameFromLine(line);
			Assert.That(returnedTypeName, Is.EqualTo(typeof(Car).ToString()));
		}
		
		[Test()]
		public void should_extract_Json_from_line()
		{
			var json = "{\"Brand\":\"Volvo\"}";
			var line = typeof(Car) + ":" + json;
			var database = new LatteDB();
			var returnedJson = database.GetJsonFromLine(line);
			Assert.That(returnedJson, Is.EqualTo(json));
		}
		
		[Test()]
		public void should_be_able_to_find_specific_types ()
		{
			var streamHandlerStub = new MockStreamHandler();
			var database = new StubLatteDB(streamHandlerStub);
			
			var retrievedCar = database.GetAll<Car>()[0];
			
			Assert.That(retrievedCar.Brand, Is.EqualTo("Volvo"));
		}
	}
	
	class MockStreamHandler : IStreamHandler
	{
		public void AppendToStream (string stringToAppend)
		{
			throw new NotImplementedException();
		}
		
		public IList<string> ReadAllLines()
		{
			var allLines = new List<string>();
			allLines.Add(typeof(Car) + ":{\"Brand\":\"Volvo\"}");
			return allLines;
		}
	}
}