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
    public partial class SaveMask : Form
    {
       
        List<string> settings;
        int selectedItem;
        public SaveMask(List<string> data,int selected)
        {
            settings = data;
            selectedItem = selected;
            InitializeComponent();


        }
        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBt_Click(object sender, EventArgs e)
        {
            string name = nameText.Text;
            string mask = maskText.Text;
            string newLine = String.Format("{0}|{1}",name,mask);


            if (selectedItem != -1)
            {
                settings[selectedItem] = newLine;
            }
            else 
            {
                settings.Add(newLine);
            }

       

            using (StreamWriter streamWriter = new StreamWriter("settings.txt"))
            {
                foreach (string line in settings)
                {
                    streamWriter.WriteLine(line);
                }
                
            }

            this.Close();
        }

        private void SaveMask_Load(object sender, EventArgs e)
        {
            if (selectedItem != -1)
            {
                this.Text = "Редагувати маску файлу";
                SaveBt.Text = "Зберегти";
                string line = settings[selectedItem];
                string[] split = line.Split('|');
                nameText.Text = split[0];
                maskText.Text = split[1];
               
            }
        } 
    }
}
