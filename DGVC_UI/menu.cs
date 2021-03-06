﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using TestProject;
using ConsoleApplication;

namespace DGVC_UI
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();

        }

        private void button_Click1(object sender, EventArgs e)
        {
            im("git status"); 
            textBox1.Text += Environment.NewLine;
        }
        private void button_Click2(object sender, EventArgs e)
        {
            im("git push");
            textBox1.Text += Environment.NewLine;
        }
        private void button_Click3(object sender, EventArgs e)
        {
            im("git pull");
            textBox1.Text += Environment.NewLine;
        }
        private void button_Click4(object sender, EventArgs e)
        {
            im("git add .");
            textBox1.Text += Environment.NewLine;
        }
        private void button_Click5(object sender, EventArgs e)
        {
            string tr = "git commit -m ";
            OK frmAbout = new OK();
            frmAbout.ShowDialog();
            tr = tr + Program.commit;
            im(tr);
            textBox1.Text += Environment.NewLine;
        }
        private void button_Click6(object sender, EventArgs e)
        {
            im("git log");
            textBox1.Text += Environment.NewLine;
        }
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                Directory.SetCurrentDirectory(textBox2.Text);
            }
        }
        public void im(string s)
        {

            string[] input = s.Split(' ');
            string command = input[0];
            if (command == "exit")
            {

            }
            else
            {
                List<string> commandArgs = new List<string>();
                for (uint i = 1; i < input.Length; i++)
                {
                    commandArgs.Add(input[i]);
                }

                Inms(command, commandArgs);

            }
        }

        public bool Inms(string command, List<string> arguments)
        {
            try
            {
                switch (command)
                {
                    case "git":
                        {
                            textBox1.Text = "";
                            List<string> @out;
                            if (arguments.Count == 1 && arguments[0] == "l")
                            {
                                @out = DGShellExecutor.ExecuteCMDCommand("git log --format=oneline", true);
                            }
                            else
                            {
                                @out = DGShellExecutor.ExecuteCMDCommand("git " + arguments.Sum(" "), true);
                            }
                            foreach (var a in @out)
                            {
                                textBox1.Text += a;
                                textBox1.Text += Environment.NewLine;
                            }
                            return true;
                        }
                }
            }
            catch { };
            return true;
        }

    }
}
