using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LatteDB
{
	public class LatteDB : IDisposable
	{
		protected Stream store;
		
		protected LatteDB()
		{
		}
		
		public LatteDB (string filename)
		{
			store = new FileStream(filename, FileMode.OpenOrCreate);
		}
		
		public void Save(object obj)
		{
			var jsonString = JsonConvert.SerializeObject(obj);
			AddToFile(jsonString);
		}
		
		protected virtual void AddToFile(string jsonString)
		{
			using(var streamWriter = new StreamWriter(store)){
				streamWriter.WriteLine(jsonString);
			}
		}
		
		public IList<T> GetAll<T>()
		{
			var all = new List<T>();
			
			using(var streamReader = new StreamReader(store))
			{
				string line;
				while((line = streamReader.ReadLine()) != null)
				{
					T deserializedObject = JsonConvert.DeserializeObject<T>(line);
					all.Add(deserializedObject);
				}
			}
				
			return all;
		}
		
		public void Dispose ()
		{
			store.Close();
		}
	}
}
