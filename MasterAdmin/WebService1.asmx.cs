using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace TIIT.MasterAdmin
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        #region UploadvideO
        //----------------------------------------------------------------------------
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void send_video_data(string Headline, string Video_url, string Date, string Cat)
        {

            string actual_url = Video_url.Substring(17);

            SqlCommand cmd;
            string strQuery = "INSERT INTO Videos (Heading,Video_url,Date,Idate,Category,Upload_date) values (@Heading,@Video_url,@Date,@Idate,@Category,@Upload_date);";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@Heading", Headline);
            cmd.Parameters.AddWithValue("@Video_url", "https://www.youtube.com/watch?v=" + actual_url);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Idate", My.idate());
            cmd.Parameters.AddWithValue("@Category", Cat);
            cmd.Parameters.AddWithValue("@Upload_date", My.date());
            if (My.InsertUpdateData(cmd))
            {
            }
        }



        //===---===FetchVideO
        public class Fetch_video
        {
            public string Id { get; set; }
            public string Date { get; set; }
            public string Heading { get; set; }
            public string Video_url { get; set; }
        }


        List<Fetch_video> Show_video = new List<Fetch_video>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_video_details()
        {
            string query = "Select * from Videos order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Videos");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_video.Add(new Fetch_video
                    {
                        Id = dr["Id"].ToString(),
                        Date = dr["Date"].ToString(),
                        Heading = dr["Heading"].ToString(),
                        Video_url = dr["Video_url"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_video));
            }
        }


        //===--====DeletevideO
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void delete_video(string Id)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from Videos where id='" + Id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Videos");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr.Delete();
                    break;
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
        }

        #endregion


        public class Fetch_video_by_cat
        {
            public string Id { get; set; }
            public string Date { get; set; }
            public string Heading { get; set; }
            public string Video_url { get; set; }
        }


        List<Fetch_video_by_cat> Show_video_by_cat = new List<Fetch_video_by_cat>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_video_details_by_cat(string Cat)
        {
            string query = "Select * from Videos where Category='" + Cat + "' order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Videos");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_video_by_cat.Add(new Fetch_video_by_cat
                    {
                        Id = dr["Id"].ToString(),
                        Date = dr["Date"].ToString(),
                        Heading = dr["Heading"].ToString(),
                        Video_url = dr["Video_url"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_video_by_cat));
            }
        }
    }
}
