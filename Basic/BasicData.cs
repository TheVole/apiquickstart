using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Basic
{
    public class BasicData
    {
        Session session;

        private Session NewSession()
        {
            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = "localhost";
            sessionOptions.ServerPort = 8194;
            return new Session(sessionOptions);
        }

        public bool StartSession()
        {
            bool sessionStarted = false;
            if (session == null)
            {
                session = NewSession();
            }
            try {
                sessionStarted = session.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return sessionStarted;
        }

        public void StopSession()
        {
            if (session != null) {
                session.Stop();
                session = null;
            }   
        }
    }
}
