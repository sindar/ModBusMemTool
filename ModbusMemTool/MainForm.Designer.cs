namespace ModbusMemTool
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
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PLCdataGridView = new System.Windows.Forms.DataGridView();
            this.MBaddressTextBox = new System.Windows.Forms.TextBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.UploadButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RegQtyTextBox = new System.Windows.Forms.TextBox();
            this.MBTCPRadButton = new System.Windows.Forms.RadioButton();
            this.MBRTURadButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.COMNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.COMSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ParityComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.StopBitsNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.SlaveAddrTBox = new System.Windows.Forms.TextBox();
            this._serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.funcCodeRdBtn4 = new System.Windows.Forms.RadioButton();
            this.funcCodeRdBtn3 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.PollPeriodTBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PLCdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopBitsNumUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(77, 46);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(196, 20);
            this.IPTextBox.TabIndex = 0;
            this.IPTextBox.Text = "192.168.0.100";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(11, 49);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(60, 13);
            this.labelIP.TabIndex = 2;
            this.labelIP.Text = "IP-address:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(300, 129);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(176, 23);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 433);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(754, 58);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // PLCdataGridView
            // 
            this.PLCdataGridView.AllowUserToAddRows = false;
            this.PLCdataGridView.AllowUserToDeleteRows = false;
            this.PLCdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PLCdataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PLCdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PLCdataGridView.Enabled = false;
            this.PLCdataGridView.Location = new System.Drawing.Point(8, 187);
            this.PLCdataGridView.MultiSelect = false;
            this.PLCdataGridView.Name = "PLCdataGridView";
            this.PLCdataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.PLCdataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PLCdataGridView.Size = new System.Drawing.Size(754, 240);
            this.PLCdataGridView.TabIndex = 5;
            this.PLCdataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.PLCdataGridView_CellEndEdit);
            // 
            // MBaddressTextBox
            // 
            this.MBaddressTextBox.Location = new System.Drawing.Point(123, 39);
            this.MBaddressTextBox.MaxLength = 5;
            this.MBaddressTextBox.Name = "MBaddressTextBox";
            this.MBaddressTextBox.Size = new System.Drawing.Size(50, 20);
            this.MBaddressTextBox.TabIndex = 6;
            this.MBaddressTextBox.Text = "0";
            this.MBaddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MBaddressTextBox_KeyPress);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(554, 149);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(107, 13);
            this.ErrorLabel.TabIndex = 7;
            this.ErrorLabel.Text = "State: not connected";
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 10;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Register address:";
            // 
            // UploadButton
            // 
            this.UploadButton.Image = global::ModbusMemTool.Properties.Resources.upload;
            this.UploadButton.Location = new System.Drawing.Point(144, 23);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(68, 65);
            this.UploadButton.TabIndex = 11;
            this.toolTip1.SetToolTip(this.UploadButton, "Data uploading from a file into PLC");
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Image = global::ModbusMemTool.Properties.Resources.download;
            this.DownloadButton.Location = new System.Drawing.Point(60, 23);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(68, 65);
            this.DownloadButton.TabIndex = 10;
            this.toolTip1.SetToolTip(this.DownloadButton, "Data downloading from PLC into a file");
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(300, 158);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(176, 23);
            this.disconnectButton.TabIndex = 12;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Length:";
            // 
            // RegQtyTextBox
            // 
            this.RegQtyTextBox.Location = new System.Drawing.Point(123, 62);
            this.RegQtyTextBox.MaxLength = 3;
            this.RegQtyTextBox.Name = "RegQtyTextBox";
            this.RegQtyTextBox.Size = new System.Drawing.Size(50, 20);
            this.RegQtyTextBox.TabIndex = 14;
            this.RegQtyTextBox.Text = "100";
            this.RegQtyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RegQtyTextBox_KeyPress);
            // 
            // MBTCPRadButton
            // 
            this.MBTCPRadButton.AutoSize = true;
            this.MBTCPRadButton.Location = new System.Drawing.Point(14, 26);
            this.MBTCPRadButton.Name = "MBTCPRadButton";
            this.MBTCPRadButton.Size = new System.Drawing.Size(85, 17);
            this.MBTCPRadButton.TabIndex = 15;
            this.MBTCPRadButton.TabStop = true;
            this.MBTCPRadButton.Text = "ModBusTCP";
            this.MBTCPRadButton.UseVisualStyleBackColor = true;
            // 
            // MBRTURadButton
            // 
            this.MBRTURadButton.AutoSize = true;
            this.MBRTURadButton.Location = new System.Drawing.Point(14, 75);
            this.MBRTURadButton.Name = "MBRTURadButton";
            this.MBRTURadButton.Size = new System.Drawing.Size(87, 17);
            this.MBRTURadButton.TabIndex = 16;
            this.MBRTURadButton.TabStop = true;
            this.MBRTURadButton.Text = "ModBusRTU";
            this.MBRTURadButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "COM-port:";
            // 
            // COMNameTextBox
            // 
            this.COMNameTextBox.Location = new System.Drawing.Point(77, 123);
            this.COMNameTextBox.MaxLength = 30;
            this.COMNameTextBox.Name = "COMNameTextBox";
            this.COMNameTextBox.Size = new System.Drawing.Size(70, 20);
            this.COMNameTextBox.TabIndex = 18;
            this.COMNameTextBox.Text = "COM1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Speed:";
            // 
            // COMSpeedComboBox
            // 
            this.COMSpeedComboBox.FormattingEnabled = true;
            this.COMSpeedComboBox.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.COMSpeedComboBox.Location = new System.Drawing.Point(75, 149);
            this.COMSpeedComboBox.Name = "COMSpeedComboBox";
            this.COMSpeedComboBox.Size = new System.Drawing.Size(72, 21);
            this.COMSpeedComboBox.TabIndex = 20;
            this.COMSpeedComboBox.Text = "460800";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Parity bit:";
            // 
            // ParityComboBox
            // 
            this.ParityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParityComboBox.FormattingEnabled = true;
            this.ParityComboBox.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.ParityComboBox.Location = new System.Drawing.Point(217, 122);
            this.ParityComboBox.MaxDropDownItems = 3;
            this.ParityComboBox.Name = "ParityComboBox";
            this.ParityComboBox.Size = new System.Drawing.Size(56, 21);
            this.ParityComboBox.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Stop-bits:";
            // 
            // StopBitsNumUpDown
            // 
            this.StopBitsNumUpDown.Location = new System.Drawing.Point(217, 150);
            this.StopBitsNumUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.StopBitsNumUpDown.Name = "StopBitsNumUpDown";
            this.StopBitsNumUpDown.Size = new System.Drawing.Size(56, 20);
            this.StopBitsNumUpDown.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Slave address:";
            // 
            // SlaveAddrTBox
            // 
            this.SlaveAddrTBox.Location = new System.Drawing.Point(110, 96);
            this.SlaveAddrTBox.MaxLength = 3;
            this.SlaveAddrTBox.Name = "SlaveAddrTBox";
            this.SlaveAddrTBox.Size = new System.Drawing.Size(70, 20);
            this.SlaveAddrTBox.TabIndex = 26;
            this.SlaveAddrTBox.Text = "1";
            // 
            // _serialPort
            // 
            this._serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this._serialPort_ErrorReceived);
            this._serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this._serialPort_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 173);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.funcCodeRdBtn4);
            this.groupBox2.Controls.Add(this.funcCodeRdBtn3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.PollPeriodTBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.MBaddressTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.RegQtyTextBox);
            this.groupBox2.Location = new System.Drawing.Point(297, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 108);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query settings";
            // 
            // funcCodeRdBtn4
            // 
            this.funcCodeRdBtn4.AutoSize = true;
            this.funcCodeRdBtn4.Location = new System.Drawing.Point(131, 16);
            this.funcCodeRdBtn4.Name = "funcCodeRdBtn4";
            this.funcCodeRdBtn4.Size = new System.Drawing.Size(42, 17);
            this.funcCodeRdBtn4.TabIndex = 32;
            this.funcCodeRdBtn4.Text = "0x4";
            this.toolTip1.SetToolTip(this.funcCodeRdBtn4, "Input Registers");
            this.funcCodeRdBtn4.UseVisualStyleBackColor = true;
            this.funcCodeRdBtn4.CheckedChanged += new System.EventHandler(this.funcCodeRdBtn_CheckedChanged);
            // 
            // funcCodeRdBtn3
            // 
            this.funcCodeRdBtn3.AutoSize = true;
            this.funcCodeRdBtn3.Location = new System.Drawing.Point(89, 16);
            this.funcCodeRdBtn3.Name = "funcCodeRdBtn3";
            this.funcCodeRdBtn3.Size = new System.Drawing.Size(42, 17);
            this.funcCodeRdBtn3.TabIndex = 31;
            this.funcCodeRdBtn3.Text = "0x3";
            this.toolTip1.SetToolTip(this.funcCodeRdBtn3, "Holding Registers");
            this.funcCodeRdBtn3.UseVisualStyleBackColor = true;
            this.funcCodeRdBtn3.CheckedChanged += new System.EventHandler(this.funcCodeRdBtn_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Read function:";
            // 
            // PollPeriodTBox
            // 
            this.PollPeriodTBox.Location = new System.Drawing.Point(123, 85);
            this.PollPeriodTBox.MaxLength = 5;
            this.PollPeriodTBox.Name = "PollPeriodTBox";
            this.PollPeriodTBox.Size = new System.Drawing.Size(50, 20);
            this.PollPeriodTBox.TabIndex = 16;
            this.PollPeriodTBox.Text = "10";
            this.PollPeriodTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PollPeriodTBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Polling period(ms):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UploadButton);
            this.groupBox3.Controls.Add(this.DownloadButton);
            this.groupBox3.Location = new System.Drawing.Point(497, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 108);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Download/Upload data";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(497, 129);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 52);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Connection state";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 503);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SlaveAddrTBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.StopBitsNumUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ParityComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.COMSpeedComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.COMNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MBRTURadButton);
            this.Controls.Add(this.MBTCPRadButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.PLCdataGridView);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.IPTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MemoryPLCTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PLCdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopBitsNumUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView PLCdataGridView;
        private System.Windows.Forms.TextBox MBaddressTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RegQtyTextBox;
        private System.Windows.Forms.RadioButton MBTCPRadButton;
        private System.Windows.Forms.RadioButton MBRTURadButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox COMNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox COMSpeedComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ParityComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown StopBitsNumUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SlaveAddrTBox;
        private System.IO.Ports.SerialPort _serialPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox PollPeriodTBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton funcCodeRdBtn4;
        private System.Windows.Forms.RadioButton funcCodeRdBtn3;
        private System.Windows.Forms.Label label9;
    }
}

