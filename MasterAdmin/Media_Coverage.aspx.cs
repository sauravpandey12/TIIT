using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace TIIT.MasterAdmin
{
    public partial class Media_Coverage : System.Web.UI.Page
    {
        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                fetch_gridview();
            }
            catch (Exception exc)
            {

            }
        }

        string query;
        private void fetch_gridview()
        {
            query = "Select * from Media_Coverage order by ID asc";
            SqlDataAdapter ad_occupa = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "Media_Coverage");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

                lblmessage.Text = "Data doesn't exist";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                pnl_grid.Visible = false;
                grd_media_coverage_list.DataSource = null;
                grd_media_coverage_list.DataBind();

            }
            else
            {

                pnl_grid.Visible = true;
                grd_media_coverage_list.DataSource = ds;
                grd_media_coverage_list.DataBind();
            }
        }

        protected void grd_media_coverage_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_media_coverage_list.PageIndex = e.NewPageIndex;
            fetch_gridview();
            grd_media_coverage_list.DataBind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                upload_media_coverage();
            }
            catch (Exception exc)
            {

            }
        }

        private void upload_media_coverage()
        {
            string filepath = "#";
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 600000)
                {
                    filepath = upload_media_attachment();
                    if (filepath == "")
                    {
                        lblmessage.Text = "Please choose Image";

                        scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                    }
                    else
                    {
                        finsl_submit(filepath);
                    }
                }
                else
                {
                    lblmessage.Text = "Please Reduce or compress size of attachment max(600kb)";

                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }

            }
            else
            {
                lblmessage.Text = "Please choose file";

                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
        }

        private string upload_media_attachment()
        {
            string dbfilePath = "";
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd_MM_yyyy");
            string time = dt.ToString("hh_mm_ss");
            String filerename = date + time;
            Boolean FileOK = false;
            Boolean FileSaved = false;
            int k = 0;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 600000)
                {
                    Session["WorkingImage"] = FileUpload1.FileName;
                    string FileExtension = Path.GetExtension(Session["WorkingImage"].ToString()).ToLower();
                    Session["renamedfile"] = filerename + "PIMG1" + FileExtension;
                    string[] allowedExtension = { ".png", ".PNG", ".jpg", ".JPG", ".JPEG", ".jpeg", ".gif", ".pdf", ".PDF", ".doc", ".docx", ".xlsx" };
                    for (int i = 0; i < allowedExtension.Length; i++)
                    {
                        k++;
                        if (FileExtension == allowedExtension[i])
                        {
                            FileOK = true;
                            lblmessage.Text = "";
                            break;
                        }
                    }
                }
                else
                {
                    lblmessage.Text = "Please Reduce or compress size of image max(600kb)";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
            else
            {
                lblmessage.Text = "Please upload file first.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            if (FileOK)
            {
                try
                {
                    string path = (Server.MapPath("/album")).ToString();
                    FileUpload1.SaveAs(path + "/" + Session["renamedfile"]);
                    FileSaved = true;
                }
                catch (Exception ex)
                {
                    FileSaved = false;
                    lblmessage.Text = "File has not save.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
            else
            {

            }
            if (FileSaved)
            {
                string originalPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "");
                string fileName = Path.GetFileName(Session["renamedfile"].ToString());
                dbfilePath = originalPath + "/album/" + fileName;
            }
            return dbfilePath;
        }

        private void finsl_submit(string filepath)
        {
            SqlConnection con = new SqlConnection(My.conn);
            con.Open();
            SqlCommand cmd;
            string strQuery = "INSERT INTO Media_Coverage (File_path,Date,Heading,idate) values (@File_path,@Date,@Heading,@idate)";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@Date", txt_date.Text);
            cmd.Parameters.AddWithValue("@Heading", txt_heading.Text);
            cmd.Parameters.AddWithValue("@File_path", filepath);
            cmd.Parameters.AddWithValue("@idate", My.idate());
            if (My.InsertUpdateData(cmd))
            {
                con.Close();
                fetch_gridview();
                txt_date.Text = "";
                txt_heading.Text = "";
                lblmessage.Text = "Media coverage added successfully.";

                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

            }
        }

        protected void grd_media_coverage_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblmessage.Text = "";
            GridViewRow row = grd_media_coverage_list.SelectedRow;
            Label lblid = ((Label)(row.FindControl("lbl_id")));

            string id;
            id = lblid.Text;



            Session["id"] = id;

            featch_edit_media(id);
        }

        private void featch_edit_media(string id)
        {
            SqlDataAdapter ad_occupa = new SqlDataAdapter("select * from Media_Coverage where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "Media_Coverage");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                pnl_btn_new_add.Visible = true;
            }
            else
            {
                pnl_btn_new_add.Visible = false;
                pnl_btn_edit.Visible = true;
                txt_date.Text = dt.Rows[0][1].ToString();
                txt_heading.Text = dt.Rows[0][2].ToString();
                lbl_image_path.Text = dt.Rows[0][3].ToString();
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                string id;
                id = Session["id"].ToString();
                send_data_update(id);
            }
            catch (Exception exc)
            {
            }
        }

        private void send_data_update(string id)
        {
            string filepath = "";
            if (FileUpload1.HasFile)
            {
                filepath = updare_media_file();

            }
            else
            {
                filepath = lbl_image_path.Text;
            }
            SqlDataAdapter ad = new SqlDataAdapter("select * from Media_Coverage where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Media_Coverage");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {

                foreach (DataRow dr in dt.Rows)
                {
                    dr[1] = txt_date.Text;
                    dr[2] = txt_heading.Text;

                    if (filepath != "")
                    {
                        dr[3] = filepath;
                    }

                    SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    fetch_gridview();
                    lblmessage.Text = "Media coverage is edited successfully.";

                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                    txt_date.Text = "";
                    txt_heading.Text = "";
                    pnl_btn_new_add.Visible = true;
                    pnl_btn_edit.Visible = false;
                }

            }
        }

        private string updare_media_file()
        {

            string dbfilePath3 = "";
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd_MM_yyyy");
            string time = dt.ToString("hh_mm_ss");
            String filerename = date + time;
            Boolean FileOK = false;
            Boolean FileSaved = false;
            int k = 0;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 500000)
                {
                    Session["WorkingImage"] = FileUpload1.FileName;
                    string FileExtension = Path.GetExtension(Session["WorkingImage"].ToString()).ToLower();
                    Session["renamedfile"] = filerename + "PIMG1" + FileExtension;
                    string[] allowedExtension = { ".png", ".jpg", ".JPG", ".JPEG", ".gif" };
                    for (int i = 0; i < allowedExtension.Length; i++)
                    {
                        k++;
                        if (FileExtension == allowedExtension[i])
                        {
                            FileOK = true;
                            lblmessage.Text = "";
                            break;
                        }
                    }
                }
                else
                {
                    lblmessage.Text = "Please Reduce or compress size of signature max(600kb)";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
            else
            {
                lblmessage.Text = "Please upload file first.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            if (FileOK)
            {
                try
                {
                    string path = (Server.MapPath("../album")).ToString();
                    FileUpload1.SaveAs(path + "/" + Session["renamedfile"]);
                    FileSaved = true;
                }
                catch (Exception exe)
                {
                    FileSaved = false;
                    lblmessage.Text = "File has not save.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
            else
            {

            }
            if (FileSaved)
            {
                string originalPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "");
                string fileName = Path.GetFileName(Session["renamedfile"].ToString());
                dbfilePath3 = originalPath + "/album/" + fileName;
            }
            return dbfilePath3;
        }

        protected void btn_cencel_Click(object sender, EventArgs e)
        {
            txt_date.Text = "";
            txt_heading.Text = "";
            pnl_btn_new_add.Visible = true;
            pnl_btn_edit.Visible = false;
        }

        protected void link_delete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            string id = lbl_id.Text;

            delete_media_news(id);
            fetch_gridview();
        }

        private void delete_media_news(string id)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from Media_Coverage where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Media_Coverage");
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
                pnl_grid.Visible = false;
                lblmessage.Text = "Deletion process has been completed.";

                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

            }
        }

       
    }
}