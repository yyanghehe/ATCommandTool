using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCommandTool.Mode
{
    class MultiCommands
    {
        private int count=0;
        private bool circle;
        private long circleTime;
        private List<ATCommand> commands;

        public string GetCommandString(int index) {
            return commands[index].Command;
        }
        public void SetCommandString(int index,string str) {
            commands[index].Command = str;
        }
        
        /// <summary>
        /// 命令的条数
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }
        /// <summary>
        /// 是否循环操作
        /// </summary>
        public bool Circle
        {
            get
            {
                return circle;
            }

            set
            {
                circle = value;
            }
        }
        

        /// <summary>
        /// 包含的命令
        /// </summary>
        internal List<ATCommand> Commands
        {
            get
            {
                return commands;
            }

            set
            {
                commands = value;
            }
        }
        /// <summary>
        /// 循环间隔时间
        /// </summary>
        public long CircleTime
        {
            get
            {
                return circleTime;
            }

            set
            {
                circleTime = value;
            }
        }

    }
}
