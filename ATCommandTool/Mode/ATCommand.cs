using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCommandTool.Mode
{
    public class ATCommand: ModuleCommand
    {
        private bool _HEX=false;
        private string _Command="";
        private string _Note="双击添加注释!!!";
        private int _index;
        public ATCommand() { }
        public ATCommand(int index, bool hex, string command, string note) {
            _index = index;
            _HEX = hex;
            _Command = command;
            _Note = note;
        }
        public ATCommand(int index, bool hex, string command, string note, string module, string function) : base(module, function) {
            _index = index;
            _HEX = hex;
            _Command = command;
            _Note = note;
        }
        //public ATCommand(string )
        /// <summary>
        /// 是否以HEX发送
        /// </summary>
        public bool HEX
        {
            get
            {
                return _HEX;
            }
            set
            {
                _HEX = value;
            }
        }
        /// <summary>
        /// 命令字符串
        /// </summary>
        public string Command
        {
            get
            {
                return _Command;
            }
            set
            {
                _Command = value;
            }
        }
        /// <summary>
        /// 命令的注释
        /// </summary>
        public string Note
        {
            get
            {
                return _Note;
            }

            set
            {
                _Note = value;
            }
        }

        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }
    }
}
