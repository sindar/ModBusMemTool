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

        #region //Выгрузка данных из ПЛК
        public void DonwloadData(ref ModbusTCPConnection connection, ushort begin, ushort end)
        {
            LoadingForm LoadForm = new LoadingForm("Выполняется выгрузка данных из ПЛК...", (end - begin)/100 + 1);
            LoadForm.Show();

            try
            {
                dataOut = new BinaryWriter(new FileStream(sFileName, FileMode.Create));
            }
            catch (IOException ex)
            {
                MessageBox.Show("Ошибка создания файла!" + ex.Message);
                return;
            }

            dataOut.Write(begin);
            dataOut.Write(end);
            
            for (ushort i = begin; i <= end; i+=100)
            {
                if (i <= end - 99)
                {
                    buffer = connection.ReadHoldingRegs(i, 100);

                    try
                    {
                        dataOut.Write(buffer, 9, 200);
                        LoadForm.IncreasePrograssBarValue();
                        LoadForm.Refresh();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Ошибка записи данных в файл!" + ex.Message);
                        dataOut.Close();
                        return;
                    }
                }
                else
                {
                
                    buffer = connection.ReadHoldingRegs(i, (ushort)(end - i + 1));
                    
                    try
                    {
                        dataOut.Write(buffer, 9, (end - i + 1)*2);
                        LoadForm.IncreasePrograssBarValue();
                        LoadForm.Refresh();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Ошибка записи данных в файл!" + ex.Message);
                        dataOut.Close();
                        return;
                    }
                }
            }

            LoadForm.Show();
            LoadForm.UpdateLabel("Выгрузка данных завершена.");
            
            if (dataOut != null)
                dataOut.Close();
        }
        #endregion

        #region //Загрузка данных в ПЛК
        public void UploadData(ref ModbusTCPConnection connection)
        {
            ushort begin, end;            
            
            try
            {
                dataIn = new BinaryReader(new FileStream(sFileName, FileMode.Open));
            }
            catch (IOException ex)
            {
                MessageBox.Show("Ошибка открытия файла!" + ex.Message);
                return;
            }

            begin = dataIn.ReadUInt16();
            end = dataIn.ReadUInt16();

            LoadingForm LoadForm = new LoadingForm("Выполняется загрузка данных в ПЛК...", (end - begin)/100 + 1);
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
                        MessageBox.Show("Ошибка записи данных в файл!" + ex.Message);
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
                        MessageBox.Show("Ошибка записи данных в файл!" + ex.Message);
                        dataIn.Close();
                        return;
                    }
                }
            }

            LoadForm.Show();
            LoadForm.UpdateLabel("Загрузка данных завершена.");
            
            if (dataIn != null)
                dataIn.Close();
         
        }
        #endregion
    }
}
