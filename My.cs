using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace TIIT
{
    public class My
    {
        public static string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;   

        internal static DataTable dataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(My.conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            cmd.Dispose();
            return dt;
        }

        public static string tabletojson(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            Object collectionWrapper = new
            {
                success = parentRow
            };

            return jsSerializer.Serialize(collectionWrapper);
        }
        public static DataTable dataTable(string query, String conn)
        {
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds.Tables[0];
        }
        //----------------------------------------------System Date & Idate
        public static string date()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
        }
        public static string idate()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
        }
        public static string time()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hh:mm:ss tt");
        }
        public static string itime()
        {
            return DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("HHmmss");
        }
        //----------------------------------------------Idate
        public static int DateConvertToIdate(string date)
        {
            DateTime d11 = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string idate = d11.ToString("yyyyMMdd");
            return Convert.ToInt32(idate);
        }

        //---------------------------Bind DDL----------------------------------
        public void bind_all_ddl_with_id(DropDownList ddl, string query)
        {

            SqlConnection conn = new SqlConnection(My.conn);
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();

            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tests");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl.DataTextField = "Select";
                ddl.DataValueField = "Select";

            }

            else
            {
                ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
                ddl.DataValueField = ds.Tables[0].Columns[1].ToString();
            }
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "Select"));
        }

        public void bind_all_ddl_with_id_all(DropDownList ddl, string query)
        {

            SqlConnection conn = new SqlConnection(My.conn);
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();

            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tests");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl.DataTextField = "Select";
                ddl.DataValueField = "Select";

            }

            else
            {
                ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
                ddl.DataValueField = ds.Tables[0].Columns[1].ToString();
            }
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("All", "All"));
        }

        //------------------------------------------Insert Update Data
        public static Boolean InsertUpdateData(SqlCommand cmd)
        {
            String strConnString = My.conn;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
            return true;


        }


        public void bind_all_ddl(DropDownList ddl, string query)
        {

            SqlConnection conn = new SqlConnection(My.conn);
            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();

            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tests");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl.DataTextField = "Select";
                ddl.DataValueField = "Select";

            }

            else
            {
                ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
                ddl.DataValueField = ds.Tables[0].Columns[1].ToString();
            }
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "Select"));
        }

        #region common

        public static void execute_query(string query)
        {
            SqlConnection conn = new SqlConnection(My.conn);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);

        }
        public static void fetch_year(DropDownList ddl)
        {
            ArrayList ar = new ArrayList();
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            int year = dt.AddYears(1).Year;
            ar.Add("Select");
            for (int i = 2015; i <= year; i++)
            {
                ar.Add(i);
            }
            ddl.DataSource = ar;
            ddl.DataBind();
        }
        public static void fetch_month(DropDownList ddl)
        {
            ArrayList ar = new ArrayList();
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            int year = dt.AddYears(1).Year;
            ar.Add("Select");
            for (int i = 1; i <= 12; i++)
            {
                ar.Add(i.ToString("00"));
            }
            ddl.DataSource = ar;
            ddl.DataBind();
        }
        public static void fetch_days(DropDownList ddl)
        {
            ArrayList ar = new ArrayList();
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            int year = dt.AddYears(1).Year;
            ar.Add("Select");
            for (int i = 1; i <= 31; i++)
            {
                ar.Add(i.ToString("00"));
            }
            ddl.DataSource = ar;
            ddl.DataBind();
        }
        public static void bind_ddl(DropDownList ddl, string query)
        {
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            foreach (DataRow dr in dt.Rows)
            {
                ar.Add(dr[0].ToString());
            }
            ddl.DataSource = ar;
            ddl.DataBind();
        }
        public static void bind_ddl_other(DropDownList ddl, string query)
        {
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            foreach (DataRow dr in dt.Rows)
            {
                ar.Add(dr[0].ToString());
            }
            ar.Add("Other");
            ddl.DataSource = ar;
            ddl.DataBind();
        }
        public static void bind_gridview(GridView gridview, string query)
        {
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            gridview.DataSource = ds;
            gridview.DataBind();
        }
        public static void bind_datalist(DataList dtlst, string query)
        {
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dtlst.DataSource = ds;
            dtlst.DataBind();
        }
        public static bool exeSql(string query)
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                return true;
            }
            catch (Exception esc)
            {
                return false;
            }
        }
        public static void executeQuery(string query)
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
                DataSet ds = new DataSet();
                ad.Fill(ds);

            }
            catch (Exception esc)
            {

            }
        }
        public static DataTable datatable(string query)
        {
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public static void bind_ddl_with_para(DropDownList ddl, string query)
        {
            SqlDataAdapter ad = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tests");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl.DataTextField = "Select";
                ddl.DataValueField = "Select";

            }
            else
            {
                ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
                ddl.DataValueField = ds.Tables[0].Columns[1].ToString();
            }

            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }
        public static void submitException(Exception exception)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from Exceptions_details", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            DataRow dr = dt.NewRow();
            dr["Exception"] = exception;
            dr["Date"] = My.date();

            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);

        }

        public static DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = My.conn;
            SqlConnection con = new SqlConnection(strConnString);

            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;


        }
         public DataTable FillData(string query)
        {
            DataTable dtc = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(My.conn);
                if (conn.State == ConnectionState.Closed) { conn.Open(); }
                SqlDataAdapter adpc = new SqlDataAdapter(query, My.conn);
                adpc.Fill(dtc);
                if (conn.State == ConnectionState.Open) { conn.Close(); }

            }
            catch (Exception ex)
            {


            }
            return dtc;
        }
        #region
        public static string global_id_creation(string columnname)
        {
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Global_Master", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr[columnname] = 2;
                result = "1";
                dt.Rows.Add(dr);

            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[columnname].ToString() == "")
                    {
                        dr[columnname] = 2;
                        result = "1";
                    }
                    else
                    {
                        dr[columnname] = Convert.ToDouble(dr[columnname]) + 1;
                        result = dr[columnname].ToString();
                    }
                    break;
                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(ds.Tables[0]);
            return DateTime.Now.Year + result;
        }

        #endregion

        //--------------------------------create_reg_id--------------------------------------
        public static string create_reg_id(string column)
        {
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Globle_Master", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Globle_Master");
            DataTable dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Regid"] = 1;
                result = "1";
                dt.Rows.Add(dr);

            }
            else
            {
                result = dt.Rows[0][column].ToString();
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    if (dr["Regid"].ToString() == "")
                //    {
                //        dr["Regid"] = 1;
                //        result = "1";
                //    }
                //    else
                //    {
                //        dr["Regid"] = ;
                //        result = dr["Regid"].ToString();
                //    }
                //    break;
                //}
               int result2= Convert.ToInt32(result) + 1;
               My.executeQuery("Update Globle_Master  set " + column + " = " + result2 + " where Id='" + 1 + "'");
            }
             
            return    result;
        }

        public static string create_productid(string column)
        {
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Globle_Master", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Globle_Master");
            DataTable dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Regid"] = 1;
                result = "1";
                dt.Rows.Add(dr);

            }
            else
            {
                result = dt.Rows[0][column].ToString();
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    if (dr["Regid"].ToString() == "")
                //    {
                //        dr["Regid"] = 1;
                //        result = "1";
                //    }
                //    else
                //    {
                //        dr["Regid"] = ;
                //        result = dr["Regid"].ToString();
                //    }
                //    break;
                //}

                int result2 = Convert.ToInt32(result) + 1;
                My.executeQuery("Update Globle_Master  set " + column + " = " + result2 + " where Id='" + 1 + "'");
            }
            return "UEI" + result + My.idate() + My.itime();
        }
        //--------------------------------create_reg_id--------------------------------------
        public static string create_registration_id(string column)
        {
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Globle_Master", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Globle_Master");
            DataTable dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["reg_no"] = 1;
                result = "1";
                dt.Rows.Add(dr);

            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["reg_no"].ToString() == "")
                    {
                        dr["reg_no"] = 1;
                        result = "1";
                    }
                    else
                    {
                        dr["reg_no"] = Convert.ToDouble(dr["reg_no"]) + 1;
                        result = dr["reg_no"].ToString();
                    }
                    break;
                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(ds.Tables[0]);
            return "Zubaida" + DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd") + result;
        }


        public static string fetch_user_id(string emvalues)
        {
            string value = "";
            SqlDataAdapter ad = new SqlDataAdapter("Select user_id from Forum_user where mobile='" + emvalues + "' or email='" + emvalues + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount != 0)
            {
                value = dt.Rows[0]["user_id"].ToString();
            }
            return value;
        }
        public static bool check_emailid(string email)
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Select * from PackageBookingMaster where email='" + email + "'", My.conn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception exc)
            {
                My.submitException(exc);
                return false;
            }
        }
        public static bool check_mobile(string mobile)
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Select * from PackageBookingMaster where mobile='" + mobile + "'", My.conn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception exc)
            {
                My.submitException(exc);
                return false;
            }
        }
        public static bool check_emailid_user(string email)
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Select * from E_User_registration where Email_id='" + email + "'", My.conn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception exc)
            {
                My.submitException(exc);
                return false;
            }
        }
        public static bool check_mobile_user(string mobile)
        {
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("Select * from E_User_registration where Mobile_no='" + mobile + "'", My.conn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception exc)
            {
                My.submitException(exc);
                return false;
            }
        }
        #endregion

        #region creation of unique ids
        // Cart id
        public string cartid()
        {
            string code = "";
            bool duplicateid = false;
            Random rn = new Random();
            int i = 10000000;
            int j = 99999999;
            do
            {
                int k = rn.Next(i, j);
                code = k.ToString();
                duplicateid = check_duplicate(code);
                if (duplicateid == true)
                {
                }
            } while (duplicateid == false);
            return code;
        }
        private bool check_duplicate(string code)
        {
            SqlDataAdapter ad_reg = new SqlDataAdapter("select * from E_Cart_table where cart_id ='" + code + "'", conn);
            DataSet ds = new DataSet();
            ad_reg.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        //REgistration no
        public string fetch_registration_no()
        {
            string code = "";
            int i = 100000000;
            int j = 999999999;
            Random rd = new Random();
            string toreturn = "";
            bool db_duplicate = false;
            int k = 0;
            do
            {
                k = rd.Next(i, j);
                code = "CA" + k.ToString();
                db_duplicate = check_dauplicate_id(code);
                if (db_duplicate == true)
                {
                    toreturn = code;
                }
            }
            while (db_duplicate == false);
            return code;
        }

        private bool check_dauplicate_id(string code)
        {

            SqlDataAdapter ad_reg = new SqlDataAdapter("select * from E_OrderMaster where order_no ='" + code + "'", My.conn);
            DataSet ds = new DataSet();
            ad_reg.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        // product code
        public static string find_product_code()
        {
            string final_code = "";
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("yyyyMMddhhmmss");
            Random random = new Random();
            int tempo = random.Next(1000, 9999);
            final_code = date + tempo;
            return final_code;
        }

        // user code creation
        public string code_creation()
        {
            string code = "";
            bool duplicateid = false;
            Random rn = new Random();
            int i = 10000000;
            int j = 99999999;
            do
            {
                int k = rn.Next(i, j);
                code = k.ToString();
                duplicateid = check_duplicateusercode(code);
                if (duplicateid == true)
                {
                }
            } while (duplicateid == false);
            return code;
        }

        private bool check_duplicateusercode(string code)
        {
            SqlDataAdapter ad = new SqlDataAdapter("Select * from User_registration where Usercode ='" + code + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Node_demand_entry");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // create categoryid
        public string createcategoryID()
        {
            string category = "";
            SqlDataAdapter ad = new SqlDataAdapter("Select categoryid  from GlobalData", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                category = "101";
                executeQuery("UPDATE GlobalData SET categoryid='" + category + "'");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    category = dr["categoryid"].ToString();
                    executeQuery("UPDATE GlobalData SET categoryid='" + (Convert.ToDouble(dr["categoryid"].ToString()) + 1).ToString() + "'");
                }
            }
            return category;

        }
        public string create_sub_categoryID()
        {
            string subcategory = "";
            SqlDataAdapter ad = new SqlDataAdapter("Select subcategoryid  from GlobalData", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                subcategory = "1001";
                executeQuery("UPDATE GlobalData SET subcategoryid='" + subcategory + "'");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    subcategory = dr["subcategoryid"].ToString();
                    executeQuery("UPDATE GlobalData SET subcategoryid='" + (Convert.ToDouble(dr["subcategoryid"].ToString()) + 1).ToString() + "'");
                }
            }
            return subcategory;

        }
        #endregion

        #region OTP Message
        static HttpWebRequest request;
        static Stream dataStream;

        public static void send_message(string mobile, string message)
        {
            string str1 = "aae0dcd1c79d6dac557a494cf5481918";
            string str2 = "INTSPL";
            string str3 = "1";
            string text = mobile;
            string str4 = message;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + "mysms.msgclub.net" + "/rest/services/sendSMS/sendGroupSms?AUTH_KEY=" + str1 + "&message=" + str4 + "&senderId=" + str2 + "&routeId=" + str3 + "&mobileNos=" + text + "&smsContentType=unicode");
            try
            {
                new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).Close();
            }
            catch (Exception ex)
            {
            }
        }
        public static string find_otp()
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("yyyyMMddhhmmss");
            Random random = new Random();
            int tempo = random.Next(1000, 9999);
            return tempo.ToString();
        }

        #endregion

        #region Tourism
        public static string fetch_payment_mode(string orderno)
        {
            string mode = "";
            SqlDataAdapter ad = new SqlDataAdapter("select payment_type from E_payment_history where order_no='" + orderno + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                //
            }
            else
            {
                mode = dt.Rows[0][0].ToString();
            }
            return mode;
        }
        public static string find_pwd(string email)
        {
            string pwd = "";
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_User_registration where Email_id='" + email + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                // do nothing
            }
            else
            {
                pwd = dt.Rows[0][4].ToString();
            }
            return pwd;
        }
        public static bool duplicated_chck(string query)
        {
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static string modifylink(string link)
        {
            if (link.Contains("http://"))
            {
                link = link.Replace("http://", "");
                link = "http://" + link;
            }
            else
            {
                link = "http://" + link;

            }
            return link;

        }
        public static bool chk_amount_validate(string number)
        {
            try
            {
                double _num = Convert.ToDouble(number.Trim());
            }
            catch
            {
                return false;
            }
            return true;
        }
        public int my_rowcount(string query)
        {
            int count = 0;
            SqlConnection sqlCnn;
            SqlCommand sqlCmd;
            string sql = null;
            string sql1 = query;

            sql = sql1;
            sqlCnn = new SqlConnection(My.conn);
            try
            {
                sqlCnn.Open();
                sqlCmd = new SqlCommand(sql, sqlCnn);
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    count = Convert.ToInt32(sqlReader.GetValue(0).ToString());
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
            }
            catch (Exception ex)
            {


            }
            return count;
        }
        public static string VIEW_auto_serial(string column)
        {
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Globle_Master ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr[column] = "1";
                result = "1";
                dt.Rows.Add(dr);
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[column].ToString() == "")
                    {
                        result = "1";
                        dr[column] = "1";
                    }
                    else
                    {

                        result = dr[column].ToString();
                    }
                    break;
                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(ds.Tables[0]);
            return result;
        }
        public static string auto_serial(string column)
        {
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Globle_Master ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr[column] = "2";
                result = "1";
                dt.Rows.Add(dr);
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[column].ToString() == "")
                    {
                        result = "1";
                        dr[column] = "2";
                    }
                    else
                    {
                        result = dr[column].ToString();
                        dr[column] = Convert.ToDouble(dr[column]) + 1;
                    }
                    break;
                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(ds.Tables[0]);
            return result;
        }
        public static int fetch_idate(string date)
        {
            int Date = Convert.ToInt32(date.Substring(6, 4) + date.Substring(3, 2) + date.Substring(0, 2));
            return Date;
        }
        public static void exceptions(string from_test, string exceptions)
        {

            SqlDataAdapter ad = new SqlDataAdapter("Select * from ExceptionDetails ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Exceptions_details");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["exception_message"] = exceptions;
            dr["date"] = date();
            dr["time"] = time();
            dr["page"] = from_test;
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);

        }
        public static string fetch_tour_typeID(string type)
        {
            string vlaue = "0";
            SqlDataAdapter ad = new SqlDataAdapter("select CategoryId from category_details where category='" + type + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                vlaue = dt.Rows[0]["CategoryId"].ToString();
            }
            return vlaue;
        }
        public static string fetch_tour_typename(string type)
        {
            string vlaue = "";
            SqlDataAdapter ad = new SqlDataAdapter("select category from category_details where CategoryId='" + type + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                vlaue = dt.Rows[0]["category"].ToString();
            }
            return vlaue;
        }


        public static string find_subcategory_name(string subcategoryid)
        {
            string subcategoryname = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from E_SubcategoryMaster where sub_category_id='" + subcategoryid + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_SubcategoryMaster");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                //
            }
            else
            {
                subcategoryname = dt.Rows[0][1].ToString();
            }
            return subcategoryname;
        }

        public static string fetch_subcategory_name(string categoryid, string subcategoryid)
        {
            string subcategoryname = "";

            SqlDataAdapter ad = new SqlDataAdapter("select * from E_SubcategoryMaster where category_id='" + categoryid + "' and sub_category_id='" + subcategoryid + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_SubcategoryMaster");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                //
            }
            else
            {
                subcategoryname = dt.Rows[0][1].ToString();
            }
            return subcategoryname;
        }

        public static string getSubCategoryid(string category_id, string subcategoryname)
        {
            string subcatid = "";

            SqlDataAdapter ad = new SqlDataAdapter("Select sub_category_id from E_SubcategoryMaster where category_id='" + category_id + "' and sub_category_name='" + subcategoryname + "' ", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_SubcategoryMaster");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                subcatid = dt.Rows[0][0].ToString();
            }


            return subcatid;
        }

        public static string getSubCategoryid(string subcategory)
        {
            string subcatid = "";

            SqlDataAdapter ad = new SqlDataAdapter("Select sub_category_id from E_SubcategoryMaster where sub_category_name='" + subcategory + "' ", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_SubcategoryMaster");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                subcatid = dt.Rows[0][0].ToString();
            }


            return subcatid;
        }

        public static string get_SubCategory_name(string subcatid)
        {
            string name = "";
            SqlDataAdapter ad = new SqlDataAdapter("Select sub_category_name from E_SubcategoryMaster where sub_category_id = '" + subcatid + "'  ", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                name = dt.Rows[0]["sub_category_name"].ToString();
            }
            return name;
        }
        public static string get_Category_name(string categoryid)
        {
            string categoryname = "";

            SqlDataAdapter ad = new SqlDataAdapter("select * from E_CategoryMaster where category_id='" + categoryid + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount != 0)
            {
                categoryname = dt.Rows[0][1].ToString();
            }
            return categoryname;
        }
        #region category&subcategory

        public static string getCategoryid(string categoryname)
        {
            string catid = "";
            SqlDataAdapter ad = new SqlDataAdapter("Select category_id from E_CategoryMaster where category_name='" + categoryname + "' ", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                catid = dt.Rows[0][0].ToString();
            }

            return catid;
        }



        #endregion
        #endregion

        #region zipunzip
        public String Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return Convert.ToBase64String(mso.ToArray());
            }
        }
        public string Unzip(string str)
        {

            byte[] bytes = Convert.FromBase64String(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {                     //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
        #endregion


        public static string sendemail(string email, string subject, string message)
        {
            try
            {
                MailMessage Msg = new MailMessage();
                MailAddress fromMail = new MailAddress("noreply@talentkhojbih.com");
                // Sender e-mail address.
                Msg.From = fromMail;
                // Recipient e-mail address.
                // Msg.To.Add(email);
                Msg.To.Add(email);
                // Subject of e-mail
                Msg.Subject = subject;
                Msg.Body = message.ToString();
                Msg.IsBodyHtml = true;
                SmtpClient mailClient = new SmtpClient("relay-hosting.secureserver.net", 25);
                //SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 465);
                // SmtpClient mailClient = new SmtpClient("smtp25.elasticemail.com", 25);
                // Change your gmail user id and password for send email
                NetworkCredential NetCrd = new NetworkCredential("talentkhojenquiry@gmail.com", "Ints#07#@#$%");
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = NetCrd;
                mailClient.EnableSsl = false;
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.Send(Msg);
                return "Something issue";
            }
            catch (Exception ex)
            {

                My.submitexception(ex.ToString());
                return ex.ToString();
            }


        }

        public static void submitexception(string ex)
        {

            SqlDataAdapter ad = new SqlDataAdapter("select * from ExceptionDetails", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "ExceptionDetails");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            DataRow dr = dt.NewRow();
            dr["exception_message"] = ex;
            dr["date"] = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");

            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);
        }



        //************************************************-----------Message Sending-------------------**************************************
        public void send_sms(string name, string mobileno, string message, string code)
        {
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Message_config", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Message_config");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                string uid = dt.Rows[0][1].ToString();
                string sender = dt.Rows[0][2].ToString();
                string route = dt.Rows[0][3].ToString();
                string mobile = mobileno;
                string domain = dt.Rows[0][4].ToString();
                string pushid = "1";
                string message1 = Uri.EscapeDataString(message);
                string url = "http://" + domain + "/rest/services/sendSMS/sendGroupSms?AUTH_KEY=" + uid + "&message=" + message1 + "&senderId=" + sender + "&routeId=" + route + "&mobileNos=" + mobile + "&smsContentType=english";
                send_message_details_in_Message_send_details(mobile, message, "NOTSEND", url, code);
                send_sms(url, code);
            }
        }
        private void send_sms(string url, string code)
        {

            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());
                string result = sr.ReadToEnd();
                sr.Close();

                string query = "update Message_send_details set Status='SEND',resulturl='" + result + "' where Membercode='" + code + "'";
                update_messagesend(query);
            }
            catch (Exception ex)
            {

            }
        }

        private void update_messagesend(string query)
        {

            SqlDataAdapter ad6 = new SqlDataAdapter(query, My.conn);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_send_details");
        }

        private void send_message_details_in_Message_send_details(string mobile, string message, string status, string url, string code)
        {

            string date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            string idate = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd");
            string time = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hh:mm:ss tt");

            SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_send_details", My.conn);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_send_details");
            DataTable dt6 = ds6.Tables[0];
            DataRow dr6 = dt6.NewRow();
            dr6[1] = code;
            dr6[2] = mobile;
            dr6[3] = date;
            dr6[4] = message;
            dr6[5] = status;
            dr6[6] = time;
            dr6[7] = url.ToString();
            dr6[8] = "";
            dt6.Rows.Add(dr6);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad6);
            ad6.Update(dt6);
        }

        public static string check_amount(object p)
        {

            if (p.ToString() == "")
            {
                return "0.00";
            }
            else
            {
                return Convert.ToDouble(p).ToString("0.00");
            }
        }

        public void bind_all_ddl_only_value(DropDownList ddl, string query)
        {

            SqlConnection conn = new SqlConnection(My.conn);
            ArrayList al = new ArrayList();

            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "tests");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl.DataTextField = "Select";

            }

            else
            {
                ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
            }
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select"));
        }
        public static bool check_bilty_status(string query)
        {
            SqlDataAdapter ad_occupa = new SqlDataAdapter(query, My.conn);
            DataSet ds = new DataSet();
            ad_occupa.Fill(ds, "GlobalMaster");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static bool check_duplicate_data(string qry)
        {
            SqlDataAdapter ad = new SqlDataAdapter(qry, My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "temp");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static string find_total_booking_counting(string user_counter)
        {
            string toreturn = "";
            SqlDataAdapter ad = new SqlDataAdapter("select count(*) as 'Total Bilty' ,sum(cast(Freight as float)) as 'Freight',sum(cast(Packaging as float)) as 'Packaging',sum(cast(Weight as float)) as 'Weight' from Booking_entry where  Created_by='" + user_counter + "'  ", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "temp");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                toreturn = "";
            }
            else
            {
                toreturn = "Total Bilty- " + dt.Rows[0][0].ToString() + ",  Total Packaging - " + dt.Rows[0][2].ToString() + ",  Total Freight - " + dt.Rows[0][1].ToString() + ",  Total Weight - " + dt.Rows[0][3].ToString();
            }
            return toreturn;
        }
        internal static string find_total_booking_counting(string user_counter, string Challanno)
        {
            string toreturn = "";
            SqlDataAdapter ad = new SqlDataAdapter("select count(*) as 'Total Bilty' ,sum(cast(Freight as float)) as 'Freight',sum(cast(Packaging as float)) as 'Packaging',sum(cast(Weight as float)) as 'Weight' from Booking_entry where  Created_by='" + user_counter + "' and   Challan_no='" + Challanno + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "temp");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                toreturn = "";
            }
            else
            {
                toreturn = "Total Bilty- " + dt.Rows[0][0].ToString() + ",  Total Packaging - " + dt.Rows[0][2].ToString() + ",  Total Freight - " + dt.Rows[0][1].ToString() + ",  Total Weight - " + dt.Rows[0][3].ToString();
            }
            return toreturn;
        }
        internal static string find_total_booking_counting(string user_counter, int isdate, int iedate)
        {
            string toreturn = "";
            SqlDataAdapter ad = new SqlDataAdapter("select count(*) as 'Total Bilty' ,sum(cast(Freight as float)) as 'Freight',sum(cast(Packaging as float)) as 'Packaging',sum(cast(Weight as float)) as 'Weight' from Booking_entry where  Created_by='" + user_counter + "' and  Created_idate>='" + isdate + "' and Created_idate<='" + iedate + "'", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "temp");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                toreturn = "";
            }
            else
            {
                toreturn = "Total Bilty- " + dt.Rows[0][0].ToString() + ",  Total Packaging - " + dt.Rows[0][2].ToString() + ",  Total Freight - " + dt.Rows[0][1].ToString() + ",  Total Weight - " + dt.Rows[0][3].ToString();
            }
            return toreturn;
        }


        internal static void submitException(string p)
        {
            throw new NotImplementedException();
        }

        public void bind_year(DropDownList ddl)
        {
            ArrayList ar = new ArrayList();

            ar.Add("Select");
            for (int i = 2000; i <= 2018; i++)
            {
                ar.Add(i);
            }
            ddl.DataSource = ar;
            ddl.DataBind();
        }


        public static SqlConnection con { get; set; }


        public string registration_code()
        {
            //string final_code = "";
            //DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            //string date = dtm.ToString("yyyyMMdd");
            //Random random = new Random();
            //int tempo = random.Next(100, 999);

            //final_code = date + tempo;
            //return final_code;
            string result = "";
            SqlDataAdapter ad = new SqlDataAdapter("select * from Globle_Master", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Globle_Master");
            DataTable dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["reg_no"] = 1;
                result = "1";
                dt.Rows.Add(dr);

            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["reg_no"].ToString() == "")
                    {
                        dr["reg_no"] = 1;
                        result = "1";
                    }
                    else
                    {
                        dr["reg_no"] = Convert.ToDouble(dr["reg_no"]) + 1;
                        result = dr["reg_no"].ToString();
                    }
                    break;
                }
            }
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(ds.Tables[0]);
            return "college" + DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("yyyyMMdd") + DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("hhmmss") + result;

        }

        internal static void submit_exception(string p)
        {
            throw new NotImplementedException();
        }

    }

}