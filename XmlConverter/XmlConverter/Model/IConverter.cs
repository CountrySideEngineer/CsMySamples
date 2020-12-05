using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEng.XmlConverter.Model
{
	/// <summary>
	/// Interface class to convert file into other format.
	/// </summary>
	public interface IConverter
	{
		/// <summary>
		/// Convert file.
		/// </summary>
		/// <param name="srcFilePath">Path to file to convert.</param>
		/// <returns>Path to the result file.</returns>
		string Convert(string srcFilePath);
	}
}
