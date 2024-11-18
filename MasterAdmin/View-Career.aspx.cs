using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIIT.MasterAdmin
{
    public partial class View_Career : System.Web.UI.Page
    {
        #region PageloaD
        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    fetch_gridview();
                }
                catch (Exception exc)
                {

                }
            }
        }
        string query;
        private void fetch_gridview()
        {
            query = "Select * from Career order by ID asc";
            SqlDataAdapter ad_occupa = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "Career");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

                lblmessage.Text = "Data doesn't exist";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                pnl_grid.Visible = false;
                grd_enquiry_list.DataSource = null;
                grd_enquiry_list.DataBind();

            }
            else
            {

                pnl_grid.Visible = true;
                grd_enquiry_list.DataSource = ds;
                grd_enquiry_list.DataBind();
            }
        }
        protected void grd_enquiry_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_enquiry_list.PageIndex = e.NewPageIndex;
            fetch_gridview();
            grd_enquiry_list.DataBind();
        }
        #endregion

        #region Delete
        protected void link_delete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            string id = lbl_id.Text;

            delete_enquiry(id);
            fetch_gridview();
        }

        private void delete_enquiry(string id)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from Career where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Career");
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
        #endregion


        #region date find
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (txt_start_date.Text == "")
            {
                lblmessage.Text = "Please select start date";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }

            else if (txt_end_date.Text == "")
            {
                lblmessage.Text = "Please select end date";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

            }

            else
            {
                string start_date = txt_start_date.Text;
                string day = start_date.Substring(0, 2);
                string month = start_date.Substring(3, 2);
                string year = start_date.Substring(6, 4);

                string end_date = txt_end_date.Text;
                string end_day = end_date.Substring(0, 2);
                string end_month = end_date.Substring(3, 2);
                string end_year = end_date.Substring(6, 4);

                int idate = Convert.ToInt32(year + month + day);
                int idate2 = Convert.ToInt32(end_year + end_month + end_day);
                try
                {
                    if (idate > idate2)
                    {

                        lblmessage.Text = "End date cannot be less than start date.";
                        scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                        grd_enquiry_list.Visible = false;
                    }
                    else
                    {
                        fill_gdidvied(idate, idate2);
                        ViewState["flag"] = "3";
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void fill_gdidvied(int idate, int idate2)
        {

            SqlDataAdapter ad = new SqlDataAdapter("Select * from Career where idate>='" + idate + "' and idate<='" + idate2 + "' order by Id DESC", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Career");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {


                lblmessage.Text = "Data doesn't exist.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                grd_enquiry_list.Visible = false;
                grd_enquiry_list.DataSource = null;
                grd_enquiry_list.DataBind();
            }
            else
            {
                grd_enquiry_list.Visible = true;
                grd_enquiry_list.DataSource = ds;
                grd_enquiry_list.DataBind();
            }
        }

        #endregion



        #region
        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("View-Career.aspx", false);
        }

        #endregion


    }
}