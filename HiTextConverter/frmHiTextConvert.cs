using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiTextConverter
{
    public partial class frmHiTextConvert : Form
    {
        string currentFolder { get; set; }

        public frmHiTextConvert()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult folder = folderBrowserDialog1.ShowDialog();
            if (folder == DialogResult.OK)
            {
                currentFolder = folderBrowserDialog1.SelectedPath;
                label1.Text = currentFolder;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            convertFolder(currentFolder);
            MessageBox.Show("轉換完成！");
        }

        private void convertFolder(string folder)
        {
            if (Directory.Exists(folder))
            {
                var files = Directory.GetFiles(folder);
                var converter = new Converter(new EmptyLogger());
                converter.DoConvert(files);
                var folders = Directory.GetDirectories(folder);
                Parallel.ForEach(folders, d =>
                {
                    convertFolder(d);
                });
            }
            else
            {
                MessageBox.Show(string.Format("目錄不存在：{0}", folder));
            }
        }
    }
}
