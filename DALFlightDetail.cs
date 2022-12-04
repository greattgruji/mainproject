using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALFlightDetail
    {
        public DataTable GetAirlineBaggage()
        {
            DataTable dtAirlineBaggage;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM AirlineBaggage", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        dtAirlineBaggage = new DataTable();
                        sda.Fill(dtAirlineBaggage);
                    }
                }
            }

            return dtAirlineBaggage;
        }
    }
}
