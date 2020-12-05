using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CSEng.XmlConverter.Model
{
	public class XmlConverter : IConverter
	{
		#region Implement of interface.
		/// <summary>
		/// Convert xml file without change line to with change.
		/// </summary>
		/// <param name="srcFilePath">Path to file to convert.</param>
		/// <returns>Created file path.</returns>
		public string Convert(string srcFilePath)
		{
			try
			{
				string dstFilePath = this.CreateDstFilePath(srcFilePath);
				XDocument xDoc = XDocument.Load(srcFilePath);
				using (var writer = new XmlTextWriter(dstFilePath, System.Text.Encoding.UTF8))
				{
					writer.Formatting = System.Xml.Formatting.Indented;
					writer.Indentation = 4;
					xDoc.Save(writer);
				}

				return dstFilePath;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);

				throw;
			}
		}
		#endregion

		#region private and protected methods.
		/// <summary>
		/// Create path to destination file from source.
		/// </summary>
		/// <param name="srcFilePath">Path to source file.</param>
		/// <returns>Path to destination file.</returns>
		/// <remarks>
		/// If the source file path does not have extention, that of destination file is "xml".
		/// </remarks>
		protected string CreateDstFilePath(string srcFilePath)
		{
			string fileName = Path.GetFileNameWithoutExtension(srcFilePath);
			string extName = string.Empty;
			if (Path.HasExtension(srcFilePath))
			{
				extName = Path.GetExtension(srcFilePath);
			}
			else
			{
				extName = ".xml";
			}

			string newFileName = fileName + "_formatted" + extName;
			string newFilePath = Path.Combine(Path.GetDirectoryName(srcFilePath), newFileName);
			return newFilePath;
		}
		#endregion
	}
}
