using System;
using System.IO;
using NUnit.Framework;

namespace LatteDB.Tests
{
	[TestFixture]
	public class Simple_object_feature
	{
		const string DATABASE_FILENAME = "database.db";
		
		[TestFixtureTearDown]
		public void TearDown()
		{
			File.Delete(DATABASE_FILENAME);
		}
		
		[Test]
		public void should_save_and_retrieve_same_object_contents ()
		{
			Car savedCar = new Car("Volvo");
			
			var saveDatabase = new LatteDB(DATABASE_FILENAME);
			saveDatabase.Save(savedCar);
			
			var readDatabase = new LatteDB(DATABASE_FILENAME);
			
			var retrievedCar = readDatabase.GetAll<Car>()[0];
			Assert.AreEqual(savedCar.Brand, retrievedCar.Brand);
		}
		
		[Test]
		public void should_save_and_retrieve_objects_of_different_types_in_same_database ()
		{
			Car savedCar = new Car("Volvo");
			Airplane savedPlane = new Airplane("Airbus", "A380");
			
			var saveDatabase = new LatteDB(DATABASE_FILENAME);
			saveDatabase.Save(savedCar);
			saveDatabase.Save(savedPlane);
			
			var readDatabase = new LatteDB(DATABASE_FILENAME);
			var retrievedCar = readDatabase.GetAll<Car>()[0];
			Assert.AreEqual(savedCar.Brand, retrievedCar.Brand);
			
			var retrievedPlane = readDatabase.GetAll<Airplane>()[0];
			Assert.AreEqual(savedPlane.Maker, retrievedPlane.Maker);
			Assert.AreEqual(savedPlane.Model, retrievedPlane.Model);
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
	
	class Airplane
	{
		public string Maker { get; private set; }
		public string Model { get; private set; }
		
		public Airplane(string maker, string model)
		{
			Maker = maker;
			Model = model;
		}
	}
}
