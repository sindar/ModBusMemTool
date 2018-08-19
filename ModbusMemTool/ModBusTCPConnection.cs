using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Forms;

namespace ModbusMemTool
{
    public class ModbusTCPConnection : ModBusConnection
    {
        Socket socket;
        EndPoint endPoint;
        
        public ModbusTCPConnection(string sAddress)
        {
            UInt16 Port = 502;
            IPAddress address;

            try
            {
                address = IPAddress.Parse(sAddress);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid IP address format! " + ex.Message);
                return;
            }

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(address, Port);

            try
            {
                socket.Connect(endPoint);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error opening connection!" + ex.Message);
                return;
            }
        }

        public override bool GetState()
        {
            return socket.Connected;
        }

        public override Byte[] ReadHoldingRegs(UInt16 baseRegister, UInt16 number)
        {
            if (socket.Connected)
            {
                Byte[] transmitData = new Byte[12];
                Byte[] receiveData = new Byte[9 + number * 2];
                Int32 numReadBytes;

                //-------------------------------Prepare read request-----------
                // Byteorder: MSB, LSB

                // Transaction identifier
                transmitData[0] = 0;
                transmitData[1] = 0;

                // Protocol identifier
                transmitData[2] = 0;
                transmitData[3] = 0;

                // Length field
                transmitData[4] = 0;
                transmitData[5] = 6;

                transmitData[6] = 0; // Unit identifier

                transmitData[7] = 0x03; // Function code

                //------ Data bytes --------
                // First register
                transmitData[8] = Convert.ToByte((baseRegister & 0xFF00) >> 8);
                transmitData[9] = Convert.ToByte(baseRegister & 0x00FF);
                //MessageBox.Show("First register" + transmitData[8].ToString() + "-" + transmitData[9].ToString());
                // Length
                transmitData[10] = Convert.ToByte((number & 0xFF00) >> 8);
                transmitData[11] = Convert.ToByte(number & 0x00FF);
                //--------------------------------Request is ready--------------

                socket.Send(transmitData);

                socket.ReceiveTimeout = 3000;
                
                try
                {
                    numReadBytes = socket.Receive(receiveData);
                }
                catch(Exception ex)
                {
                    //MessageBox.Show("No response! " + ex.Message);
                }

                return receiveData;
            }
            else
                return null;
        }

        public override Byte[] PresetMultipleRegs(UInt16 baseRegister, UInt16 number, Byte[] presetData)
        {
            if (socket.Connected)
            {
                Byte[] transmitData = new Byte[13 + presetData.Length];
                Byte[] receiveData = new byte[20];// = new Byte[9 + number * 2];//Пока заглушка
                Int32 numReadBytes;
                UInt16 dataLength;

                //-------------------------------Prepare write request----------
                // Byteorder: MSB, LSB

                // Transaction identifier
                transmitData[0] = 0;
                transmitData[1] = 0;

                // Protocol identifier
                transmitData[2] = 0;
                transmitData[3] = 0;

                // Length field
                dataLength = Convert.ToUInt16(7 + presetData.Length);
                transmitData[4] = Convert.ToByte((dataLength & 0xFF00) >> 8);
                transmitData[5] = Convert.ToByte(dataLength & 0x00FF);

                transmitData[6] = 0; // Unit identifier

                transmitData[7] = 0x10; // Function code

                //------ Data bytes --------
                // First register
                transmitData[8] = Convert.ToByte((baseRegister & 0xFF00) >> 8);
                transmitData[9] = Convert.ToByte(baseRegister & 0x00FF);
                //MessageBox.Show("First register" + transmitData[8].ToString() + "-" + transmitData[9].ToString());
                // Length
                transmitData[10] = Convert.ToByte((number & 0xFF00) >> 8);
                transmitData[11] = Convert.ToByte(number & 0x00FF);

                transmitData[12] = Convert.ToByte(presetData.Length); // Bytes count

                for (int i = 0; i < presetData.Length; i++)
                    transmitData[i + 13] = presetData[i];
                //--------------------------------Request is ready--------------

                
                try
                {
                    socket.Send(transmitData);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Connection error!" + ex.Message);
                }

                try
                {
                    numReadBytes = socket.Receive(receiveData);                    
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("No response! " + ex.Message);
                }

                return receiveData;
            }
            else
                return null;
        }

        public override void Close()
        {
            socket.Close();
        }
    }
}
