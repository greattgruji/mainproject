using Core.Flight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GetSetDataBase
    {
        public List<Airport> getAllAirport()
        {
            List<Airport> arpList = new List<Airport>();
            DataSet ds = SqlHelper.ExecuteDataset(DataConnection.GetConnection(), CommandType.Text, "select * from airport_details  order by CityCode, cityPriority, AirportName ");
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Airport arp = new Airport();
                    arp.airportCode = dr["AirportCode"].ToString();
                    arp.airportName = dr["AirportName"].ToString();
                    arp.cityCode =  dr["CityCode"].ToString();
                    arp.cityName =  dr["CityName"].ToString();
                    arp.countryCode = dr["Country"].ToString();
                    arp.countryName = dr["CountryName"].ToString();
                    arp.stateCode = dr["StateCode"].ToString();
                    arp.stateName = dr["StateName"].ToString();
                    arp.continent = dr["Continent"].ToString();

                    if (arp.countryName.ToUpper() == "USA")
                    {
                      arp.countryName = arp.countryName.ToUpper();
                    }
                    arpList.Add(arp);
                }
            }
            return arpList;
        }
    }
}
