using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LatteDB
{
	public class LatteDB
	{
		protected IStreamHandler _streamHandler;

		public LatteDB ()
		{
			var filename = "database.db";
			_streamHandler = new FileStreamHandler(filename);
		}

		public LatteDB (string filename)
		{
			_streamHandler = new FileStreamHandler(filename);
		}

		public void Save<T> (T obj)
		{
			var jsonString = JsonConvert.SerializeObject (obj);
			_streamHandler.AppendToStream(typeof(T) + ":" + jsonString);
		}

		public IList<T> GetAll<T> ()
		{
			var all = new List<T> ();
			
			IList<string> allLines = _streamHandler.ReadAllLines();
			foreach(string line in allLines)
			{
				var typeName = GetTypeNameFromLine(line);
				
				if(typeName == typeof(T).ToString())
				{
					T deserializedObject = JsonConvert.DeserializeObject<T> (GetJsonFromLine(line));
					all.Add (deserializedObject);
				}
			}
			
			return all;
		}
		
		public string GetTypeNameFromLine (string line)
		{
			var semicolonAfterTypeNameIndex = line.IndexOf(':');
			return line.Substring(0, semicolonAfterTypeNameIndex);
		}
		
		public string GetJsonFromLine(string line)
		{
			var semicolonAfterTypeNameIndex = line.IndexOf(':');
			return line.Substring(semicolonAfterTypeNameIndex + 1);
		}
	}
}