using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Basic
{

    public struct Result
    {
        public string security;
        public string field;
        public double value;

        public override string ToString()
        {
            return string.Format("{0} {1}: {2}", security, field, value);
        }
    }

    public class ResponseEventArgs : EventArgs
    {
        private Result result;
        public ResponseEventArgs(Result result)
        {
            this.result = result;
        }
        public Result ResponseResult
        {
            get { return result; }
        }

        public override string ToString()
        {
            return result.ToString();
        }
    }

    public class BasicData
    {
        Session session;
        Service refDataService;


        public event EventHandler<ResponseEventArgs> RaiseResponseEvent;


        private Session NewSession()
        {
            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = "localhost";
            sessionOptions.ServerPort = 8194;
            return new Session(sessionOptions, new Bloomberglp.Blpapi.EventHandler(ProcessEvent));
        }

        public bool StartSession()
        {
            bool sessionStarted = false;
            if (session == null)
            {
                session = NewSession();
            }
            try
            {
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
            if (session != null)
            {
                session.Stop(AbstractSession.StopOption.ASYNC);
                session = null;
            }
        }

        public bool OpenService()
        {
            return session.OpenService("//blp/refdata");
        }

        public bool GetService()
        {
            refDataService = session.GetService("//blp/refdata");
            return refDataService != null;
        }

        public void MakeRequest(string securityName, string fieldName)
        {
            if (refDataService == null) return;
            Request request = refDataService.CreateRequest("ReferenceDataRequest");
            Element securities = request.GetElement("securities");
            securities.AppendValue(securityName);
            Element fieldNames = request.GetElement("fields");
            fieldNames.AppendValue(fieldName);

            CorrelationID cID = new CorrelationID(1);
            session.Cancel(cID);

            session.SendRequest(request, cID);

            //while (true)
            //{
            //    Event eventObj = session.NextEvent();
            //    Debug.WriteLine("Processing data... {0}", eventObj.Type);
            //    // process data
            //    ProcessEvent(eventObj, session);
            //    if (eventObj.Type == Event.EventType.RESPONSE)
            //    {
            //        break;
            //    }
            //}
            Debug.WriteLine("Processed Request...");
        }

        private string DateParameterString(DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        public void MakeHistoryRequest(string securityName, string fieldName, DateTime startDate, DateTime endDate)
        {
            if (refDataService == null) return;
            Request request = refDataService.CreateRequest("HistoricalDataRequest");
            Element securities = request.GetElement("securities");
            securities.AppendValue(securityName);
            Element fieldNames = request.GetElement("fields");
            fieldNames.AppendValue(fieldName);
            request.GetElement("startDate").SetValue(DateParameterString(startDate));
            request.GetElement("endDate").SetValue(DateParameterString(endDate));

            request.Set("periodicitySelection", new Name("WEEKLY"));

            CorrelationID cID = new CorrelationID(1);
            session.Cancel(cID);

            session.SendRequest(request, cID);
        }

        public void Subscribe(string securityName, string fieldName)
        {
            session.OpenService("//blp/mktdata");
            Service realtimeService = session.GetService("//blp/mktdata");
            Subscription subscription = new Subscription(securityName, fieldName);
            CorrelationID correlator = new CorrelationID(securityName + "!" + fieldName);
            subscription.CorrelationID = correlator;
            session.Cancel(correlator);
            List<Subscription> subscriptions = new List<Subscription>();
            subscriptions.Add(subscription);
            session.Subscribe(subscriptions);

        }

        private void ProcessEvent(Event eventObj, Session session)
        {

            try
            {
                switch (eventObj.Type)
                {
                    case Event.EventType.RESPONSE:
                        // process final respose for request
                        ProcessRequestDataEvent(eventObj, session);

                        break;
                    case Event.EventType.PARTIAL_RESPONSE:
                        // process partial response
                        ProcessRequestDataEvent(eventObj, session);
                        break;
                    case Event.EventType.SUBSCRIPTION_DATA:
                        ProcessRealTimeSubscriptionDataEvent(eventObj, session);
                        break;
                    default:
                        //processMiscEvents(eventObj, session);
                        break;
                }
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }

        }

        private void ProcessRealTimeSubscriptionDataEvent(Event eventObj, Session session)
        {

            foreach (Message msg in eventObj)
            {

                Debug.WriteLine(msg.CorrelationID);
                var correlator = msg.CorrelationID;
                string securityName = (correlator.ToString()).Split('!')[0];

                Debug.WriteLine(msg);

                if (msg.HasElement("LAST_PRICE"))
                {
                    var price = msg.GetElementAsFloat64("LAST_PRICE");

                    Debug.WriteLine(price);

                    Result result = new Result();
                    result.security = securityName;
                    result.field = "Last Price";
                    result.value = price;
                    OnRaiseResponseEvent(result);
                }

            }
        }

        private void ProcessRequestDataEvent(Event eventObj, Session session)
        {
            Result result = new Result();
            foreach (Message msg in eventObj)
            {
                int cId = (int)msg.CorrelationID.Value;
                switch (msg.MessageType.ToString())
                {
                    case "HistoricalDataResponse":
                        {
                            Debug.WriteLine(msg);
                            Element securityData = msg.GetElement(new Name("securityData"));
                            //Debug.WriteLine(securityData);
                            //Debug.WriteLine("Security count: {0}", securitiesData.NumValues);

                            string securityName = securityData.GetElementAsString("security");
                            Debug.WriteLine(securityName);

                            Element fieldDataItems = securityData.GetElement("fieldData");

                            Debug.WriteLine(fieldDataItems.NumValues);
                            List<double> prices = new List<double>();
                            for (int i = 0; i < fieldDataItems.NumValues; ++i)
                            {
                                Element fieldDataItem = fieldDataItems.GetValue(i) as Element;
                                Debug.WriteLine(fieldDataItem);
                                prices.Add(fieldDataItem.GetElementAsFloat64("PX_LAST"));
                            }
                            double averagePrice = prices.Average();
                            Debug.WriteLine(averagePrice);

                            result.security = securityName;
                            result.field = "Average price";
                            result.value = averagePrice;
                            OnRaiseResponseEvent(result);
                        }

                        break;
                    case "ReferenceDataResponse":

                        {
                            Element securitiesData = msg.GetElement(new Name("securityData"));

                            Debug.WriteLine("Security count: {0}", securitiesData.NumValues);

                            Element securityData = securitiesData.GetValueAsElement(0);
                            Debug.WriteLine(securityData);


                            var securityName = securityData.GetElementAsString("security");
                            Debug.WriteLine(securityName);
                            result.security = securityName;


                            var fieldData = securityData.GetElement("fieldData");
                            Debug.WriteLine(fieldData);
                            var fieldResult = fieldData.GetElement(0);
                            var fieldName = fieldResult.Name;
                            result.field = fieldName.ToString();
                            var fieldValue = fieldResult.GetValueAsFloat64();
                            Debug.WriteLine("Result is: {0}", fieldValue);
                            result.value = fieldValue;
                            OnRaiseResponseEvent(result);
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        private void OnRaiseResponseEvent(Result result)
        {
            EventHandler<ResponseEventArgs> handler = RaiseResponseEvent;
            if (handler != null)
            {
                ResponseEventArgs args = new ResponseEventArgs(result);
                handler(this, args);
            }


        }
    }
}

