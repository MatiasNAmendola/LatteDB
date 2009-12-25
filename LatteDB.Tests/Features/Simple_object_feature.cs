using System;
using System.IO;
using NUnit.Framework;

namespace LatteDB.Tests
{
	[TestFixture()]
	public class Simple_object_feature
	{
		[Test()]
		public void should_save_and_retrieve_same_object_contents ()
		{
			string databaseName = "cars.db";
			Car savedCar = new Car("Volvo");
			
			using(var saveDatabase = new LatteDB(databaseName)){
				saveDatabase.Save(savedCar);
			}
			
			using(var readDatabase = new LatteDB(databaseName))
			{
				var retrievedCar = readDatabase.GetAll<Car>()[0];
				Assert.AreEqual(savedCar.Brand, retrievedCar.Brand);
			}
			
			File.Delete(databaseName);
		}
	}
	
	class Car
	{
		public string Brand { get; private set; }
		
		public Car(string brand)
		{
			Brand = brand;
		}
	}
}
