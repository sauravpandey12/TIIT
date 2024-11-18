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
    public partial class add_video_category : System.Web.UI.Page
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
            query = "Select * from Video_category order by Category_name asc";
            SqlDataAdapter ad_occupa = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "Video_category");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

                lblmessage.Text = "Data doesn't exist";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                pnl_grid.Visible = false;
                grd_news_list.DataSource = null;
                grd_news_list.DataBind();

            }
            else
            {

                pnl_grid.Visible = true;
                grd_news_list.DataSource = ds;
                grd_news_list.DataBind();
            }
        }
        protected void grd_news_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_news_list.PageIndex = e.NewPageIndex;
            fetch_gridview();
            grd_news_list.DataBind();
        }
        #endregion


        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                add_news();
            }
            catch (Exception exc)
            {
                My.submitexception(exc.ToString());

            }
        }

        private void add_news()
        {
            SqlCommand cmd;
            string strQuery = "INSERT INTO Video_category (Category_name,Video_cat_id) values (@Category_name,@Video_cat_id)";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@Category_name", txt_name.Text);
            cmd.Parameters.AddWithValue("@Video_cat_id", My.auto_serial("Video_cat_id"));
            if (My.InsertUpdateData(cmd))
            { 
                fetch_gridview();
                txt_name.Text = ""; 
                lblmessage.Text = "Category has been added successfully.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
        }


        #region Edit
        protected void grd_news_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblmessage.Text = "";
            GridViewRow row = grd_news_list.SelectedRow;
            Label lblid = ((Label)(row.FindControl("lbl_id"))); 
            string id;
            id = lblid.Text; 
            Session["id"] = id;

            featch_edit_news(id);
        }

        private void featch_edit_news(string id)
        {
            SqlDataAdapter ad_occupa = new SqlDataAdapter("select * from Video_category where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "Video_category");
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
                txt_name.Text = dt.Rows[0]["Category_name"].ToString(); 
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

            SqlDataAdapter ad = new SqlDataAdapter("select * from Video_category where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Video_category");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Category_name"] = txt_name.Text; 
                    SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    fetch_gridview();
                    lblmessage.Text = "Category  is edited successfully.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                    txt_name.Text = ""; 
                    pnl_btn_new_add.Visible = true;
                    pnl_btn_edit.Visible = false;
                }

            }
        }

        protected void btn_cencel_Click(object sender, EventArgs e)
        {
            txt_name.Text = ""; 
            pnl_btn_new_add.Visible = true;
            pnl_btn_edit.Visible = false;
        }
        #endregion

        #region Delete
        protected void link_delete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            string id = lbl_id.Text;

            delete_news(id);
            fetch_gridview();
        }

        private void delete_news(string id)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from Video_category where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Video_category");
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


    }
}