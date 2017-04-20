using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCommandTool.Mode
{
    public class ModuleCommand : IComparable
    {
        string _module = "";
        string _function = "";

        public ModuleCommand()
        {
        }
        public ModuleCommand(string module, string function)
        {
            _module = module;
            _function = function;
        }
        //public ModuleCommand(int index, bool hex, string command, string note, string module, string function):base(index,hex,command,note ) {
        //    _module = module;
        //    _function = function;
        //}
        /// <summary>
        /// 模块
        /// </summary>
        public string Module
        {
            get
            {
                return _module;
            }

            set
            {
                _module = value;
            }
        }
        /// <summary>
        /// 功能
        /// </summary>
        public string Function
        {
            get
            {
                return _function;
            }

            set
            {
                _function = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (!(obj is ModuleCommand))
                throw new InvalidCastException("Not a valid Developer object.");
            ModuleCommand temp = obj as ModuleCommand;
                    return Function.CompareTo(temp.Function);

        }

    }
}
