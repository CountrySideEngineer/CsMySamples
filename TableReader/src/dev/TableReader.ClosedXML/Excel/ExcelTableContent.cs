using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableReader.TableData;

namespace TableReader.Excel
{
	class ExcelTableContent : Content
	{
		public IEnumerable<IEnumerable<string>> TableContent
		{
			get
			{
				return base._tableContent;
			}
			set
			{
				base._tableContent = value;
			}
		}
	}
}
