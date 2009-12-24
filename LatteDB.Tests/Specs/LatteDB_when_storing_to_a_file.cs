using System;
using NUnit.Framework;

namespace LatteDB.Tests
{
	[TestFixture()]
	public class LatteDB_when_storing_to_a_file
	{
		[Test()]
		public void should_append_Json_to_file ()
		{
			var database = new StubLatteDB();
			var savedCar = new Car("Volvo");
			
			database.Save(savedCar);
			
			Assert.AreEqual("{\"Brand\":\"Volvo\"}", database.AppendedJson);
		}
	}
	
	class StubLatteDB : LatteDB
	{
		public string AppendedJson { get; set; }
		
		protected override void AddToFile (string jsonString)
		{
			AppendedJson = jsonString;
		}
	}
}