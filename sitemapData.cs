using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DAL
{
    public class sitemapData
    {
        //public SiteMapList getSiteMapData()
        //{
        //    SiteMapList smlst = new SiteMapList() { sitemapAirline = new List<sitemapDetails>(), sitemapCity = new List<sitemapDetails>(), sitemapGeneric = new List<sitemapDetails>() };
        //    SqlParameter[] param = new SqlParameter[2];
        //    using (SqlConnection con = DataConnection.GetConnection())
        //    {
        //        DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "getSitemapDynamicValue", param);
        //        if (ds != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[0].Rows)
        //                {
        //                    sitemapDetails siteMap = new sitemapDetails();
        //                    siteMap.code = dr["AirlineCode"].ToString();
        //                    siteMap.name = dr["AirlineName"].ToString();
        //                    if (!string.IsNullOrEmpty(siteMap.code))
        //                        smlst.sitemapAirline.Add(siteMap);
        //                }
        //            }
        //            if (ds.Tables[1].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[1].Rows)
        //                {
        //                    sitemapDetails siteMap = new sitemapDetails();
        //                    siteMap.code = dr["CityCode"].ToString();
        //                    siteMap.name = dr["CityName"].ToString();
        //                    if (!string.IsNullOrEmpty(siteMap.code))
        //                        smlst.sitemapCity.Add(siteMap);
        //                }
        //            }
        //            if (ds.Tables[2].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[2].Rows)
        //                {
        //                    sitemapDetails siteMap = new sitemapDetails();
        //                    siteMap.name = dr["GenericName"].ToString();
        //                    if (!string.IsNullOrEmpty(siteMap.name))
        //                        smlst.sitemapGeneric.Add(siteMap);
        //                }
        //            }
        //        }
        //    }
        //    return smlst;
        //}
    }
}
