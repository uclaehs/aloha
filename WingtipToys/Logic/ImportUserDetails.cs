using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WingtipToys.Logic
{
    public class ImportUserDetails
    {
        public bool GetUserDetailByUID(string uid, ref DataSet ds, ref string sERROR)
        {
            try
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
         
                con.Open();
                cmd.Connection = con;

                //cmd.CommandText = " select Learner_Id, NameReverse, Course_Id, Title, CASE MAX(Status_Date) WHEN '1900-01-01 00:00:00' THEN NULL ELSE MAX(Status_Date) END AS Status_Date, CASE MAX(Date_Expires) WHEN '1900-01-01 00:00:00' THEN NULL ELSE MAX(Date_Expires) END AS Date_Expires from vw_MHistory where  Learner_Id in ('" + pkeys + "') and Status='f' and ( Category in ('BIO','LAB','LAS','RAD') or Course_Id in ('FIRE-FEX', 'ENV-FULL','ENV-HALF','ENV-N95') ) group by Learner_Id, NameReverse, Course_Id, Title order by NameReverse, Title ";
                cmd.CommandText = " select First_Name, Last_Name, ManagerID from vw_Learner where Learner_Id = @p_uid ; ";
                cmd.Parameters.AddWithValue("@p_uid", uid);

                da.SelectCommand = cmd;
                da.Fill(ds);

                con.Close();
                da.Dispose();
                cmd.Dispose();
                da = null;
                cmd = null;
                con = null;
                return true;
            }
            catch (Exception ex)
            {
                sERROR = ex.Message;
                return false;
            }
        }

        public bool GetUserDetailByEmail(string email, ref DataSet ds, ref string sERROR)
        {
            try
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();

                con.Open();
                cmd.Connection = con;

                //cmd.CommandText = " select Learner_Id, NameReverse, Course_Id, Title, CASE MAX(Status_Date) WHEN '1900-01-01 00:00:00' THEN NULL ELSE MAX(Status_Date) END AS Status_Date, CASE MAX(Date_Expires) WHEN '1900-01-01 00:00:00' THEN NULL ELSE MAX(Date_Expires) END AS Date_Expires from vw_MHistory where  Learner_Id in ('" + pkeys + "') and Status='f' and ( Category in ('BIO','LAB','LAS','RAD') or Course_Id in ('FIRE-FEX', 'ENV-FULL','ENV-HALF','ENV-N95') ) group by Learner_Id, NameReverse, Course_Id, Title order by NameReverse, Title ";
                cmd.CommandText = " select First_Name, Last_Name, ManagerID from vw_Learner where Email = @p_email ; ";
                cmd.Parameters.AddWithValue("@p_email", email);

                da.SelectCommand = cmd;
                da.Fill(ds);

                con.Close();
                da.Dispose();
                cmd.Dispose();
                da = null;
                cmd = null;
                con = null;
                return true;
            }
            catch (Exception ex)
            {
                sERROR = ex.Message;
                return false;
            }
        }

        public bool UpdateUserDetailByID(string id, string fname, string lname, string mid, ref string sERROR)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                con.Open();
                cmd.Connection = con;

                cmd.CommandText = " Update AspNetUsers set FirstName = @FirstName, LastName = @LastName, ManagerID =@ManagerID where Id =  @id; ";

                cmd.Parameters.AddWithValue("@FirstName", fname);
                cmd.Parameters.AddWithValue("@LastName", lname);
                cmd.Parameters.AddWithValue("@ManagerID", mid);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                con.Close();
                
                da.Dispose();
                cmd.Dispose();
                da = null;
                cmd = null;
                con = null;
                return true;
            }
            catch (Exception ex)
            {
                sERROR = ex.Message;
                return false;
            }
        }

        public bool UpdateUserUIDByUserName(string id, ref string sERROR)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                con.Open();
                cmd.Connection = con;

                cmd.CommandText = " update AspNetUsers set UniversityID = UserName where Id =  @id; ";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                con.Close();

                da.Dispose();
                cmd.Dispose();
                da = null;
                cmd = null;
                con = null;
                return true;
            }
            catch (Exception ex)
            {
                sERROR = ex.Message;
                return false;
            }
        }


    } // End of public class ImportUserDetails
} // End of namespace WingtipToys.Logic