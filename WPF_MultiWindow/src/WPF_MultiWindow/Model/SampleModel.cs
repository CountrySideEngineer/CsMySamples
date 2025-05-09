using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MultiWindow.Model
{
    internal class SampleModel
    {
        protected ulong _sampleValue = 0;

        public SampleModel() { }

        public SampleModel(ulong sampleValue)
        {
            _sampleValue = sampleValue;
        }

        public ulong UpdateValue()
        {
            _sampleValue++;

            return _sampleValue;
        }
    }
}
