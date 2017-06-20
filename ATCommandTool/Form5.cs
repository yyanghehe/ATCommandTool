using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ATCommandTool
{
    public partial class Form5 : Form
    {
        public static IntPtr myPtr;
        public Form5()
        {
            InitializeComponent();
            listBox1.ItemHeight = 20;
            myPtr = GetForegroundWindow();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
    }
}
