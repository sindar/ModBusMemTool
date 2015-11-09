namespace ModbusMemTool
{
    partial class FileSaveForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.BeginRegTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EndRegTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FileNameTBox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начальный регистр:";
            // 
            // BeginRegTBox
            // 
            this.BeginRegTBox.Location = new System.Drawing.Point(155, 6);
            this.BeginRegTBox.Name = "BeginRegTBox";
            this.BeginRegTBox.Size = new System.Drawing.Size(100, 20);
            this.BeginRegTBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Конечный регистр:";
            // 
            // EndRegTBox
            // 
            this.EndRegTBox.Location = new System.Drawing.Point(155, 37);
            this.EndRegTBox.Name = "EndRegTBox";
            this.EndRegTBox.Size = new System.Drawing.Size(100, 20);
            this.EndRegTBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Имя файла:";
            // 
            // FileNameTBox
            // 
            this.FileNameTBox.Location = new System.Drawing.Point(112, 68);
            this.FileNameTBox.Name = "FileNameTBox";
            this.FileNameTBox.Size = new System.Drawing.Size(143, 20);
            this.FileNameTBox.TabIndex = 5;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(112, 104);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Выгрузить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // FileSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 130);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.FileNameTBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EndRegTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BeginRegTBox);
            this.Controls.Add(this.label1);
            this.Name = "FileSaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FileSave";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BeginRegTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EndRegTBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FileNameTBox;
        private System.Windows.Forms.Button SaveBtn;
    }
}