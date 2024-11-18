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
    public partial class Add_News : System.Web.UI.Page
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
            query = "Select * from News order by ID asc";
            SqlDataAdapter ad_occupa = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "News");
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
            string strQuery = "INSERT INTO News (Date,Headline,Description) values (@Date,@Headline,@Description)";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@Date", txt_date.Text);
            cmd.Parameters.AddWithValue("@Headline", txt_headline.Text);
            cmd.Parameters.AddWithValue("@Description", txt_news_desc.Text);
            if (My.InsertUpdateData(cmd))
            {
             
                fetch_gridview();
                txt_date.Text = "";
                txt_headline.Text = "";
                txt_news_desc.Text = "";
                lblmessage.Text = "News added successfully.";
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
            SqlDataAdapter ad_occupa = new SqlDataAdapter("select * from News where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "News");
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
                txt_headline.Text = dt.Rows[0][2].ToString();
                txt_news_desc.Text = dt.Rows[0][3].ToString();
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

            SqlDataAdapter ad = new SqlDataAdapter("select * from News where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "News");
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
                    dr[2] = txt_headline.Text;
                    dr[3] = txt_news_desc.Text;
                    SqlCommandBuilder cmb = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    fetch_gridview();
                    lblmessage.Text = "News  is edited successfully.";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                    txt_date.Text = "";
                    txt_headline.Text = "";
                    txt_news_desc.Text = "";
                    pnl_btn_new_add.Visible = true;
                    pnl_btn_edit.Visible = false;
                }

            }
        }

        protected void btn_cencel_Click(object sender, EventArgs e)
        {
            txt_date.Text = "";
            txt_headline.Text = "";
            txt_news_desc.Text = "";
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
            SqlDataAdapter ad = new SqlDataAdapter("select * from News where Id='" + id + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "News");
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