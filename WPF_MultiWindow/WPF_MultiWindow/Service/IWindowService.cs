using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MultiWindow.Service
{
    internal interface IWindowService<TContext>
    {
        bool? ShowNew(TContext context);
        void Close(TContext context);
    }
}
