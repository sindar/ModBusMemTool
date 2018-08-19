using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModbusMemTool
{
    public partial class FileSaveForm : Form
    {

        ModbusTCPConnection connection;

        public FileSaveForm(ref ModbusTCPConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            ushort beginAdr;
            ushort endAdr;

            try
            {
                beginAdr = Convert.ToUInt16(BeginRegTBox.Text);
                endAdr = Convert.ToUInt16(EndRegTBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter first and last register in range [0-65535]");
                return;
            }

            FileOper file = new FileOper(FileNameTBox.Text);
            file.DonwloadData(ref connection, beginAdr, endAdr);
        }

        private void FileSaveForm_Load(object sender, EventArgs e)
        {

        }
    }
}
