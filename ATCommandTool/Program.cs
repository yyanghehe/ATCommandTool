using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATCommandTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception EX)
            {
                saveErrorAtLog(EX);
            }
        }
        static void saveErrorAtLog(Exception EX)
        {
            //获取当前文件路径
                string nowDirPath = System.Windows.Forms.Application.StartupPath;
                string dirPath = nowDirPath + "\\AtCommandTool_Logs";
                string filePth = dirPath + "\\" + "ERRORLOG" + ".log";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                if (!File.Exists(filePth))
                {
                    using (File.Create(filePth))
                    {

                    }
                }
            //File.AppendAllText(filePth, DateTime.Now.ToString("yyyyMMddHHmmmmssfff") + "  "+ E.InnerException.Source.ToString());
            StreamWriter sw = new StreamWriter(filePth,true);
            sw.NewLine = "\r\n";
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sw.WriteLine("异常信息：" + EX.Message);
            sw.WriteLine("异常对象：" + EX.Source);
            sw.WriteLine("调用堆栈：\n" + EX.StackTrace.Trim());
            sw.WriteLine("触发方法：" + EX.TargetSite);
            sw.WriteLine();
            sw.Close();
            }
    }
}
