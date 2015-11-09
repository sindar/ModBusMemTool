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
    public partial class LoadingForm : Form
    {
        public LoadingForm(string LabelText, int MaxBarValue)
        {
            InitializeComponent();
            UpdateLabel(LabelText);
            progressBarLoad.Maximum = MaxBarValue;
        }

        public void UpdateLabel(string LabelText)
        {
            label1.Text = LabelText;
        }

        public void IncreasePrograssBarValue()
        {
            ++progressBarLoad.Value;
            this.Refresh();
        }
    }
}
