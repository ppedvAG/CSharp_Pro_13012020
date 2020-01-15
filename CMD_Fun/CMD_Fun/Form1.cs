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



            // Start the asynchronous read of the sort output stream.

            proc.OutputDataReceived += Proc_OutputDataReceived;
            proc.BeginOutputReadLine();
            //while (!proc.HasExited)
            //{
            //    Application.DoEvents(); // This keeps your form responsive by processing events
            //}
        }

        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(e.Data); });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var writer = proc.StandardInput;
            writer.WriteLine("ping google.de /t");
        }
    }
}
