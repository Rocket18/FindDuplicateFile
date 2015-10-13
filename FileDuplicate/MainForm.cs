using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileDuplicate
{
    public partial class MainForm : Form, IMainForm
    {
        DateTime date;
        Timer timer;
        public MainForm()
        {

            InitializeComponent();
            sizeTypeMin.SelectedIndex = 0;
            sizeTypeMax.SelectedIndex = 0;
            scanBt.Click += scanBt_Click;//Сканувати
            clearDataBt.Click += clearDataBt_Click;//Очистити результат  
            deleteDuplicateFileBt.Click += deleteDuplicateFileBt_Click;//Видалити усі дублікати
            deleteFileBt.Click += deleteFileBt_Click;//Видалити файл
            openFoldersBt.Click += openFoldersBt_Click;//Відкрити   файл
            viewPropertiesBt.Click += viewPropertiesBt_Click;//Переглянути властивості
        }

        void viewPropertiesBt_Click(object sender, EventArgs e)
        {
            if (OpenProperties != null) OpenProperties(this, EventArgs.Empty);
        }

        void openFoldersBt_Click(object sender, EventArgs e)
        {
            if (OpenFolder != null) OpenFolder(this, EventArgs.Empty);
        }

        void deleteFileBt_Click(object sender, EventArgs e)
        {
            if (DeleteFile != null) DeleteFile(this, EventArgs.Empty);
        }

        #region
        public string directoryPach
        {
            get { return patchText.Text; }
        }

        public int algorithm
        {
            get { return algoritm.SelectedIndex; }

        }
        public string fileType
        {
            get { return fileFormatText.Text; }
        }
        public double minSize
        {
            get { return Convert.ToDouble(minSizeText.Text); }
        }
        public double maxSize
        {
            get { return Convert.ToDouble(maxSizeText.Text); }
        }
        public int minSizeType
        {
            get { return sizeTypeMin.SelectedIndex; }
        }
        public int maxSizeType
        {
            get { return sizeTypeMax.SelectedIndex; }
        }
        public void setAlgotithm(List<string> data)
        {
            algoritm.DataSource = data;
        }
        public bool minSizeIsChacked
        {
            get { return minSizeCheck.Checked ? true : false; }
        }

        public bool maxSizeIsChacked
        {
            get { return maxSizeCheck.Checked ? true : false; }
        }
        #endregion
        void deleteDuplicateFileBt_Click(object sender, EventArgs e)
        {
            if (DeleteDublicateFile != null) DeleteDublicateFile(this, EventArgs.Empty);
        }

        void scanBt_Click(object sender, EventArgs e)
        {
            if (ScanClick != null) ScanClick(this, EventArgs.Empty);
        }
        public void Result(DataTable data)
        {
            if (duplicateFileShow.InvokeRequired)
            {
                duplicateFileShow.Invoke(new MethodInvoker(delegate
                {
                    duplicateFileShow.DataSource = data;
                    if (data != null)
                    {
                        foreach (DataGridViewRow row in duplicateFileShow.Rows)
                        {
                            if (Convert.ToInt32(row.Cells[2].Value) % 2 == 0)
                                row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                 }));
            }
            else
            {
                duplicateFileShow.DataSource = data;
            }
        }

        public event EventHandler ScanClick;
        public event EventHandler DeleteDublicateFile;
        public event EventHandler ClearResult;
        public event EventHandler OpenFolder;
        public event EventHandler OpenProperties;
        public event EventHandler DeleteFile;
        public event EventHandler TimeRun;

        private void selectBt_Click_1(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                patchText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void clearDataBt_Click(object sender, EventArgs e)
        {
            if (ClearResult != null) ClearResult(this, EventArgs.Empty);

        }

        private void fileFormatSelectBt_Click(object sender, EventArgs e)
        {
            FileMask mask = new FileMask(fileFormatText);
            mask.ShowDialog();
        }

        private void duplicateFileShow_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    duplicateFileShow.CurrentCell = duplicateFileShow.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    duplicateFileShow.ClearSelection();
                    duplicateFileShow.Rows[e.RowIndex].Selected = true;
                }
                contextMenuStrip1.Show(duplicateFileShow, e.Location);
            }
        }

        public string GetFullName
        {
            get { return duplicateFileShow.CurrentRow.Cells[1].Value.ToString(); }
        }

        public void RemoveRow()
        {
            int index = duplicateFileShow.CurrentRow.Index;
            duplicateFileShow.Rows.RemoveAt(index);
        }

        public void StartTimer(bool start)
        {
            if (start)
            {

                date = DateTime.Now;
                timer = new Timer();
                timer.Interval = 10;
                timer.Tick += new EventHandler(run);
                timer.Start();
            }
            else
            {
                timer.Stop();

            }
        }
        void run(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);
            timerLb.Text = String.Format("{0:HH:mm:ss:ff}", stopWatch);
        }
    }

    public interface IMainForm
    {
        string directoryPach { get; }
        int algorithm { get; }
        string fileType { get; }
        double minSize { get; }
        double maxSize { get; }
        int minSizeType { get; }
        int maxSizeType { get; }
        bool minSizeIsChacked { get; }
        bool maxSizeIsChacked { get; }
        string GetFullName { get; }
        void RemoveRow();
        void Result(DataTable data);
        void setAlgotithm(List<string> data);
        void StartTimer(bool oper);

        event EventHandler ScanClick;
        event EventHandler ClearResult;
        event EventHandler OpenFolder;
        event EventHandler OpenProperties;
        event EventHandler DeleteFile;
        event EventHandler DeleteDublicateFile;
    }
}
