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
    public partial class Change_Password : System.Web.UI.Page
    {
        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_change_password_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_old_password.Text == "")
                {
                    lblmessage.Text = "Enter old password";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
                else
                {
                    changePassword_in_db();

                }

            }
            catch (Exception exc)
            {
            }
        }

        private void changePassword_in_db()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from Admin_login where password='" + txt_old_password.Text + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Admin_login");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 1)
            {
                if (txt_new_password.Text == txt_confirm.Text)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[2] = Convert.ToString(txt_confirm.Text);
                        SqlCommandBuilder ac = new SqlCommandBuilder(ad);
                        ad.Update(dt);
                        lblmessage.Text = "Password is changed successfully.";
                        scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

                        txt_old_password.Text = "";
                        txt_new_password.Text = "";
                        txt_confirm.Text = "";
                    }

                }
                else
                {
                    lblmessage.Text = "New password and confirm password does not match";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }

            else
            {
                lblmessage.Text = "Old password is incorrect";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);

            }
        }
    }
}