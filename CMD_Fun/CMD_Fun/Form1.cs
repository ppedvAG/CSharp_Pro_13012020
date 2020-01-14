using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMD_Fun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Process proc = new Process();
        private void button1_Click(object sender, EventArgs e)
        {
            proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.Start();


            //var writer = proc.StandardInput;
            //writer.WriteLine("ping");
            //writer.Flush();
            //writer.Close();

            //StreamReader reader = proc.StandardOutput;
            //string output = reader.ReadToEnd();
            //listBox1.Items.Add(output);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader reader = proc.StandardOutput;
            var writer = proc.StandardInput;
            writer.WriteLine("ping");
            //writer.Flush();
            //writer.Close();

            string output = reader.ReadToEnd();
            listBox1.Items.Add(output);
        }
    }
}
