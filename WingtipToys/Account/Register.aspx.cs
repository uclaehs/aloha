using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WingtipToys.Models;
using System.Data;
using WingtipToys.Logic;


namespace WingtipToys.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new ApplicationUser() { UserName = UID.Text, Email = Email.Text, UniversityID = UID.Text };
            IdentityResult result = manager.Create(user, Password.Text);
   
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                string code = manager.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                manager.SendEmail(user.Id, "Confirm your UCLA EH&S account", "Please confirm your UCLA EH&S account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                LoadUserData(UID.Text, Email.Text, user.Id);

                ////IdentityHelper.SignIn(manager, user, isPersistent: false);

                using (WingtipToys.Logic.ShoppingCartActions usersShoppingCart = new WingtipToys.Logic.ShoppingCartActions())
                {
                    String cartId = usersShoppingCart.GetCartId();
                    usersShoppingCart.MigrateCart(cartId, user.Id);
                }
                //Response.Redirect("~/Account/Login");

                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private void LoadUserData(string uid, string email, string id)
        {
            //DAL dal = new DAL();
            ImportUserDetails iud = new ImportUserDetails();
            DataSet ds = new DataSet();
            string sError = "";
            bool result = false;
            bool result1 = false;

            try
            {
                result = iud.GetUserDetailByUID(uid, ref ds, ref sError);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    result = iud.GetUserDetailByEmail(email, ref ds, ref sError);
                    
                    //result_msg.Text = "No user reocrd found for =>" + "id:" + UID.Text;
                    //result_msg.CssClass = "success";
                    //result_msg.Style.Add("display", "block");
                }

                if (result == true & string.IsNullOrEmpty(sError))
                {
                    //workerListGrid.DataSource = ds.Tables[0];
                    //workerListGrid.DataBind();
                    object fName = ds.Tables[0].Rows[0]["First_Name"];
                    object lfName = ds.Tables[0].Rows[0]["Last_Name"];
                    object mID = ds.Tables[0].Rows[0]["ManagerID"];

                    result1 = iud.UpdateUserDetailByID(id, fName.ToString(), lfName.ToString(), mID.ToString(), ref sError);

                    if (result1 == true & string.IsNullOrEmpty(sError))
                    {
                        result_msg.Text = "Welcome, " + fName.ToString() + " " + lfName.ToString() + ", please login to your email account, click on the confirmation link to confirm your email account.";
                        result_msg.CssClass = "success";
                        result_msg.Style.Add("display", "block");
                    }
                    else
                    {
                        result_msg.Text = "Sorry! An error has occurred and the site administrator has been notified." + ds.ToString();
                        result_msg.CssClass = "error";
                    }
                }
                else
                {
                    result_msg.Text = "Sorry! An error has occurred and the site administrator has been notified." + ds.ToString();
                    result_msg.CssClass = "error";
                }
            }
            catch (Exception ex)
            {}
            ds.Dispose();
            ds = null;
            iud = null;
        }

    }
}