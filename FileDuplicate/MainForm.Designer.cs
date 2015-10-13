namespace FileDuplicate
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.selectlb = new System.Windows.Forms.Label();
            this.patchText = new System.Windows.Forms.TextBox();
            this.selectBt = new System.Windows.Forms.Button();
            this.scanBt = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.GroupBox();
            this.sizeTypeMax = new System.Windows.Forms.ComboBox();
            this.sizeTypeMin = new System.Windows.Forms.ComboBox();
            this.maxSizeText = new System.Windows.Forms.TextBox();
            this.minSizeText = new System.Windows.Forms.TextBox();
            this.maxSizeCheck = new System.Windows.Forms.CheckBox();
            this.minSizeCheck = new System.Windows.Forms.CheckBox();
            this.fileFormatSelectBt = new System.Windows.Forms.Button();
            this.fileFormatLb = new System.Windows.Forms.Label();
            this.fileFormatText = new System.Windows.Forms.TextBox();
            this.algoritmLb = new System.Windows.Forms.Label();
            this.algoritm = new System.Windows.Forms.ComboBox();
            this.duplicateFileShow = new System.Windows.Forms.DataGridView();
            this.deleteDuplicateFileBt = new System.Windows.Forms.Button();
            this.clearDataBt = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timeLb = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerLb = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFoldersBt = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPropertiesBt = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileBt = new System.Windows.Forms.ToolStripMenuItem();
            this.settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duplicateFileShow)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectlb
            // 
            this.selectlb.AutoSize = true;
            this.selectlb.Location = new System.Drawing.Point(12, 24);
            this.selectlb.Name = "selectlb";
            this.selectlb.Size = new System.Drawing.Size(81, 13);
            this.selectlb.TabIndex = 0;
            this.selectlb.Text = "Шлях до папки";
            // 
            // patchText
            // 
            this.patchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patchText.Location = new System.Drawing.Point(105, 21);
            this.patchText.Name = "patchText";
            this.patchText.Size = new System.Drawing.Size(315, 20);
            this.patchText.TabIndex = 1;
            // 
            // selectBt
            // 
            this.selectBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBt.Location = new System.Drawing.Point(445, 18);
            this.selectBt.Name = "selectBt";
            this.selectBt.Size = new System.Drawing.Size(75, 32);
            this.selectBt.TabIndex = 2;
            this.selectBt.Text = "Обрати";
            this.selectBt.UseVisualStyleBackColor = true;
            this.selectBt.Click += new System.EventHandler(this.selectBt_Click_1);
            // 
            // scanBt
            // 
            this.scanBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scanBt.Location = new System.Drawing.Point(537, 18);
            this.scanBt.Name = "scanBt";
            this.scanBt.Size = new System.Drawing.Size(75, 32);
            this.scanBt.TabIndex = 3;
            this.scanBt.Text = "Сканувати";
            this.scanBt.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.settings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settings.Controls.Add(this.sizeTypeMax);
            this.settings.Controls.Add(this.sizeTypeMin);
            this.settings.Controls.Add(this.maxSizeText);
            this.settings.Controls.Add(this.minSizeText);
            this.settings.Controls.Add(this.maxSizeCheck);
            this.settings.Controls.Add(this.minSizeCheck);
            this.settings.Controls.Add(this.fileFormatSelectBt);
            this.settings.Controls.Add(this.fileFormatLb);
            this.settings.Controls.Add(this.fileFormatText);
            this.settings.Controls.Add(this.algoritmLb);
            this.settings.Controls.Add(this.algoritm);
            this.settings.Location = new System.Drawing.Point(632, 18);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(240, 444);
            this.settings.TabIndex = 4;
            this.settings.TabStop = false;
            this.settings.Text = "Настройки";
            // 
            // sizeTypeMax
            // 
            this.sizeTypeMax.FormattingEnabled = true;
            this.sizeTypeMax.Items.AddRange(new object[] {
            "Б",
            "КБ",
            "МБ",
            "ГБ"});
            this.sizeTypeMax.Location = new System.Drawing.Point(186, 230);
            this.sizeTypeMax.Name = "sizeTypeMax";
            this.sizeTypeMax.Size = new System.Drawing.Size(48, 21);
            this.sizeTypeMax.TabIndex = 10;
            // 
            // sizeTypeMin
            // 
            this.sizeTypeMin.FormattingEnabled = true;
            this.sizeTypeMin.Items.AddRange(new object[] {
            "Б",
            "КБ",
            "МБ",
            "ГБ"});
            this.sizeTypeMin.Location = new System.Drawing.Point(186, 183);
            this.sizeTypeMin.Name = "sizeTypeMin";
            this.sizeTypeMin.Size = new System.Drawing.Size(48, 21);
            this.sizeTypeMin.TabIndex = 9;
            // 
            // maxSizeText
            // 
            this.maxSizeText.Location = new System.Drawing.Point(112, 229);
            this.maxSizeText.Name = "maxSizeText";
            this.maxSizeText.Size = new System.Drawing.Size(53, 20);
            this.maxSizeText.TabIndex = 8;
            // 
            // minSizeText
            // 
            this.minSizeText.Location = new System.Drawing.Point(112, 184);
            this.minSizeText.Name = "minSizeText";
            this.minSizeText.Size = new System.Drawing.Size(53, 20);
            this.minSizeText.TabIndex = 7;
            // 
            // maxSizeCheck
            // 
            this.maxSizeCheck.AutoSize = true;
            this.maxSizeCheck.Location = new System.Drawing.Point(15, 232);
            this.maxSizeCheck.Name = "maxSizeCheck";
            this.maxSizeCheck.Size = new System.Drawing.Size(90, 17);
            this.maxSizeCheck.TabIndex = 6;
            this.maxSizeCheck.Text = "Макс.розмір";
            this.maxSizeCheck.UseVisualStyleBackColor = true;
            // 
            // minSizeCheck
            // 
            this.minSizeCheck.AutoSize = true;
            this.minSizeCheck.Location = new System.Drawing.Point(15, 186);
            this.minSizeCheck.Name = "minSizeCheck";
            this.minSizeCheck.Size = new System.Drawing.Size(80, 17);
            this.minSizeCheck.TabIndex = 5;
            this.minSizeCheck.Text = "Мін.розмір";
            this.minSizeCheck.UseVisualStyleBackColor = true;
            // 
            // fileFormatSelectBt
            // 
            this.fileFormatSelectBt.Location = new System.Drawing.Point(171, 122);
            this.fileFormatSelectBt.Name = "fileFormatSelectBt";
            this.fileFormatSelectBt.Size = new System.Drawing.Size(63, 36);
            this.fileFormatSelectBt.TabIndex = 4;
            this.fileFormatSelectBt.Text = "Вибір";
            this.fileFormatSelectBt.UseVisualStyleBackColor = true;
            this.fileFormatSelectBt.Click += new System.EventHandler(this.fileFormatSelectBt_Click);
            // 
            // fileFormatLb
            // 
            this.fileFormatLb.AutoSize = true;
            this.fileFormatLb.Location = new System.Drawing.Point(14, 96);
            this.fileFormatLb.Name = "fileFormatLb";
            this.fileFormatLb.Size = new System.Drawing.Size(69, 13);
            this.fileFormatLb.TabIndex = 3;
            this.fileFormatLb.Text = "Типи файлів";
            // 
            // fileFormatText
            // 
            this.fileFormatText.Font = new System.Drawing.Font("Miriam", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileFormatText.Location = new System.Drawing.Point(15, 131);
            this.fileFormatText.Name = "fileFormatText";
            this.fileFormatText.Size = new System.Drawing.Size(150, 21);
            this.fileFormatText.TabIndex = 2;
            this.fileFormatText.Text = "*.*";
            // 
            // algoritmLb
            // 
            this.algoritmLb.AutoSize = true;
            this.algoritmLb.Location = new System.Drawing.Point(14, 28);
            this.algoritmLb.Name = "algoritmLb";
            this.algoritmLb.Size = new System.Drawing.Size(95, 13);
            this.algoritmLb.TabIndex = 1;
            this.algoritmLb.Text = "Обрати алгоритм";
            // 
            // algoritm
            // 
            this.algoritm.FormattingEnabled = true;
            this.algoritm.Location = new System.Drawing.Point(17, 57);
            this.algoritm.Name = "algoritm";
            this.algoritm.Size = new System.Drawing.Size(148, 21);
            this.algoritm.TabIndex = 0;
            // 
            // duplicateFileShow
            // 
            this.duplicateFileShow.AllowUserToAddRows = false;
            this.duplicateFileShow.AllowUserToDeleteRows = false;
            this.duplicateFileShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicateFileShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.duplicateFileShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.duplicateFileShow.Location = new System.Drawing.Point(15, 71);
            this.duplicateFileShow.Name = "duplicateFileShow";
            this.duplicateFileShow.ReadOnly = true;
            this.duplicateFileShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.duplicateFileShow.Size = new System.Drawing.Size(597, 334);
            this.duplicateFileShow.TabIndex = 6;
            this.duplicateFileShow.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.duplicateFileShow_CellMouseClick);
            // 
            // deleteDuplicateFileBt
            // 
            this.deleteDuplicateFileBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteDuplicateFileBt.Location = new System.Drawing.Point(294, 422);
            this.deleteDuplicateFileBt.Name = "deleteDuplicateFileBt";
            this.deleteDuplicateFileBt.Size = new System.Drawing.Size(184, 35);
            this.deleteDuplicateFileBt.TabIndex = 7;
            this.deleteDuplicateFileBt.Text = "Видалити дублікати файлів";
            this.deleteDuplicateFileBt.UseVisualStyleBackColor = true;
            // 
            // clearDataBt
            // 
            this.clearDataBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearDataBt.Location = new System.Drawing.Point(484, 422);
            this.clearDataBt.Name = "clearDataBt";
            this.clearDataBt.Size = new System.Drawing.Size(119, 35);
            this.clearDataBt.TabIndex = 8;
            this.clearDataBt.Text = "Очистити";
            this.clearDataBt.UseVisualStyleBackColor = true;
            this.clearDataBt.Click += new System.EventHandler(this.clearDataBt_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeLb,
            this.timeText,
            this.timerLb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 24);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timeLb
            // 
            this.timeLb.Name = "timeLb";
            this.timeLb.Size = new System.Drawing.Size(95, 19);
            this.timeLb.Text = "Час виконання: ";
            // 
            // timeText
            // 
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(0, 19);
            // 
            // timerLb
            // 
            this.timerLb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.timerLb.Name = "timerLb";
            this.timerLb.Size = new System.Drawing.Size(85, 19);
            this.timerLb.Text = "00:00:00:00";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFoldersBt,
            this.viewPropertiesBt,
            this.deleteFileBt});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 70);
            // 
            // openFoldersBt
            // 
            this.openFoldersBt.Name = "openFoldersBt";
            this.openFoldersBt.Size = new System.Drawing.Size(177, 22);
            this.openFoldersBt.Text = "Відкрити файл";
            // 
            // viewPropertiesBt
            // 
            this.viewPropertiesBt.Name = "viewPropertiesBt";
            this.viewPropertiesBt.Size = new System.Drawing.Size(177, 22);
            this.viewPropertiesBt.Text = "Властивості файлу";
            // 
            // deleteFileBt
            // 
            this.deleteFileBt.Name = "deleteFileBt";
            this.deleteFileBt.Size = new System.Drawing.Size(177, 22);
            this.deleteFileBt.Text = "Видалити файл";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 482);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.clearDataBt);
            this.Controls.Add(this.deleteDuplicateFileBt);
            this.Controls.Add(this.duplicateFileShow);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.scanBt);
            this.Controls.Add(this.selectBt);
            this.Controls.Add(this.patchText);
            this.Controls.Add(this.selectlb);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainForm";
            this.Text = "Scan Duplicate File";
            this.settings.ResumeLayout(false);
            this.settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duplicateFileShow)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectlb;
        private System.Windows.Forms.TextBox patchText;
        private System.Windows.Forms.Button selectBt;
        private System.Windows.Forms.Button scanBt;
        private System.Windows.Forms.GroupBox settings;
        private System.Windows.Forms.ComboBox sizeTypeMax;
        private System.Windows.Forms.ComboBox sizeTypeMin;
        private System.Windows.Forms.TextBox maxSizeText;
        private System.Windows.Forms.TextBox minSizeText;
        private System.Windows.Forms.CheckBox maxSizeCheck;
        private System.Windows.Forms.CheckBox minSizeCheck;
        private System.Windows.Forms.Button fileFormatSelectBt;
        private System.Windows.Forms.Label fileFormatLb;
        private System.Windows.Forms.TextBox fileFormatText;
        private System.Windows.Forms.Label algoritmLb;
        private System.Windows.Forms.ComboBox algoritm;
        private System.Windows.Forms.DataGridView duplicateFileShow;
        private System.Windows.Forms.Button deleteDuplicateFileBt;
        private System.Windows.Forms.Button clearDataBt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel timeLb;
        private System.Windows.Forms.ToolStripStatusLabel timeText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel timerLb;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFoldersBt;
        private System.Windows.Forms.ToolStripMenuItem viewPropertiesBt;
        private System.Windows.Forms.ToolStripMenuItem deleteFileBt;
    }
}

