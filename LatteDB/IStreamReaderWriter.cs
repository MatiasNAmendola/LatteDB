using System;
using System.Collections.Generic;

namespace LatteDB
{
	public interface IStreamReaderWriter
	{
		void AppendToStream(string stringToAppend);
		IList<string> ReadAllLines();
	}
}