﻿using System;
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
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    featch_download();
                }
                catch (Exception exe)

                { }
            }
        }


        string query;
        private void featch_download()
        {
            query = "Select * from Download order by ID asc";
            SqlDataAdapter ad_occupa = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "Download");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

                lblmessage.Text = "Data doesn't exist";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                pnl_grid.Visible = false;
                grd_download.DataSource = null;
                grd_download.DataBind();

            }
            else
            {
                pnl_grid.Visible = true;
                grd_download.DataSource = ds;
                grd_download.DataBind();
            }
        }


        protected void grd_download_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_download.PageIndex = e.NewPageIndex;
            featch_download();
            grd_download.DataBind();
        }

        // add

        protected void btn_add_notice_board_Click(object sender, EventArgs e)
        {
            try
            {
                submit_data();
            }
            catch (Exception ex)
            {
            }

        }

        private void submit_data()
        {
            if (fileupload.HasFile)
            {
                string uploadfile = upload_file();

                if (uploadfile == "")
                {
                    lblmessage.Text = "Please Choose Valid File";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
                else
                {
                    SqlConnection con = new SqlConnection(My.conn);
                    con.Open();
                    SqlCommand cmd;
                    string strQuery = "INSERT INTO Download (Heading,Date,FilePath,idate) values (@Heading,@Date,@FilePath,@idate)";
                    cmd = new SqlCommand(strQuery);
                    cmd.Parameters.AddWithValue("@Date", txt_date.Text);
                    cmd.Parameters.AddWithValue("@Heading", txt_headline.Text);
                    cmd.Parameters.AddWithValue("@FilePath", uploadfile);
                    cmd.Parameters.AddWithValue("@idate", My.idate());
                    if (My.InsertUpdateData(cmd))
                    {
                        con.Close();
                        featch_download();

                        txt_headline.Text = "";
                        txt_date.Text = "";

                        lblmessage.Text = "Download file added successfully.";
                        scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                    }
                }
            }
            else
            {
                lblmessage.Text = "Please Select File";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
        }


        private string upload_file()
        {
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd_MM_yyyy");
            string time = dt.ToString("hh_mm_ss");
            Boolean Fileok = false;
            Boolean Filesaved = false;
            string dbfilpath = "";
            int k = 0;
            if (fileupload.HasFile)
            {
                Session["fileupload"] = fileupload.FileName;
                string FileExtension = Path.GetExtension(Session["fileupload"].ToString()).ToLower();
                string[] allowedExtensions = { ".doc", ".docx", ".pdf", ".txt", ".ppt", ".pptx", ".png", ".jpeg", ".jpg", ".gif", };

                Session["renamedFile"] = date + time + " Download " + FileExtension;
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    k++;
                    if (FileExtension == allowedExtensions[i])
                    {
                        Fileok = true;
                        break;
                    }
                }
            }
            else
            {
            }

            if (Fileok)
            {
                try
                {
                    string path = (Server.MapPath("../album/download")).ToString();
                    fileupload.SaveAs(path + "/" + Session["renamedfile"]);
                    Filesaved = true;
                }
                catch (Exception ex)
                {
                    Filesaved = false;
                }
            }

            else
            {
            }
            if (Filesaved)
            {
                string filename = Path.GetFileName(Session["renamedfile"].ToString());
                dbfilpath = @"/album/download/" + filename;
            }
            return dbfilpath;
        }


        protected void link_delete_Click1(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            string id = lbl_id.Text;

            link_delete(id);
            featch_download();
        }



        // edit
        #region Edit
        protected void grd_download_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblmessage.Text = "";
            GridViewRow row = grd_download.SelectedRow;
            Label lblid = ((Label)(row.FindControl("lbl_id")));

            string id;
            id = lblid.Text;

            Session["id"] = id;
            featch_edit_noticeboard(id);
        }

        private void featch_edit_noticeboard(string id)
        {
            SqlDataAdapter ad_occupa = new SqlDataAdapter("select * from Download where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "Download");
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

                txt_date.Text = dt.Rows[0][3].ToString();
                txt_headline.Text = dt.Rows[0][1].ToString();
                lbl_filepath3.Text = dt.Rows[0]["FilePath"].ToString();
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                string id;
                id = Session["id"].ToString();
                send_data(id);
            }
            catch (Exception exc)
            {
            }
        }

        private void send_data(string id)
        {

            string uploadfile = "";
            if (fileupload.HasFile)
            {
                uploadfile = upload_file();
            }
            else
            {
                uploadfile = lbl_filepath3.Text;
            }


            SqlDataAdapter ad = new SqlDataAdapter("select * from Download where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Download");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Heading"] = txt_headline.Text;
                    dr["Date"] = txt_date.Text;
                    dr["FilePath"] = uploadfile;

                    SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    featch_download();
                    lblmessage.Text = "Download File is edited successfully.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(2000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                    txt_date.Text = "";
                    txt_headline.Text = "";

                    pnl_btn_new_add.Visible = true;
                    pnl_btn_edit.Visible = false;
                }

            }
        }

        protected void btn_cencel_Click(object sender, EventArgs e)
        {
            txt_headline.Text = "";
            pnl_btn_new_add.Visible = true;
            pnl_btn_edit.Visible = false;
        }
        #endregion



        //delete

        private void link_delete(string id)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from Download where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Download");
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

        public string scrpt { get; set; }
    }

    } 

    
