using System;
using System.Data;
using WingtipToys.Logic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WingtipToys.Models;


namespace WingtipToys.Training
{
    public partial class MyStaffsTraining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(Context.User.Identity.GetUserId());
            var currentUserUID = currentUser.UniversityID;

            LoadWorkSafeTrainDoneData(currentUserUID);
            //result_msg.Style.Add("display", "none");
        }

        private void LoadWorkSafeTrainDoneData(string ids)
        {
            TrainingRecord ts = new TrainingRecord();
            DataSet ds = new DataSet();
            string sError = "";
            bool result1 = false;

            try
            {
                result1 = ts.getLabPersonnelTrainingByManagerID(ids, ref ds, ref sError);

                if (result1 == true & string.IsNullOrEmpty(sError))
                {
                    trainingListGrid.DataSource = ds.Tables[0];
                    trainingListGrid.DataBind();
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

    } // End of public partial class MyTraining : System.Web.UI.Page
} // End of namespace WingtipToys.Training