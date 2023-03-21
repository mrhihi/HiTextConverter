using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HiTextConverter
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
                ShowWindow(h, 0);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmHiTextConvert());
            }
            else
            {
                var converter = new Converter(new ConsoleLogger());

                converter.DoConvert(args);

                Console.WriteLine("按任意鍵繼續 ....");
                Console.ReadKey();
            }


        }
    }
}
