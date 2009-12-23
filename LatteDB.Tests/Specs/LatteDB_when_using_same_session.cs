
using System;
using NUnit.Framework;

namespace LatteDB.Tests
{


	[TestFixture()]
	public class LatteDB_when_using_same_session
	{

		[Test()]
		public void should_save_and_retrieve_a_simple_object ()
		{
			var database = new LatteDB("irrelevant name");
			var savedCar = new Car("Volvo");
			database.Save(savedCar);
			var retrievedCar = database.GetAll<Car>()[0];
			Assert.AreEqual(savedCar.Brand, retrievedCar.Brand);
		}
	}
}
