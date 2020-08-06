using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.IO.Ports;

namespace ModbusMemTool
{
    public partial class MainForm : Form
    {
        ModBusConnection MBConnection;
        UInt16 baseAddress;
        UInt16 regQuantity;
        string AgentAddress;
        string sSlaveAddr;
        string sCOMName;
        string sCOMSpeed;
        byte parityIndex;
        byte stopBits;
        UInt32 pollPeriod;
        enum ModBusMode { TCP, RTU };
        ModBusMode ConnectionMode;
        bool RTUResponseWait = false;
        UInt16 ADUExpectedSize = 0;
        byte readFunc;

        delegate Int32 radixConv(string str);

        public MainForm()
        {
            InitializeComponent();
            
            ErrorLabel.Text = "State: no connection to PLC";

            for (int i = 0; i < 10; i++)
            {
                PLCdataGridView.Columns.Add("Column" + i.ToString(), i.ToString());
                PLCdataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                PLCdataGridView.Rows.Add();
                PLCdataGridView.Rows[i].HeaderCell.Value = i.ToString();
            }

            if(ReadConfigFile())
            {
                IPTextBox.Text = GetAddress(AgentAddress).ToString();
                SlaveAddrTBox.Text = sSlaveAddr;
                COMNameTextBox.Text = sCOMName;
                COMSpeedComboBox.Text = sCOMSpeed;
                ParityComboBox.SelectedIndex = parityIndex;
                StopBitsNumUpDown.Value = stopBits;
                PollPeriodTBox.Text = pollPeriod.ToString();
                RefreshTimer.Interval = Convert.ToInt32(pollPeriod);
            }
            else
            {
                IPTextBox.Text = "192.168.0.0";
                ParityComboBox.SelectedIndex = 1;
            }

            baseAddress = 0;
            regQuantity = 100;
            MBTCPRadButton.Checked = true;
            readFunc = 0x3;
            funcCodeRdBtn3.Checked = true;

            PLCDataGridHeadersFill();
        }

        public bool ReadConfigFile()
        {
            StreamReader FileIn;

            try
            {
                FileIn = new StreamReader("modbusmemtool.cfg");
            }
            catch (IOException exc)
            {
                return false;
            }

            try
            {
                AgentAddress = FileIn.ReadLine();
                sSlaveAddr = (Convert.ToByte(FileIn.ReadLine())).ToString();
                sCOMName = FileIn.ReadLine();
                sCOMSpeed = (Convert.ToUInt32(FileIn.ReadLine())).ToString();
                parityIndex = (Convert.ToByte(FileIn.ReadLine()));
                stopBits = (Convert.ToByte(FileIn.ReadLine()));
                pollPeriod = (Convert.ToUInt32(FileIn.ReadLine()));

                if ((AgentAddress == null) || (sSlaveAddr == null) || (sCOMName == null) || (sCOMSpeed == null) ||
                    (parityIndex == null) || (stopBits == null) || (pollPeriod == null))
                    return false;
                
            }
            catch (IOException exc)
            {
                return false;
            }
            finally
            {
                FileIn.Close();
            }

            return true;
        }

        public bool WriteConfigFile()
        {
            StreamWriter FileOut;

            try
            {
                FileOut = new StreamWriter("modbusmemtool.cfg");
            }
            catch (IOException exc)
            {
                return false;
            }

            try
            {
                FileOut.WriteLine(IPTextBox.Text);
                FileOut.WriteLine(SlaveAddrTBox.Text);
                FileOut.WriteLine(COMNameTextBox.Text);
                FileOut.WriteLine(COMSpeedComboBox.Text);
                FileOut.WriteLine(ParityComboBox.SelectedIndex.ToString());
                FileOut.WriteLine(StopBitsNumUpDown.Value.ToString());
                FileOut.WriteLine(PollPeriodTBox.Text);
            }
            catch (IOException exc)
            {
                return false;
            }
            finally
            {
                FileOut.Close();
            }

            return true;
        }

        public static IPAddress GetAddress(string address)
        {
            IPAddress ipAddress = null;

            try
            {
                ipAddress = IPAddress.Parse(address);
            }
            catch (Exception)
            {
                IPHostEntry heserver;

                try
                {
                    heserver = Dns.GetHostEntry(address);
                    if (heserver.AddressList.Length == 0)
                    {
                        return null;
                    }
                    ipAddress = heserver.AddressList[0];
                }
                catch
                {
                    return null;
                }
            }

            return ipAddress;
        } 

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            bool connectionState = false;
            byte slaveAddress;
            try
            {
                if (MBTCPRadButton.Checked)
                {
                    ConnectionMode = ModBusMode.TCP;
                    MBConnection = new ModbusTCPConnection(IPTextBox.Text);
                }
                else if (MBRTURadButton.Checked)
                {
                    ConnectionMode = ModBusMode.RTU;
                    _serialPort.PortName = COMNameTextBox.Text;
                    _serialPort.BaudRate = Convert.ToInt32(COMSpeedComboBox.Text);

                    switch (Convert.ToByte(ParityComboBox.SelectedIndex))
                    {
                        case 0:
                            _serialPort.Parity = Parity.None;
                            break;
                        case 1:
                            _serialPort.Parity = Parity.Even;
                            break;
                        case 2:
                            _serialPort.Parity = Parity.Odd;
                            break;
                        default:
                            _serialPort.Parity = Parity.None;
                            break;
                    }

                    _serialPort.DataBits = 8;

                    switch (Convert.ToByte(StopBitsNumUpDown.Value))
                    {
                        case 0:
                            _serialPort.StopBits = StopBits.None;
                            break;
                        case 1:
                            _serialPort.StopBits = StopBits.One;
                            break;
                        case 2:
                            _serialPort.StopBits = StopBits.Two;
                            break;
                        default:
                            _serialPort.StopBits = StopBits.One;
                            break;
                    }

                    try
                    {
                        slaveAddress = Convert.ToByte(SlaveAddrTBox.Text);
                    }
                    catch
                    {
                        slaveAddress = 1;
                        SlaveAddrTBox.Text = "1";
                    }

                    try
                    {
                        MBConnection = new ModBusRTUConnection(ref _serialPort, slaveAddress);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error opening COM-port!\n" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please choose a connection type!");
                    return;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error opening connection!");
            }

            try
            {
                connectionState = MBConnection.GetState();
            }
            catch
            {
                MessageBox.Show("Connection error!");
                ErrorLabel.Text = "State: connection error";
            }

            if (connectionState)
            {
                PLCdataGridView.Enabled = true;
                RefreshTimer.Enabled = true;
                ErrorLabel.Text = "State: OK";
            }
            else
                RefreshTimer.Enabled = false;
            
        }

        private void RefreshDataGridView(UInt16[] PLCData)
        {
            if (PLCData.Length == regQuantity)
            {
                if (PLCData != null)
                {
                    string sVal = "";

                    for (int i = 0, j = 0, k = 0; i < PLCData.Length; ++k, ++i)
                    {
                        if (k > 9)
                        {
                            k = 0;
                            ++j;
                        }

                        try
                        {
                            if (decRadBtn.Checked)
                                sVal = PLCData[i].ToString();
                            else if (hexRadBtn.Checked)
                                sVal = Convert.ToString(PLCData[i], 16);
                            else if (binRadBtn.Checked)
                                sVal = Convert.ToString(PLCData[i], 2);
                            else
                                sVal = PLCData[i].ToString();
                        }
                        catch(Exception ex)
                        {
                            
                        }

                        PLCdataGridView[k, j].Value = sVal;
                    }
                }
                else
                    ErrorLabel.Text = "State: error connection";
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            bool socketConnected = false;
            Byte[] PLCData = null;
            UInt16[] ValData = null;

            try
            {
                if (MBConnection.GetState())
                {
                    socketConnected = true;
                    ErrorLabel.Text = "State: OK";
                }
                else
                {
                    MBConnection.Close();
                    RefreshTimer.Enabled = false;
                    MBConnection = new ModbusTCPConnection(IPTextBox.Text);
                    RefreshTimer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error connecting to the PLC!" + ex.Message);
                ErrorLabel.Text = "State: connection error, reconnectiong...";
            }

            if (socketConnected && ConnectionMode == ModBusMode.TCP)
            {
                try
                {
                    PLCData = MBConnection.ReadHoldingAndInputRegs(baseAddress, regQuantity, readFunc);

                    if (PLCData != null)
                    {
                        ValData = new UInt16[(PLCData.Length - 9) / 2];

                        for (int i = 9, j = 0; i < PLCData[8] + 8; i += 2, ++j)
                        {
                            ValData[j] = Convert.ToUInt16((PLCData[i] << 8) | PLCData[i + 1]);
                        }
                    }

                    if (ValData != null)
                        RefreshDataGridView(ValData);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error connecting to the PLC!" + ex.Message);
                    ErrorLabel.Text = "State: connection error, reconnectiong...";
                    MBConnection.Close();;
                    RefreshTimer.Enabled = false;
                    MBConnection = new ModbusTCPConnection(IPTextBox.Text);
                    RefreshTimer.Enabled = true;
                }
            }

            if (socketConnected && ConnectionMode == ModBusMode.RTU)
            {
                PLCData = MBConnection.ReadHoldingAndInputRegs(baseAddress, regQuantity, readFunc);
                ADUExpectedSize = (UInt16)(regQuantity * 2 + 5);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MBConnection != null)
                MBConnection.Close();
            WriteConfigFile();
        }

        private void PLCdataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(readFunc == 0x3)
            {
                UInt16 u16PresetValue;
                Byte[] bytePresetValue = new Byte[2];
                string sPresetValue = PLCdataGridView.CurrentCell.Value.ToString();

                try
                {
                    if (decRadBtn.Checked)
                        u16PresetValue = Convert.ToUInt16(sPresetValue);
                    else if (hexRadBtn.Checked)
                        u16PresetValue = UInt16.Parse(sPresetValue,
                                                      System.Globalization.NumberStyles.HexNumber);
                    else if (binRadBtn.Checked)
                    {
                        radixConv binToDec = (binStr) =>
                        {
                            Int32 val = 0;

                            for (int i = 0; i < binStr.Length; i++)
                            {
                                if (binStr[i] == '0' || binStr[i] == '1')
                                {
                                    Int32 ch = Convert.ToInt32(binStr[i].ToString());
                                    Int32 pow = Convert.ToInt32((binStr.Length - 1) - i);
                                    val += Convert.ToInt32(Math.Pow(2, pow) * ch);
                                }
                                else
                                {
                                    val = -1;
                                    break;
                                }
                                    
                            }
                            return val;
                        };
                        Int32 tmp = binToDec(sPresetValue);
                        if (tmp != -1)
                            u16PresetValue = Convert.ToUInt16(tmp);
                        else
                            return;
                    }
                    else
                        u16PresetValue = Convert.ToUInt16(sPresetValue);


                    if (MBConnection.GetState())
                    {
                        ushort baseRegister;
                        bytePresetValue[0] = Convert.ToByte((u16PresetValue & 0xFF00) >> 8);
                        bytePresetValue[1] = Convert.ToByte(u16PresetValue & 0x00FF);
                        RefreshTimer.Enabled = false;
                        baseRegister = (UInt16)(baseAddress + PLCdataGridView.CurrentCell.RowIndex * 10 + PLCdataGridView.CurrentCell.ColumnIndex);
                        MBConnection.PresetMultipleRegs(baseRegister, 1, bytePresetValue);
                        RefreshTimer.Enabled = true;
                    }
                }
                catch
                {
                    PLCdataGridView.CurrentCell.Value = 0;
                    return;
                }

            }
            else
            {
                MessageBox.Show("Cannot write to Input registers!");
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FileOper file = new FileOper(openFileDialog1.FileName);
            ModbusTCPConnection tmpMBTCPonnection = (ModbusTCPConnection)MBConnection;
            file.UploadData(ref tmpMBTCPonnection);
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (ConnectionMode == ModBusMode.TCP)
            {
                if (RefreshTimer.Enabled)
                {
                    RefreshTimer.Enabled = false;
                    ModbusTCPConnection tmpMBTCPonnection = (ModbusTCPConnection)MBConnection;
                    FileSaveForm saveForm = new FileSaveForm(ref tmpMBTCPonnection);
                    saveForm.Show();
                    RefreshTimer.Enabled = true;
                }
                else
                    MessageBox.Show("Please connect to the PLC!");
            }
            else
                MessageBox.Show("Function is only available with Ethernet-connection!");
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (ConnectionMode == ModBusMode.TCP)
            {
                if (RefreshTimer.Enabled)
                {
                    RefreshTimer.Enabled = false;
                    openFileDialog1.ShowDialog();
                    RefreshTimer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please connect to the PLC!");
                }
            }
            else
               MessageBox.Show("Function is only available with Ethernet-connection!");
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (MBConnection != null && MBConnection.GetState())
            {
                MBConnection.Close();
                RefreshTimer.Enabled = false;
                PLCdataGridView.Enabled = false;
                ErrorLabel.Text = "State: not connected to PLC";
            }

        }

        private void RegQtyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    regQuantity = Convert.ToUInt16(RegQtyTextBox.Text);
                }
                catch
                {
                    regQuantity = 100;
                    RegQtyTextBox.Text = "100";
                }

                if ((regQuantity > 100) || (regQuantity < 1))
                {
                    regQuantity = 100;
                    RegQtyTextBox.Text = "100";
                }

                if((regQuantity % 10) != 0)
                    PLCdataGridView.RowCount = regQuantity / 10 + 1;
                else
                    PLCdataGridView.RowCount = regQuantity / 10;

                PLCDataGridHeadersFill();
            }
        }

        private void MBaddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    baseAddress = Convert.ToUInt16(MBaddressTextBox.Text);
                }
                catch
                {
                    baseAddress = 0;
                    MBaddressTextBox.Text = "0";
                }
                PLCDataGridHeadersFill();
            }
        }

        private void _serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {              
            Byte[] PLCData = ((ModBusRTUConnection)MBConnection).ParseReceivedData(ADUExpectedSize);

            if (PLCData != null)
            {
                UInt16[] ValData = new UInt16[PLCData.Length / 2];

                for (int i = 0, j = 0; i < PLCData.Length; i += 2, ++j)
                {
                    ValData[j] = Convert.ToUInt16((PLCData[i] << 8) | PLCData[i + 1]);
                }

                RefreshDataGridView(ValData);
            }
            else // maybe here will be something in future
            {}
        }

        private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            object a = e.GetType();
        }

        private void PLCDataGridHeadersFill()
        {
            for (int i = 0; i < PLCdataGridView.RowCount; i++)
                PLCdataGridView.Rows[i].HeaderCell.Value = (baseAddress + i * 10).ToString();
        }

        private void PollPeriodTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    RefreshTimer.Interval = Convert.ToInt32(PollPeriodTBox.Text);
                }
                catch
                {
                    RefreshTimer.Interval = 10;
                    PollPeriodTBox.Text = "10";
                }
            }
        }

        private void funcCodeRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (funcCodeRdBtn3.Checked)
                readFunc = 0x3;
            else if (funcCodeRdBtn4.Checked)
                readFunc = 0x4;
            else
            {
                readFunc = 0x3;
                funcCodeRdBtn3.Checked = true;
            }
                
        }
    }
}


//--------Header for the debug
/*for (int i = 0; i < 9; i++)
{
    richTextBox1.Text += PLCData[i].ToString() + "--";
}

richTextBox1.Text += '\n';*/
//--------------------------------------------
