using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTextConverter
{
    class ConsoleLogger : ILogger
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }


        public void Write(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }
    }
}
