using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCommandTool.Mode
{
    class CommandList
    {
        string _module;
        string _function;

        public CommandList(string module, string function) {
            _module = module;
            _function = function;
        }
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
    }
}
