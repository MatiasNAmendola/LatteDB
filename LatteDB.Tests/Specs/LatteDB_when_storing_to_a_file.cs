using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LatteDB.Tests
{
	[TestFixture]
	public class LatteDB_when_storing_to_a_file
	{
		[Test]
		public void should_append_typename_and_Json_to_file()
		{
			var streamHandlerStub = new StreamHandlerAppendStub();
			var database = new StubLatteDB(streamHandlerStub);
			var savedCar = new Car("Volvo");
			
			database.Save(savedCar);
			
			Assert.AreEqual(typeof(Car) + ":{\"Brand\":\"Volvo\"}", streamHandlerStub.AppendedString);
		}
		
		[Test]
		public void should_append_two_objects_to_file()
		{
			var streamHandlerStub = new StreamHandlerAppendStub();
			var database = new StubLatteDB(streamHandlerStub);
			var car1 = new Car("Volvo");
			var car2 = new Car("SAAB");
			
			database.Save(car1);
			database.Save(car2);
			
			Assert.AreEqual(typeof(Car) + ":{\"Brand\":\"SAAB\"}", streamHandlerStub.AppendedString);
		}
	}
	
	class StreamHandlerAppendStub : IStreamReaderWriter
	{
		public string AppendedString { get; set; }
		
		public void AppendToStream (string stringToAppend)
		{
			AppendedString = stringToAppend;
		}
		
		public IList<string> ReadAllLines()
		{
			throw new NotImplementedException();
		}
	}
	
	class StubLatteDB : LatteDB
	{
		
		public StubLatteDB(IStreamReaderWriter streamHandler)
		{
			_streamHandler = streamHandler;
		}
	}
}