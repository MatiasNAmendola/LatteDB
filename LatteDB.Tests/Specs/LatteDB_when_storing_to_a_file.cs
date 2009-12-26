using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LatteDB.Tests
{
	[TestFixture]
	public class LatteDB_when_storing_to_a_file
	{
		StreamHandlerAppendStub _streamHandlerAppendStub;
		LatteDB _database;
		
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			_streamHandlerAppendStub = new StreamHandlerAppendStub();
			ServiceLocator.RegisterInstance<IStreamReaderWriter>(_streamHandlerAppendStub);
		}
		
		[SetUp]
		public void SetUp()
		{
			_database = new LatteDB("database.db");
		}
		
		[Test]
		public void should_append_typename_and_Json_to_file()
		{
			var savedCar = new Car("Volvo");
			
			_database.Save(savedCar);
			
			Assert.AreEqual(typeof(Car) + ":{\"Brand\":\"Volvo\"}", _streamHandlerAppendStub.AppendedString);
		}
		
		[Test]
		public void should_append_two_objects_to_file()
		{
			var car1 = new Car("Volvo");
			var car2 = new Car("SAAB");
			
			_database.Save(car1);
			_database.Save(car2);
			
			Assert.AreEqual(typeof(Car) + ":{\"Brand\":\"SAAB\"}", _streamHandlerAppendStub.AppendedString);
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
}