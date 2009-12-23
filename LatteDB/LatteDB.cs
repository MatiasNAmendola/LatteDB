using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LatteDB
{
	public class LatteDB
	{
		Dictionary<Guid, string> store = new Dictionary<Guid, string>();

		public LatteDB (string filename)
		{
		}
		
		public void Save(object obj)
		{
			var jsonObject = JsonConvert.SerializeObject(obj);
			var id = Guid.NewGuid();
			store.Add(id, jsonObject);
		}
		
		public IList<T> GetAll<T>()
		{
			var all = new List<T>();
			foreach(var keyValuePair in store)
			{
				T deserializedObject = JsonConvert.DeserializeObject<T>(keyValuePair.Value);
				all.Add(deserializedObject);
			}
			
			return all;
		}
	}
}
