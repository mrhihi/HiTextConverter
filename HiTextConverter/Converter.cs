using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTextConverter
{
    class Converter
    {
        private ILogger logger { get; set; }
        public Converter(ILogger logger)
        {
            this.logger = logger;
        }
        public void DoConvert(string[] args)
        {
            Parallel.ForEach(args, filePath =>
            {
                if (!validateFile(filePath))
                {
                    logger.WriteLine("檔案不存在或格式不正確！");
                    return;
                }
                logger.Write(string.Format("{0}:檔案 {1} 處理中。", DateTime.Now, filePath));

                convert(filePath);

                logger.WriteLine(string.Format(" ...... {0} 完成。", DateTime.Now));
            });
        }

        static bool validateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }
            return true;
        }

        static void convert(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var fsr = new StreamReader(fs, Encoding.GetEncoding(950), true))
                {
                    string s = fsr.ReadToEnd();
                    var encoding = fsr.CurrentEncoding;
                    using (var w = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        byte[] b = Encoding.Convert(encoding, Encoding.UTF8, encoding.GetBytes(s));
                        w.Write(Encoding.UTF8.GetString(b));
                    }
                }
            }
        }
    }
}
