using ATCommandTool.Mode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATCommandTool.Control
{
    //对多条命令发送的操作
    class MultiControl
    {
        MultiCommands MultiCommands;
        string panelFlag = "MCPanel";
        string cbox = "cbox";
        string tbox = "tbox";
        string btn = "btn";
        public MultiControl(MultiCommands multicommands) {
            MultiCommands = multicommands;
        }
        //对listView进行添加控制
        public Panel PanelAddItems(Panel container) {
            ATCommand[] atcommands = MultiCommands.Commands;
            int length = atcommands.Length;
            for (int i = 0; i < length; i++) {
                TextBox textbox = new TextBox();
                CheckBox checkBox = new CheckBox();
                Button button = new Button();
                //复选框定义
                checkBox.Name = cbox + panelFlag + i;
                checkBox.Width = 40;
                checkBox.Height = 40;
                checkBox.Location = new Point(3, 40 * i+3);
                checkBox.Checked =atcommands[i].HEX==null?false: atcommands[i].HEX;
                //文本框定义
                textbox.Name = tbox + panelFlag + i;
                textbox.Width = 240;
                textbox.Height = 40;
                textbox.Location = new Point(6 + checkBox.Width, 40 * i+3);
                textbox.Text = atcommands[i].Command;
                //按钮定义
                button.Name = btn + panelFlag + i;
                button.Width = 60;
                button.Height = 40;
                button.Location = new Point(289, 40 * i+3);
                button.Text =( i + 1 )+ "";
                //添加控件到容器
                container.Controls.Add(checkBox);
                container.Controls.Add(textbox);
                container.Controls.Add(button);
            }
            return container;
        }
    }
}
