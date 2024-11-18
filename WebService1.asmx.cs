using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace TIIT
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        //-----------------------------news-------------------------------------       
        #region NewS
        //------------------------------News & Events--------------------------------------
        public class Fetch_Details_of_News
        {
            public string Date { get; set; }
            public string Headline { get; set; }
            public string Description { get; set; }
        }

        List<Fetch_Details_of_News> Show_of_news_details = new List<Fetch_Details_of_News>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_news_details()
        {
            string query = "Select * from News order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "News");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_news_details.Add(new Fetch_Details_of_News
                    {
                        Date = dr["Date"].ToString(),
                        Headline = dr["Headline"].ToString(),
                        Description = dr["Description"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_news_details));
            }

        }
        #endregion

        //-----------------------------gallery-------------------------------------       
        #region GallerY
        //-------------------------------Gallery--------------------------------------


        public class Fetch_Category_of_gallery
        {
            public string Category { get; set; }
        }


        List<Fetch_Category_of_gallery> Show_of_category_details = new List<Fetch_Category_of_gallery>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_category()
        {
            string query = "Select DISTINCT Category from Imagegallery order by Category DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Imagegallery");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_category_details.Add(new Fetch_Category_of_gallery
                    {
                        Category = dr["Category"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_category_details));
            }

        }

        public class Fetch_all_images_of_gallery
        {
            public string image_path { get; set; }
            public string Category { get; set; }
        }


        List<Fetch_all_images_of_gallery> Show_of_all_images = new List<Fetch_all_images_of_gallery>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_gallery_all_image()
        {
            string query = "Select * from Imagegallery order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Imagegallery");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_all_images.Add(new Fetch_all_images_of_gallery
                    {
                        image_path = dr["image_path"].ToString(),
                        Category = dr["Category"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_all_images));
            }

        }

        //-------------------------------------------------------------

        public class Fetch_images_of_gallery_cat_vise
        {
            public string image_path { get; set; }
            public string Category { get; set; }
        }

        List<Fetch_images_of_gallery_cat_vise> Show_of_images_cat_vise = new List<Fetch_images_of_gallery_cat_vise>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_gallery_image_cat_wise(string Cat_Value)
        {
            string query = "Select * from Imagegallery where Category='" + Cat_Value + "' order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Imagegallery");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_images_cat_vise.Add(new Fetch_images_of_gallery_cat_vise
                    {
                        image_path = dr["image_path"].ToString(),
                        Category = dr["Category"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_images_cat_vise));
            }

        }
        #endregion

        //------------------------------gallery home page--------------------------------------       
        #region HomeGallery
        public class Fetch_hm_images_of_gallery
        {
            public string image_path { get; set; }
        }
        List<Fetch_hm_images_of_gallery> Show_of_hm_images = new List<Fetch_hm_images_of_gallery>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_gallery_hm_image()
        {
            string query = "Select top 8 * from Imagegallery order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Imagegallery");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_hm_images.Add(new Fetch_hm_images_of_gallery
                    {
                        image_path = dr["image_path"].ToString(),

                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_hm_images));
            }

        }


        #endregion

        //------------------------------news-------------------------------------       
        #region AnnualreporT

        //------------------------------AnnualreporT--------------------------------------
        public class Fetch_Details_of_annual_report
        {
            public string Heading { get; set; }
            public string FilePath { get; set; }
            public string Date { get; set; }
            public string Year { get; set; }
        }


        List<Fetch_Details_of_annual_report> Show_of_annual_report_details = new List<Fetch_Details_of_annual_report>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_annual_details()
        {
            string query = "Select * from Annual_Report order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Annual_Report");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_annual_report_details.Add(new Fetch_Details_of_annual_report
                    {
                        Heading = dr["Heading"].ToString(),
                        FilePath = dr["FilePath"].ToString(),
                        Date = dr["Date"].ToString(),
                        Year = dr["Year"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_annual_report_details));
            }
        }
        #endregion

        //------------------------------MediaGallery--------------------------------------
        #region MediaGallery
        public class Fetch_media_images
        {
            public string image_path { get; set; }
            public string heading { get; set; }
        }

        List<Fetch_media_images> Show_of_media_images = new List<Fetch_media_images>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_media_gallery()
        {
            string query = "Select * from Media_Coverage order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Media_Coverage");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_media_images.Add(new Fetch_media_images
                    {
                        image_path = dr["File_path"].ToString(),
                        heading = dr["Heading"].ToString(),

                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_media_images));
            }

        }

        #endregion

        #region

        //------------------------------notice Board Default --------------------------------------

        public class Fetch_Details_of_notice_board
        {
            public string Heading { get; set; }
            public string FilePath { get; set; }
            public string Date { get; set; }
        }

        List<Fetch_Details_of_notice_board> Show_of_notice_board_details = new List<Fetch_Details_of_notice_board>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]


        public void fetch_notice_details()
        {
            string query = "Select Top 4 * from Notice_Board order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Notice_Board");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_notice_board_details.Add(new Fetch_Details_of_notice_board
                    {
                        Heading = dr["Heading"].ToString(),
                        FilePath = dr["FilePath"].ToString(),
                        Date = dr["Date"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_notice_board_details));
            }

        }
        #endregion

        #region

        //------------------------------notice Board Page --------------------------------------

        public class Fetch_Details_of_notice_board_page
        {
            public string Heading { get; set; }
            public string FilePath { get; set; }
            public string Date { get; set; }
        }

        List<Fetch_Details_of_notice_board_page> Show_of_notice_board_details_page = new List<Fetch_Details_of_notice_board_page>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]


        public void fetch_notice_details_page()
        {
            string query = "Select * from Notice_Board order by ID asc";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Notice_Board");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_notice_board_details_page.Add(new Fetch_Details_of_notice_board_page
                    {
                        Heading = dr["Heading"].ToString(),
                        FilePath = dr["FilePath"].ToString(),
                        Date = dr["Date"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_notice_board_details_page));
            }

        }

        #endregion

        //------------------------------video gallery----------------------------------
        #region UploadvideO
        //----------------------------------------------------------------------------
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void send_video_data(string Headline, string Video_url)
        {

            string actual_url = Video_url.Substring(17);

            SqlConnection con = new SqlConnection(My.conn);
            con.Open();
            SqlCommand cmd;
            string strQuery = "INSERT INTO Videos (Heading,Video_url,Date,Idate) values (@Heading,@Video_url,@Date,@Idate);";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@Heading", Headline);
            cmd.Parameters.AddWithValue("@Video_url", "https://www.youtube.com/watch?v=" + actual_url);
            cmd.Parameters.AddWithValue("@Date", My.date());
            cmd.Parameters.AddWithValue("@Idate", My.idate());
            if (My.InsertUpdateData(cmd))
            {
                con.Close();
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



        public class Fetch_vdo_cat
        {
            public string Category_name { get; set; }
            public string Video_cat_id { get; set; }
        }

        List<Fetch_vdo_cat> Show_of_vdo_cat = new List<Fetch_vdo_cat>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_video_cat_details()
        {
            string query = "select t2.Category_name,t2.Video_cat_id from Videos t1 join Video_category t2 on t1.Category=t2.Video_cat_id group by t2.Category_name,t2.Video_cat_id  order by t2.Category_name asc";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Video_category");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_vdo_cat.Add(new Fetch_vdo_cat
                    {
                        Category_name = dr["Category_name"].ToString(),
                        Video_cat_id = dr["Video_cat_id"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_vdo_cat));
            }

        }
        //ByCAT
        //===---===FetchVideO
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
        #endregion

        #region popup
        //----------------------------popup -------------------------------------
        public class Fetch_Details_popup
        {

            public string Filepath { get; set; }
        }

        List<Fetch_Details_popup> Show_of_popup_details = new List<Fetch_Details_popup>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_popup_details()
        {
            string query = "Select * from Popup order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Popup");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_popup_details.Add(new Fetch_Details_popup
                    {
                        Filepath = dr["File_path"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_popup_details));
            }

        }
        #endregion

        #region NewS main
        //------------------------------News home--------------------------------------
        public class Fetch_Details_of_Newsmain
        {
            public string Headline22 { get; set; }
        }
        List<Fetch_Details_of_Newsmain> Show_of_news_detailsmain = new List<Fetch_Details_of_Newsmain>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fetch_news_detailsmain()
        {
            string query = "Select* from News order by ID DESC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "News");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_news_detailsmain.Add(new Fetch_Details_of_Newsmain
                    {
                        Headline22 = dr["Headline"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_news_detailsmain));
            }

        }

        #endregion

        #region Download file

        public class Fetch_Details_of_downloadFile
        {
            public string Heading { get; set; }
            public string FilePath { get; set; }
            public string Date { get; set; }
        }

        List<Fetch_Details_of_downloadFile> Show_of_download_details_page = new List<Fetch_Details_of_downloadFile>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]


        public void fetch_download_page()
        {
            string query = "Select * from Download order by ID asc";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Download");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_download_details_page.Add(new Fetch_Details_of_downloadFile
                    {
                        Heading = dr["Heading"].ToString(),
                        FilePath = dr["FilePath"].ToString(),
                        Date = dr["Date"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_download_details_page));
            }

        }

        #endregion

        #region Mandatory public disc

        public class Fetch_Details_of_mpd
        {
            public string Heading { get; set; }
            public string FilePath { get; set; }
            public string Date { get; set; }
        }

        List<Fetch_Details_of_mpd> Show_of_mpd_details = new List<Fetch_Details_of_mpd>();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]


        public void fetch_madatory_public_Discolar()
        {
            string query = "Select * from Mandatory_PD order by ID ASC";
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Mandatory_PD");
            DataTable dt = ds.Tables[0];
            int rowcount1 = dt.Rows.Count;
            if (rowcount1 == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Show_of_mpd_details.Add(new Fetch_Details_of_mpd
                    {
                        Heading = dr["Heading"].ToString(),
                        FilePath = dr["FilePath"].ToString(),
                        Date = dr["Date"].ToString(),
                    });
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(Show_of_mpd_details));
            }

        }
        #endregion

    }
}
