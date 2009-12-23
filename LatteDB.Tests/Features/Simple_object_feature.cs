using System;
using NUnit.Framework;

namespace LatteDB.Tests
{
	[TestFixture()]
	public class Simple_object_feature
	{
		[Test()]
		public void should_save_and_retrieve_same_object_contents ()
		{
			var database = new LatteDB("cars.db");
			
			Car savedCar = new Car("Volvo");
			database.Save(savedCar);
			
			database = new LatteDB("cars.db");
			var retrievedCar = database.GetAll<Car>()[0];
			
			Assert.AreEqual(savedCar.Brand, retrievedCar.Brand);
		}
	}
	
	class Car
	{
		public string Brand { get; set; }
		
		public Car(string brand)
		{
			Brand = brand;
		}
	}
}
