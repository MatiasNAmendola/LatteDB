using System;
using System.Collections.Generic;

namespace LatteDB
{
	public interface IStreamHandler
	{
		void AppendToStream(string stringToAppend);
		IList<string> ReadAllLines();
	}
}