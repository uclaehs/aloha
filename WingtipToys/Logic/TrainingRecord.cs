using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WingtipToys.Logic
{
    public class TrainingRecord
    {
        public bool getLabPersonnelTraining(string pkeys, ref DataSet ds, ref string sERROR)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

                con.Open();
                cmd.Connection = con;

                cmd.CommandText = " select Learner_Id, NameReverse, Course_Id, Title, CASE MAX(Status_Date) WHEN '1900-01-01 00:00:00' THEN NULL ELSE MAX(Status_Date) END AS Status_Date, CASE MAX(Date_Expires) WHEN '1900-01-01 00:00:00' THEN NULL ELSE MAX(Date_Expires) END AS Date_Expires from vw_MHistory where Learner_Id in ('" + pkeys + "') and Status='f' group by Learner_Id, NameReverse, Course_Id, Title order by NameReverse, Title "; // and ( Category in ('BIO','LAB','LAS','RAD') or Course_Id in ('FIRE-FEX', 'ENV-FULL','ENV-HALF','ENV-N95') ) group by Learner_Id, NameReverse, Course_Id, Title order by NameReverse, Title ";

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
        }  // End of public bool getLabPersonnelTraining(string pkeys, ref DataSet ds, ref string sERROR)

        public bool getLabPersonnelTrainingByManagerID(string pkeys, ref DataSet ds, ref string sERROR)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

                con.Open();
                cmd.Connection = con;

                cmd.CommandText = " select Learner_Id, NameReverse, Course_Id, Title, CASE MAX(Status_Date) WHEN '1900-01-01 00:00:00' THEN NULL ELSE MAX(Status_Date) END AS Status_Date, CASE MAX(Date_Expires) WHEN '1900-01-01 00:00:00' THEN NULL ELSE MAX(Date_Expires) END AS Date_Expires from vw_MHistory where ManagerID in ('" + pkeys + "') and Status='f' group by Learner_Id, NameReverse, Course_Id, Title order by NameReverse, Title ";

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
        }  // End of public bool getLabPersonnelTraining(string pkeys, ref DataSet ds, ref string sERROR)

    } // End of public class TrainingRecord
} // End of namespace WingtipToys.Logic