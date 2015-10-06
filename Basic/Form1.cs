using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic
{
    public partial class Form1 : Form
    {

        BasicData data = new BasicData();
        bool sessionStarted = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshUIState()
        {
            btnStartSession.Enabled = !sessionStarted;
            btnStopSession.Enabled = sessionStarted;
        }

        private void sessionStartBtn_Click(object sender, EventArgs e)
        {
            sessionStarted = data.StartSession();
            System.Diagnostics.Debug.WriteLine("Session started {0}", sessionStarted);
            RefreshUIState();
        }

        private void btnStopSession_Click(object sender, EventArgs e)
        {
            data.StopSession();
            sessionStarted = false;
            RefreshUIState();
        }
    }
}
