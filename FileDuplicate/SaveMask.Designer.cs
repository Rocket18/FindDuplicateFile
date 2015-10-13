namespace FileDuplicate
{
    partial class SaveMask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maskText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.maskLb = new System.Windows.Forms.Label();
            this.nameLb = new System.Windows.Forms.Label();
            this.SaveBt = new System.Windows.Forms.Button();
            this.cancelBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskText
            // 
            this.maskText.Location = new System.Drawing.Point(94, 12);
            this.maskText.Name = "maskText";
            this.maskText.Size = new System.Drawing.Size(319, 20);
            this.maskText.TabIndex = 0;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(94, 56);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(319, 20);
            this.nameText.TabIndex = 1;
            // 
            // maskLb
            // 
            this.maskLb.AutoSize = true;
            this.maskLb.Location = new System.Drawing.Point(27, 15);
            this.maskLb.Name = "maskLb";
            this.maskLb.Size = new System.Drawing.Size(40, 13);
            this.maskLb.TabIndex = 2;
            this.maskLb.Text = "Маска";
            // 
            // nameLb
            // 
            this.nameLb.AutoSize = true;
            this.nameLb.Location = new System.Drawing.Point(28, 56);
            this.nameLb.Name = "nameLb";
            this.nameLb.Size = new System.Drawing.Size(39, 13);
            this.nameLb.TabIndex = 3;
            this.nameLb.Text = "Назва";
            // 
            // SaveBt
            // 
            this.SaveBt.Location = new System.Drawing.Point(94, 96);
            this.SaveBt.Name = "SaveBt";
            this.SaveBt.Size = new System.Drawing.Size(75, 23);
            this.SaveBt.TabIndex = 4;
            this.SaveBt.Text = "Добавити";
            this.SaveBt.UseVisualStyleBackColor = true;
            this.SaveBt.Click += new System.EventHandler(this.SaveBt_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.Location = new System.Drawing.Point(191, 96);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 23);
            this.cancelBt.TabIndex = 5;
            this.cancelBt.Text = "Скасувати";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // SaveMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 132);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.SaveBt);
            this.Controls.Add(this.nameLb);
            this.Controls.Add(this.maskLb);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.maskText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveMask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавити маску файлу";
            this.Load += new System.EventHandler(this.SaveMask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox maskText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label maskLb;
        private System.Windows.Forms.Label nameLb;
        private System.Windows.Forms.Button SaveBt;
        private System.Windows.Forms.Button cancelBt;
    }
}