using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTextConverter
{
    class EmptyLogger: ILogger
    {
        public void WriteLine(string value)
        {
        }

        public void Write(string format, params object[] arg)
        {
        }
    }
}
