using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusMemTool
{
    public abstract class ModBusConnection
    {
        public abstract Byte[] ReadHoldingRegs(UInt16 baseRegister, UInt16 number);
        public abstract Byte[] PresetMultipleRegs(UInt16 baseRegister, UInt16 number, Byte[] presetData);
        public abstract void Close();
        public abstract bool GetState();
    }
}
