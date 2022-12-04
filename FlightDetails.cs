using Core;
using Core.Flight;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Net;
using Core.Email;
using Newtonsoft.Json;


namespace BAL
{
    public class FlightDetails
    {
        public static string API_URL = ConfigurationManager.AppSettings["FlightApiUrl"].ToString();
        public static string authcode = ConfigurationManager.AppSettings["AuthCode"].ToString();
        public static string goToLive = ConfigurationManager.AppSettings["goToLive"].ToString();
        public ResponseStatus SendMail(SendEmailRequest sendEmailRequest)
        {
            ResponseStatus responseStatus;
            try
            {
                if (sendEmailRequest != null)
                {
                    sendEmailRequest.MailBody = BAL.StringHelper.CompressString(sendEmailRequest.MailBody);
                    sendEmailRequest.isBodyCompress = true;
                    WebClient client = new WebClient();
                    var url = API_URL + "Email/SendMail?authcode=" + authcode;
                    string serialisedData = JsonConvert.SerializeObject(sendEmailRequest);
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    System.DateTime dt = DateTime.Now;
                    var kk = client.UploadString(url, serialisedData);
                    if (kk.ToString().ToLower() == "true")
                    {
                        responseStatus = new ResponseStatus();
                    }
                    else
                    {
                        responseStatus = new ResponseStatus() { status = TransactionStatus.Error, message = "Mail not sent properly!!" };
                    }
                }
                else
                {
                    responseStatus = new ResponseStatus() { status = TransactionStatus.Error, message = "Request is empty!" };
                }
            }
            catch (Exception exrr)
            {
                responseStatus = new ResponseStatus() { status = TransactionStatus.Error, message = exrr.ToString() };
            }
            return responseStatus;
        }

        public List<Airport> GetCitynew(string ID)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                WebClient client = new WebClient();
                var url = API_URL + "Flights/GetAirport?authcode=" + authcode + "&data=" + ID;

                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var kk = client.DownloadString(url);
                var fbr = JsonConvert.DeserializeObject<List<Airport>>(kk.ToString());
                return fbr;
            }
            else
            {
                return new List<Airport>();
            }
        }

        public List<Airport> GetCity(string ID)
        {

            if (!FlightUtility.isMasterDataLoaded)
            {
                FlightUtility.LoadMasterData();
            }

            ID = ID.Replace(" ", "").Replace("  ", "");

            List<Airport> resCityCode = FlightUtility.AirportList.Where(x => (x.cityCode.StartsWith(ID, StringComparison.OrdinalIgnoreCase))).ToList();
            List<Airport> ResCityName = FlightUtility.AirportList.Where(x => (x.cityName.Replace(" ", "").StartsWith(ID, StringComparison.OrdinalIgnoreCase))).ToList();
            List<Airport> ResAirportCode = FlightUtility.AirportList.Where(x => (x.airportCode.StartsWith(ID, StringComparison.OrdinalIgnoreCase))).ToList();
            List<Airport> ResAirportName = FlightUtility.AirportList.Where(x => (x.airportName.Replace(" ", "").StartsWith(ID, StringComparison.OrdinalIgnoreCase))).ToList();
            //List<Airport> ResStateName = FlightUtility.AirportList.Where(x => (!string.IsNullOrEmpty(x.stateName.Replace(" ", "")) && (x.stateName.Replace(" ", "").StartsWith(ID, StringComparison.OrdinalIgnoreCase)))).ToList();
            List<Airport> ResStateName = new List<Airport>();
            List<Airport> response = new List<Airport>();

            if (ID.Count() >= 4)
            {
                List<Airport> firstName = resCityCode.Union(ResAirportCode).Union(ResCityName).Union(ResAirportName).Union(ResStateName).Where(x => (x.countryCode.Equals("US"))).ToList();
                List<Airport> secondName = resCityCode.Union(ResAirportCode).Union(ResCityName).Union(ResAirportName).Union(ResStateName).Where(x => (x.countryCode.Equals("CA"))).ToList();
                List<Airport> thirdName = resCityCode.Union(ResAirportCode).Union(ResCityName).Union(ResAirportName).Union(ResStateName).ToList();
                response = firstName.Union(secondName).Union(thirdName).ToList();
            }
            else
            {
                List<Airport> firstName = resCityCode.Union(ResAirportCode).Union(ResCityName).Union(ResAirportName).Where(x => (x.countryCode.Equals("US"))).ToList();
                List<Airport> secondName = resCityCode.Union(ResAirportCode).Union(ResCityName).Union(ResAirportName).Where(x => (x.countryCode.Equals("CA"))).ToList();
                List<Airport> thirdName = resCityCode.Union(ResAirportCode).Union(ResCityName).Union(ResAirportName).Union(ResStateName).ToList();
                var response3Char = firstName.Union(secondName).Union(thirdName).ToList();
                response = response3Char.Where(n => n.cityCode.Equals(ID, StringComparison.OrdinalIgnoreCase)).ToList().Union(response3Char.Where(n => !n.cityCode.Equals(ID, StringComparison.OrdinalIgnoreCase)).ToList()).ToList();

            }
            List<Airport> response2 = response.Where(x => x.airportName.ToLower().IndexOf(" all ") != -1).ToList();
            if (response2.Count > 0)
            {
                List<Airport> response3 = response.Where(n => n.cityCode.Equals(response2[0].cityCode, StringComparison.OrdinalIgnoreCase)).ToList().Union(response.Where(n => !n.cityCode.Equals(response2[0].cityCode, StringComparison.OrdinalIgnoreCase)).ToList()).ToList();
                return response3;
            }
            else
            {
                return response;
            }

        }
        public void SearchFlight(ref AirContext airContext)
        {
            #region set flight result and Markup
            airContext.flightSearchResponse = new FlightSearchResponse();
            airContext.flightSearchResponse.airline = new List<Airline>();
            airContext.flightSearchResponse.operatedAirline = new List<Airline>();
            airContext.flightSearchResponse.airport = new List<Airport>();
            airContext.flightSearchResponse.flightResult = new List<FlightResult>();
            airContext.flightSearchResponse.adults = airContext.flightSearchRequest.adults;
            airContext.flightSearchResponse.child = airContext.flightSearchRequest.child;
            airContext.flightSearchResponse.infants = airContext.flightSearchRequest.infants;
            airContext.flightSearchResponse.infantsWs = airContext.flightSearchRequest.infantsWs;
            airContext.flightSearchResponse.responsStatus = new ResponseStatus();
            #endregion
            try
            {
                if (airContext.flightSearchRequest != null)
                {

                    if (goToLive == "false")
                    {
                        //string path = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "result.txt");
                        string path = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "dummyResult.json");
                        string data = "";
                        using (System.IO.StreamReader r = new System.IO.StreamReader(path))
                        {
                            data = r.ReadToEnd();
                        }

                        airContext.flightSearchResponse = JsonConvert.DeserializeObject<FlightSearchResponse>(data);
                        airContext.IsSearchCompleted = true;
                    }
                    else
                    {
                        WebClient client = new WebClient();
                        var url = API_URL + "Flights/SearchFlightResult?authcode=" + authcode;
                        string serialisedData = JsonConvert.SerializeObject(airContext.flightSearchRequest);
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        System.DateTime dt = DateTime.Now;
                        var kk = client.UploadString(url, serialisedData);
                        airContext.flightSearchResponse = JsonConvert.DeserializeObject<FlightSearchResponse>(kk.ToString());
                        airContext.IsSearchCompleted = true;
                    }
                }
                else
                {
                    airContext.flightSearchResponse = new FlightSearchResponse();
                    airContext.flightSearchResponse.responsStatus.status = TransactionStatus.Error;
                    airContext.flightSearchResponse.responsStatus.message = "Request is empty!";
                    airContext.IsSearchCompleted = false;
                }
            }
            catch (Exception exrr)
            {
                airContext.flightSearchResponse = new FlightSearchResponse();
                airContext.flightSearchResponse.responsStatus.status = TransactionStatus.Error;
                airContext.flightSearchResponse.responsStatus.message = "Request is empty!";
                airContext.IsSearchCompleted = false;
            }
        }

        public FlightBookingResponse CreateBooking(FlightBookingRequest flightBookingRequest)
        {
            FlightBookingResponse fbr;
            try
            {
                if (flightBookingRequest != null)
                {
                    WebClient client = new WebClient();
                    var url = API_URL + "Flights/CreateBooking?authcode=" + authcode;
                    string serialisedData = JsonConvert.SerializeObject(flightBookingRequest);
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    System.DateTime dt = DateTime.Now;
                    var kk = client.UploadString(url, serialisedData);
                    fbr = JsonConvert.DeserializeObject<FlightBookingResponse>(kk.ToString());
                }
                else
                {
                    fbr = new FlightBookingResponse();
                    fbr.responseStatus = new ResponseStatus() { status = TransactionStatus.Error, message = "Request is empty!" };

                }
            }
            catch (Exception exrr)
            {
                fbr = new FlightBookingResponse();
                fbr.responseStatus = new ResponseStatus() { status = TransactionStatus.Error, message = exrr.ToString() };
            }
            return fbr;
        }

        public void SaveFlightSessionData(string SearchKey, AirContext Data)
        {
            new DAL.sessionData.DalSessionData().SaveFlightSessionData(SearchKey, StringHelper.CompressString(JsonConvert.SerializeObject(Data)));
        }
        public AirContext getFlightSessionData(string SearchKey)
        {
            string str = new DAL.sessionData.DalSessionData().getFlightSessionData(SearchKey);
            str = StringHelper.DecompressString(str);
            if (!string.IsNullOrEmpty(str))
            {
                return JsonConvert.DeserializeObject<AirContext>(StringHelper.DecompressString(str));
            }
            else
                return null;
        }
    }
    public class LogWriter
    {
        private string m_exePath = string.Empty;
        public LogWriter(string logMessage, string FileName)
        {
            LogWrite(logMessage, FileName);
        }
        public LogWriter(string logMessage, string FileName, string FolderName)
        {
            LogWrite(logMessage, FileName, FolderName);
        }
        public void LogWrite(string logMessage, string FileName)
        {
            //try
            //{
            using (StreamWriter w = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "\\Log\\" + FileName + ".txt"))
            {
                Log(logMessage, w);
            }
            //}
            //catch (Exception ex)
            //{
            //}
        }
        public void LogWrite(string logMessage, string FileName, string FolderName)
        {
            try
            {
                using (StreamWriter w = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "\\log\\" + FolderName + "\\" + FileName + ".txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
