using System;
using System.IO;
using System.Collections.Generic;

namespace LatteDB
{
	public class FileStreamReaderWriter : IStreamReaderWriter
	{
		protected readonly string _filename;
		
		public FileStreamReaderWriter (string filename)
		{
			_filename = filename;
		}
		
		public void AppendToStream (string stringToAppend)
		{
			using(var stream = new FileStream (_filename, FileMode.Append))
			{
				using (var streamWriter = new StreamWriter (stream)) {
					streamWriter.WriteLine(stringToAppend);
				}
			}
		}
		
		public IList<string> ReadAllLines()
		{
			var allLines = new List<string>();
			
			using (var stream = new FileStream (_filename, FileMode.OpenOrCreate)) {
				using (var streamReader = new StreamReader (stream)) {
					string line;
					while ((line = streamReader.ReadLine ()) != null) {
						allLines.Add(line);
					}
				}
			}
			
			return allLines;
		}

	}
}