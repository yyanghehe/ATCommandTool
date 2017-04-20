using ATCommandTool.Mode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using static ATCommandTool.Mode.ModuleCommand;

namespace ATCommandTool.Controlers
{
    class XMLUnit
    {
        string filePath = System.Windows.Forms.Application.StartupPath + @"\CommandsData.xml";
        public XMLUnit()
        {
            //判断文件是否存在,如果不存在创建新的文件
            if (!File.Exists(filePath))
            {
                using (File.CreateText(filePath))
                {
                }
            }

        }

        //序列化xml
        public void XMLUnitWrite(ModuleCommand module, List<ATCommand> atCommands)
        {
            List<ATCommand> fullList = new List<ATCommand>(32);
            for (int i = atCommands.Count - 1; i >=0; i--)
            {
                if (atCommands[i].Command != null&&atCommands[i].Command.Trim()!="")
                {
                    for (int j = 0; j <= i; j++)
                    {
                        ATCommand a = new ATCommand();
                        a.Module = module.Module;
                        a.Function = module.Function;
                        a.HEX = atCommands[j].HEX;
                        a.Index = atCommands[j].Index;
                        a.Note = atCommands[j].Note;
                        a.Command = atCommands[j].Command;
                        fullList.Add(a);
                    }
                    break;
                }
            }
            if (fullList.Count > 0)
            {
                XMLUnitWrite(fullList);
            }
            else
            {
                if (module.Module != ""&&module.Function!="") { 
                    atCommands[0].Module = module.Module;
                    atCommands[0].Function = module.Function;
                    fullList.Add(atCommands[0]);
                   
                }
                XMLUnitWrite(fullList);
            }
        }
        /// <summary>
        /// XML序列化
        /// </summary>
        /// <param name="fullList"></param>
        private void XMLUnitWrite(List<ATCommand> fullList)
        {
            if (fullList.Count == 0 && File.Exists(filePath))
            {
                File.Delete(filePath);
                return;
            }
            fullList = MoreList(fullList);
            XmlSerializer serializer = new XmlSerializer(typeof(List<ATCommand>));
            //Stream stream = new FileStream(,FileMode.)
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, fullList);
            }
        }

        private List<ATCommand> MoreList(List<ATCommand> fullList)
        {
            if (File.Exists(filePath))
            {
                Application.DoEvents();
                ModuleCommand mc = fullList[0];
                List<ATCommand> tempList = XMLUnitRead();
                List<ATCommand> deltempList = new List<ATCommand>();
                foreach (ATCommand temp in tempList)
                {
                    if (temp.Module == mc.Module && temp.Function == mc.Function)
                    {
                        deltempList.Add(temp);
                    }
                }
                if (deltempList.Count > 0)
                {
                    foreach (ATCommand TEMP in deltempList)
                    {
                        tempList.Remove(TEMP);
                    }
                }
                foreach (ATCommand TEMP in fullList)
                {
                    tempList.Add(TEMP);
                }
                return tempList;
            }
            return fullList;
        }
        //获取存储区域的模块列表
        public List<ModuleCommand> QueryModuleList()
        {
            List<ModuleCommand> ModuleList = new List<ModuleCommand>();
            List<ATCommand> TempList = XMLUnitRead();
            if (TempList.Count > 0)
            {
                ModuleList.Add(TempList[0]);
                ModuleCommand atCommand = TempList[0];

                for (int i = 0; i < TempList.Count; i++)
                {
                    if (TempList[i].Module != atCommand.Module || TempList[i].Function != atCommand.Function)
                    {
                        atCommand = TempList[i];
                        ModuleList.Add(atCommand);
                    }
                }
            }
            ModuleList.Sort(MySort);
            return ModuleList;
        }
        private int MySort(ModuleCommand m1,ModuleCommand m2) {
            if (m1.Module.CompareTo(m2.Module) != 0)
            {
                return m1.Module.CompareTo(m2.Module);
            }
            else if (m1.Function.CompareTo(m2.Function) != 0)
            {
                return m1.Function.CompareTo(m2.Function);
            }
            else
                return 1;
        }
        //删除存储区域的模块列表
        public bool DelModuleList(ModuleCommand module)
        {
            bool flag = false;
            List<ATCommand> tempList = XMLUnitRead();
            List<ATCommand> fullList = new List<ATCommand>();
            foreach (ATCommand _module in tempList)
            {
                if (_module.Function != module.Function || _module.Module != module.Module)
                {
                    fullList.Add(_module);
                }
            }
            if (fullList.Count == 0 && File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<ATCommand>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, fullList);
            }

            return flag;
        }
        /// <summary>
        /// 更改模块列表
        /// </summary>
        /// <param name="oldModule"></param>
        /// <param name="newModule"></param>
        public void ChangeModultList(ModuleCommand oldModule,ModuleCommand newModule) {
            List<ATCommand> tempList = XMLUnitRead();
            for (int i=0;i<tempList.Count;i++)
            {
                if (tempList[i].Function == oldModule.Function && tempList[i].Module == oldModule.Module)
                {
                    tempList[i].Function = newModule.Function;
                    tempList[i].Module = newModule.Module;
                }
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<ATCommand>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, tempList);
            }
        }
        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <returns></returns>
        public List<ATCommand> XMLUnitRead()
        {
            List<ATCommand> fullList = new List<ATCommand>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ATCommand>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                if (fs.Length > 0)
                {
                    fullList = (List<ATCommand>)serializer.Deserialize(fs);
                }
            }
            return fullList;
        }
        /// <summary>
        /// 根据选列表,XML反序列化
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public List<ATCommand> XMLUnitRead(ModuleCommand module)
        {
            List<ATCommand> temp = XMLUnitRead();
            List<ATCommand> fullList = new List<ATCommand>();
            foreach (ATCommand command in temp)
            {
                if (command.Module.Equals(module.Module) && command.Function.Equals(module.Function))
                {
                    fullList.Add(command);
                }
            }
            return fullList;
        }

    }
}
