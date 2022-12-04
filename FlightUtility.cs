using Core.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace Core
{
    public class FlightUtility
    {
        public static bool isB2B { get; set; }
        public static List<Airport> AirportList { get; set; }
        public static List<Airline> AirlineList { get; set; }
        public static List<string> OfficeIp { get; set; }

        public static List<AirportWithTimeZone> AirportTimeZoneList { get; set; }
        public static bool isWriteLog = false;
        public static bool isMasterDataLoaded = false;
        public static void LoadMasterData()
        {
            // isB2B = ConfigurationManager.AppSettings["isB2B"] != null ? Convert.ToBoolean(ConfigurationManager.AppSettings["isB2B"]) : false;

            FlightUtility obj = new FlightUtility();
            AirportList = obj.getAllAirport();
            AirlineList = obj.getAllAirline();
            OfficeIp = obj.getAllOfficeIp();
            isMasterDataLoaded = true;
        }
        public static Airport GetAirport(string AirportCode)
        {
            if (!FlightUtility.isMasterDataLoaded)
            {
                FlightUtility.LoadMasterData();
            }

            List<Airport> ResAirportCode = FlightUtility.AirportList.Where(x => (x.airportCode.Equals(AirportCode, StringComparison.OrdinalIgnoreCase))).ToList();
            if (ResAirportCode.Count > 0)
            {
                return ResAirportCode[0];
            }
            else
            {
                return new Airport()
                {
                    airportCode = AirportCode,
                    airportName = AirportCode,
                    cityCode = AirportCode,
                    cityName = AirportCode,
                    countryCode = AirportCode.ToUpper(),
                    countryName = AirportCode,
                    continent = AirportCode
                };
            }
        }
        public static Airline GetAirline(string AirlineCode)
        {
            if (!FlightUtility.isMasterDataLoaded)
            {
                FlightUtility.LoadMasterData();
            }

            List<Airline> ResAirlineCode = FlightUtility.AirlineList.Where(x => (x.code.Equals(AirlineCode, StringComparison.OrdinalIgnoreCase))).ToList();
            if (ResAirlineCode.Count > 0)
            {
                return ResAirlineCode[0];
            }
            else
            {
                return new Airline()
                {
                    code = AirlineCode,
                    name = AirlineCode
                };
            }
        }


        #region GetData From DB
        public List<Airport> getAllAirport()
        {
            List<Airport> arpList = null;
            try
            {
                string path = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "Airport.json");
                string data = "";
                using (System.IO.StreamReader r = new System.IO.StreamReader(path))
                {
                    data = r.ReadToEnd();
                }
                arpList = JsonConvert.DeserializeObject<List<Airport>>(data);
            }
            catch (Exception)
            {
                arpList = new List<Airport>();
            }
            return arpList;
        }

        public List<Airline> getAllAirline()
        {
            List<Airline> arlList = null;
            try
            {
                string path = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "Airline.json");
                string data = "";
                using (System.IO.StreamReader r = new System.IO.StreamReader(path))
                {
                    data = r.ReadToEnd();
                }
                arlList = JsonConvert.DeserializeObject<List<Airline>>(data);
            }
            #pragma warning disable 0168
            catch (Exception ex)
            #pragma warning restore 0168

            {
                arlList = new List<Airline>();
            }
            return arlList;
        }

        public List<AircraftDetail> getAllAircraftDetail()
        {
            List<AircraftDetail> arcftList = null;
            try
            {
                string path = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "AircraftDetails.json");
                string data = "";
                using (System.IO.StreamReader r = new System.IO.StreamReader(path))
                {
                    data = r.ReadToEnd();
                }
                arcftList = JsonConvert.DeserializeObject<List<AircraftDetail>>(data);
            }
            catch (Exception ex)
            {
                arcftList = new List<AircraftDetail>();
            }
            return arcftList;
        }

        public List<AirlineBaggage> GetAllAirlineBaggage()
        {

            List<AirlineBaggage> bag = new List<AirlineBaggage>();

            return bag;
        }
        public List<string> getAllOfficeIp()
        {
            List<string> bla = null;
            if (ConfigurationManager.AppSettings["isDBConnection"] != null ? Convert.ToBoolean(ConfigurationManager.AppSettings["isDBConnection"]) : true)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT [WebsiteOfficeIP] FROM [LoginPin] where id=1", con))
                    {
                        try
                        {
                            con.Open();
                            SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (string.IsNullOrEmpty(Convert.ToString(dr["WebsiteOfficeIP"])) == false)
                                    {
                                        bla = Convert.ToString(dr["WebsiteOfficeIP"]).Split(',').ToList();
                                    }
                                    else
                                    {
                                        bla = new List<string>();
                                    }
                                }
                            }

                            try
                            {
                                dr.Close();
                                con.Close();
                            }
                            catch { }

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            else
            {
                bla = Convert.ToString(ConfigurationManager.AppSettings["inHouseIp"]).Split(',').ToList();
            }
            return bla;
        }

        #endregion

        public bool isDomestic(string FromAirportCode, string ToAirportCode)
        {
            if (!FlightUtility.isMasterDataLoaded)
            {
                FlightUtility.LoadMasterData();
            }
            List<Airport> FromArp = FlightUtility.AirportList.Where(x => (x.airportCode.Equals(FromAirportCode, StringComparison.OrdinalIgnoreCase))).ToList();
            List<Airport> ToArp = FlightUtility.AirportList.Where(x => (x.airportCode.Equals(ToAirportCode, StringComparison.OrdinalIgnoreCase))).ToList();
            if (FromArp.Count > 0 && FromArp[0].countryCode.Equals("US", StringComparison.OrdinalIgnoreCase) && ToArp.Count > 0 && ToArp[0].countryCode.Equals("US", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (FromArp.Count > 0 && FromArp[0].countryCode.Equals("CA", StringComparison.OrdinalIgnoreCase) && ToArp.Count > 0 && ToArp[0].countryCode.Equals("CA", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
                return false;
        }

    }
}
namespace CoreLogWriter
{
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
            //try
            //{
            //txtWriter.Write("\r\nLog Entry : ");
            //txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
            //    DateTime.Now.ToLongDateString());
            //txtWriter.WriteLine("  :");
            txtWriter.WriteLine("{0}", logMessage);
            //txtWriter.WriteLine("-------------------------------");
            //}
            //catch (Exception ex)
            //{
            //}
        }
    }
}
