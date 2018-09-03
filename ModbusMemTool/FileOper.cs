using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Timers;

namespace ModbusMemTool
{
    
    class FileOper
    {
        BinaryWriter dataOut;
        BinaryReader dataIn;
        string sFileName;
        Byte[] buffer;
        
        public FileOper(string sFileName)
        {
            this.sFileName = sFileName;
        }

        #region Donloading data from PLC
        public void DownloadData(ref ModbusTCPConnection connection, ushort begin, ushort end)
        {
            LoadingForm LoadForm = new LoadingForm("Data is downloading from PLC...", (end - begin)/100 + 1);
            LoadForm.Show();

            try
            {
                dataOut = new BinaryWriter(new FileStream(sFileName, FileMode.Create));
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error creating a file!" + ex.Message);
                return;
            }

            dataOut.Write(begin);
            dataOut.Write(end);
            
            for (ushort i = begin; i <= end; i+=100)
            {
                if (i <= end - 99)
                {
                    buffer = connection.ReadHoldingAndInputRegs(i, 100, 0x3);

                    try
                    {
                        dataOut.Write(buffer, 9, 200);
                        LoadForm.IncreasePrograssBarValue();
                        LoadForm.Refresh();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error writing to a file!" + ex.Message);
                        dataOut.Close();
                        return;
                    }
                }
                else
                {
                
                    buffer = connection.ReadHoldingAndInputRegs(i, (ushort)(end - i + 1), 0x3);
                    
                    try
                    {
                        dataOut.Write(buffer, 9, (end - i + 1)*2);
                        LoadForm.IncreasePrograssBarValue();
                        LoadForm.Refresh();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error writing to a file!" + ex.Message);
                        dataOut.Close();
                        return;
                    }
                }
            }

            LoadForm.Show();
            LoadForm.UpdateLabel("Data downloading is finised.");
            
            if (dataOut != null)
                dataOut.Close();
        }
        #endregion

        #region Uploading data into a PLC
        public void UploadData(ref ModbusTCPConnection connection)
        {
            ushort begin, end;            
            
            try
            {
                dataIn = new BinaryReader(new FileStream(sFileName, FileMode.Open));
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error opening a file!" + ex.Message);
                return;
            }

            begin = dataIn.ReadUInt16();
            end = dataIn.ReadUInt16();

            LoadingForm LoadForm = new LoadingForm("Data is uploading into a PLC...", (end - begin)/100 + 1);
            LoadForm.Show();
            
            for (int i = begin; i <= end; i+=100)
            {
                if (i <= end - 99)
                {                
                    try
                    {
                        buffer = dataIn.ReadBytes(200);
                        connection.PresetMultipleRegs((ushort)i, (ushort)100, buffer);
                        LoadForm.IncreasePrograssBarValue();
                        LoadForm.Refresh();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error reading data from a file!" + ex.Message);
                        dataIn.Close();
                        return;
                    }
                }
                else
                {
                    try
                    {
                        buffer = dataIn.ReadBytes((end - i + 1) * 2);
                        connection.PresetMultipleRegs((ushort)i, (ushort)(end - i + 1), buffer);
                        LoadForm.IncreasePrograssBarValue();
                        LoadForm.Refresh();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error reading data from a file!" + ex.Message);
                        dataIn.Close();
                        return;
                    }
                }
            }

            LoadForm.Show();
            LoadForm.UpdateLabel("Data uploading is finised.");
            
            if (dataIn != null)
                dataIn.Close();
         
        }
        #endregion
    }
}
