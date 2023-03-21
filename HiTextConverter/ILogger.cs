using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTextConverter
{
    interface ILogger
    {
        void WriteLine(string value);
        void Write(string format, params object[] arg);
    }
}
