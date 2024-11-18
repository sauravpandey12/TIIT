using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIIT.MasterAdmin
{
    public partial class Upload_Image : System.Web.UI.Page
    {
        string query1 = "";
        static string query = "Select * from Imagegallery";
        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    find_category();
                    Show_image(query);
                    Show_image(query1);
                }
                catch (Exception exc)
                {
                }
            }
        }

        private void find_category()
        {
            ArrayList al = new ArrayList();

            SqlDataAdapter ad = new SqlDataAdapter("Select distinct Category from Imagegallery", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Imagegallery");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

                al.Add("Select");
                al.Add("Other");
                ddl_categorgy.DataSource = al;
                ddl_categorgy.DataBind();
            }
            else
            {
                al.Add("Select");
                foreach (DataRow dr in dt.Rows)
                {
                    al.Add(dr[0].ToString());
                }
                al.Add("Other");

                ddl_categorgy.DataSource = al;
                ddl_categorgy.DataBind();

            }
        }
        private void Show_image(string query)
        {

            SqlDataAdapter ad_occupa = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                pnl_view_image.Visible = false;
                dlImages.DataSource = null;
                dlImages.DataBind();
            }
            else
            {
                pnl_view_image.Visible = true;
                dlImages.DataSource = ds;
                dlImages.DataBind();
            }
        }
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_categorgy.Text != "Select")

                    if (FileUpload1.HasFile)
                    {

                        if (ddl_categorgy.Text == "Other")
                        {
                            if (txt_category.Text != "")
                            {
                                send_data();
                            }

                            else
                            {
                                lblmessage.Text = "Please Enter Categorgy ";
                                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                            }
                        }
                        else
                        {
                            send_data();
                            //query1 = "select * from Imagegallery where Category='" + ddl_categorgy.Text + "'";
                            Show_image(query1);
                        }
                    }
                    else
                    {
                        lblmessage.Text = "Please choose Image";
                        scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                    }

                else
                {
                    lblmessage.Text = "Please select Categorgy";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }

            }
            catch (Exception exc)
            {
            }

        }
        protected void ddl_categorgy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_categorgy.Text == "Select")
            {
                lblmessage.Text = "Please select Categorgy";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                txt_category.Visible = false;
                txt_category.Text = "";
            }
            else if (ddl_categorgy.Text == "Other")
            {
                txt_category.Visible = true;
                txt_category.Text = "";
            }
            else
            {
                txt_category.Text = ddl_categorgy.Text;
                txt_category.Visible = false;
            }
            try
            {
                query1 = "select * from Imagegallery where Category='" + ddl_categorgy.Text + "'";
                Show_image(query1);
            }
            catch (Exception exc)
            {

            }

        }

        private void send_data()
        {
            string imagepath = Upload_Images();
            if (imagepath == "")
            {
            }
            else
            {

                SqlDataAdapter ad = new SqlDataAdapter("select * from Imagegallery", My.conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Imagegallery");
                DataTable dt = ds.Tables[0];
                int rowcount = ds.Tables[0].Rows.Count;
                DataRow dr = dt.NewRow();
                DateTime dtTmrw2 = DateTime.UtcNow;
                string date = dtTmrw2.ToString("dd/MM/yyyy");
                dr[0] = imagepath;
                dr[1] = txt_category.Text;
                dr[2] = date;
                dt.Rows.Add(dr);
                SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
                ad.Update(dt);
                query1 = "select * from Imagegallery where Category='" + txt_category.Text + "'";
                Show_image(query1);
                find_category();
                txt_category.Visible = false;
                lblmessage.Text = "Image has been saved successfully";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
        }

        private string Upload_Images()
        { 
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd_MM_yyyy");
            string time = dt.ToString("hh_mm_ss");
            String filerename = date + time;             // rename file
            string dbfilePath = "";
            Boolean FileOK = false;
            Boolean FileSaved = false;
            int k = 0;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 600000)
                {
                    Session["WorkingImage"] = FileUpload1.FileName;
                    String FileExtension = Path.GetExtension(Session["WorkingImage"].ToString()).ToLower();
                    Session["renamedfile"] = filerename + "PIMG1" + FileExtension;
                    String[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".gif", ".JPEG" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        k++;
                        if (FileExtension == allowedExtensions[i])
                        {
                            FileOK = true;
                            lblmessage.Text = "";
                            break;
                        }
                    }
                }
                else
                {
                    lblmessage.Text = "Please Reduce or compress Size of image Max(500kb)";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
            else
            {
                lblmessage.Text = "Please select image first";
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
                catch (Exception ex)
                {
                    FileSaved = false;
                    lblmessage.Text = " Image has not save";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
            else
            {
            }
            if (FileSaved)
            {
                string fileName = Path.GetFileName(Session["renamedfile"].ToString());
                dbfilePath = @"/album/" + fileName;
            }
            return dbfilePath;
        }

        protected void dlImages_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                Label lbl_imgeid = (Label)e.Item.FindControl("lbl_imageid");
                string image_id = lbl_imgeid.Text;
                delete_image(image_id);
                Show_image(query);
            }
            catch (Exception exc)
            {
            }
        }

        private void delete_image(string image_id)
        {

            SqlDataAdapter ad_occupa = new SqlDataAdapter("select * from Imagegallery where Id='" + image_id + "'", My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "Imagegallery");
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
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad_occupa);
                    ad_occupa.Update(dt);
                    break;
                }
            }
        }
    }
}