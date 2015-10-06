using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        bool serviceOpened = false;
        bool serviceOpenedAndGot = false;

        public Form1()
        {
            InitializeComponent();

            data.RaiseResponseEvent += HandleResponse;
        }

        private void HandleResponse(Object sender, ResponseEventArgs args)
        {
            if (InvokeRequired)
            {
                Invoke(new  EventHandler<ResponseEventArgs>(HandleResponse), new Object[] { sender, args });
            }
            Debug.WriteLine("Response received: {0}", args);
            DisplayResult(args.ResponseResult);
        }
        

        private void DisplayResult( Result result)
        {
            
                txtResult.Text = string.Format("{0}: {1}", result.field, result.value);
            
        }


        private void RefreshUIState()
        {
            btnStartSession.Enabled = !sessionStarted;
            btnStopSession.Enabled = btnOpenService.Enabled = sessionStarted;
            btnGetService.Enabled = serviceOpened;
            btnRequest.Enabled = serviceOpenedAndGot;
            btnHistoryRequest.Enabled = serviceOpenedAndGot;
            btnSubscribe.Enabled = serviceOpenedAndGot;
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
            sessionStarted = serviceOpenedAndGot = serviceOpened = false;
            RefreshUIState();
        }

        private void btnOpenService_Click(object sender, EventArgs e)
        {
            serviceOpened = data.OpenService();
            Debug.WriteLine("Service opened: {0}", serviceOpened);
            RefreshUIState();
        }

        private void btnGetService_Click(object sender, EventArgs e)
        {
            bool serviceGot = data.GetService();
            Debug.WriteLine("Service got: {0}", serviceGot);
            serviceOpenedAndGot = serviceGot;
            RefreshUIState();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            string securityName = txtSecurity.Text;
            data.MakeRequest(securityName, "PX_LAST");
        }

        private void btnHistoryRequest_Click(object sender, EventArgs e)
        {
            string securityName = txtSecurity.Text;
            DateTime startDate = new DateTime(2010, 10, 1);
            DateTime endDate = new DateTime(2015, 10, 12);
            data.MakeHistoryRequest(securityName, "PX_LAST", startDate, endDate);
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            data.Subscribe(txtSecurity.Text, "LAST_PRICE");
        }

        private void txtSecurity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
