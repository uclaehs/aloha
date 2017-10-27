using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WingtipToys.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WingtipToys.Logic;

namespace WingtipToys.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //var currentUser = manager.FindById(Context.User.Identity.GetUserId());
            //FName.Text = currentUser.FirstName;
            //LName.Text = currentUser.LastName;
        }

        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ////var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            ////var manager = new UserManager<ApplicationUser>(store);
            //var currentUser = manager.FindById(Context.User.Identity.GetUserId());

            //currentUser.FirstName = "ken15556689";
            //currentUser.LastName = LName.Text;

            //manager.UpdateAsync(currentUser);
        }

        public ApplicationUser userProfileGrid_GetDataByID()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(Context.User.Identity.GetUserId());
            return currentUser;

            //return db.ApplicationUser.FirstOrDefault(t => t.Id == Context.User.Identity.GetUserId()); ;
        }

        // The studentID parameter name should match the DataKeyNames value set on the control
        public void userProfileGrid_UpdateItem()
        {

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(Context.User.Identity.GetUserId());
            
            TryUpdateModel(currentUser);
            if (ModelState.IsValid)
            {
                manager.Update(currentUser);
            }
        }

    } // End of public partial class Profile : System.Web.UI.Page
} // End of namespace WingtipToys.Accoun