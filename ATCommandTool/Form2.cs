using ATCommandTool.Mode;
using System.Windows.Forms;

namespace ATCommandTool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string str) {
            InitializeComponent();
            this.textBox1.Text = str;
        }
    }
}
