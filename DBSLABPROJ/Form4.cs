﻿using System;
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
using Gecko;
namespace DBSLABPROJ
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            
        }
        private string uname;
        public Form4(string na )
        {
            this.uname = na;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            l1.Text = "Logged in as " + uname.ToUpper() + " !";  
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private string result;

        private void run_cmd(string cmd, string args)
        {
            //System.Diagnostics.Process proc = new System.Diagnostics.Process;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"complete_Location_Where_Your_Python.exe_File_Is_Present";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
            outp.Text = result;            
            geckoWebBrowser1.Navigate("file:///complete_Location_Where_You_Want_To_Save_map.html");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string fname = "complete_Location_Of_make_html_py3.py_File";
            string src = source.Text;
            string dst = dest.Text;
            string cmd = string.Format("{0}",fname);
            string arg = string.Format("{0} {1}", src, dst);
            run_cmd(cmd, arg);
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void geckoWebBrowser1_Click(object sender, EventArgs e)
        {

        }
    }
}
