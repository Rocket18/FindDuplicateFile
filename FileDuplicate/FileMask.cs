using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileDuplicate
{
    public partial class FileMask : Form
    {
        List<string> settings;
        public readonly string filename = "settings.txt";
        TextBox file;
        public FileMask(TextBox fileType)
        {
            file = fileType;
            InitializeComponent();
            settings = new List<string>();
            button2.Click += maskList_DoubleClick;

            ShowMask();

            
        }


        private void ShowMask()
        
        {
         
            settings.Clear();
            maskList.Items.Clear();
            settings = File.ReadAllLines(filename).ToList();

            for (int i = 0; i < settings.Count; i++)
            {
                maskList.Items.Add(settings[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveMask mask = new SaveMask(settings,-1);

            mask.FormClosing += mask_FormClosing;
            mask.ShowDialog();
        }

        void mask_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShowMask();
        }


       

        private void maskList_DoubleClick(object sender, EventArgs e)
        {
            if (maskList.SelectedItem != null)
            {
                int selectedItem = maskList.SelectedIndex;
                SaveMask mask = new SaveMask(settings, selectedItem);

                mask.FormClosing += mask_FormClosing;
                mask.ShowDialog();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskList.SelectedItem != null)
            {
                int selectedItem = maskList.SelectedIndex;
                settings.RemoveAt(selectedItem);
                using (StreamWriter streamWriter = new StreamWriter("settings.txt"))
                {
                    foreach (string line in settings)
                    {
                        streamWriter.WriteLine(line);
                    }

                }
                ShowMask();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = "";

            foreach (string a in maskList.CheckedItems)
            {

                result += a.Substring(a.IndexOf('|')+1);
                
               
            }

            file.Text = result;
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
