using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace forms_ping
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control outputBox = this.Controls.Find("richTextBox1", false)[0];
            Control inputBox = this.Controls.Find("textBox1", false)[0];
            outputBox.Text = "";

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c \"chcp 437 & ping "+ inputBox.Text +"\"";
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            string buffer = null;
            do
            {
                buffer = p.StandardOutput.ReadLine();
                if(buffer != null && buffer != "Active code page: 437")
                    outputBox.Text += buffer + "\n";
                this.Refresh();
            } while (buffer != null);
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode.ToString() == "Return")
                button1_Click(null, null);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
