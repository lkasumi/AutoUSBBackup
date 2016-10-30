using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUSBBackup
{
    public partial class MainForm : Form
    {
        UInt32 WM_DEVICECHANGE = 0x0219;
        UInt32 DBT_DEVTUP_VOLUME = 0x02;
        UInt32 DBT_DEVICEARRIVAL = 0x8000;
        UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

        public MainForm()
        {
            InitializeComponent();
        }


        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEARRIVAL))
            {
                lbMessage.Text = "헐!";
            }
            
            base.WndProc(ref m);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
