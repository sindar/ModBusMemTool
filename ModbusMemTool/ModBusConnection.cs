using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusMemTool
{
    public abstract class ModBusConnection
    {
        public abstract Byte[] ReadHoldingAndInputRegs(UInt16 baseRegister, 
                                                       UInt16 number, 
                                                       byte funcCode);
        public abstract Byte[] PresetMultipleRegs(UInt16 baseRegister, 
                                                  UInt16 number, 
                                                  Byte[] presetData);
        public abstract void Close();
        public abstract bool GetState();
    }
}
