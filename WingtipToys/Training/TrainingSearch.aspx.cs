using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WingtipToys.Logic;

namespace WingtipToys.Training
{
    public partial class TrainingSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //result_msg.Text = "ID List =>";
            //result_msg.Text = idUID.Text;
        }

        protected void btnTrainingSearch_Click(object sender, ImageClickEventArgs e)
        {
            //result_msg.Text = idUID.Text;

            string UIDList = null;
            UIDList = idUID.Text;
            string[] UIDArray = UIDList.Split(new char[] { ',' });
            string UIDArrayFormat = string.Join("','", UIDArray);

            result_msg.Text = "ID List =>" + UIDList;
            result_msg.CssClass = "success";
            result_msg.Style.Add("display", "block");

            LoadWorkSafeTrainDoneData(UIDArrayFormat);
        }

        private void LoadWorkSafeTrainDoneData(string ids)
        {
            //DAL dal = new DAL();
            TrainingRecord ts = new TrainingRecord();
            DataSet ds = new DataSet();
            string sError = "";
            bool result1 = false;
            //bool result2 = false;
            //bool result3 = false;

            try
            {
                result1 = ts.  getLabPersonnelTraining(ids, ref ds, ref sError);

                if (result1 == true & string.IsNullOrEmpty(sError))
                {
                    workerListGrid.DataSource = ds.Tables[0];
                    workerListGrid.DataBind();

                    result_msg.Text = "Loading successfully =>" + "id:" + ids;
                    result_msg.CssClass = "success";
                }
                else
                {
                    result_msg.Text = "Sorry! An error has occurred and the site administrator has been notified." + ds.ToString();
                    result_msg.CssClass = "error";
                }

                //result_msg.Style.Add("display", "block")

            }
            catch (Exception ex)
            {
            }
            ds.Dispose();
            ds = null;
            ts = null;
        }

    }

}