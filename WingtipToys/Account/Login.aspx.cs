using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WingtipToys.Models;

namespace WingtipToys.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";

            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }
        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                var userName = Email.Text;
                var user = manager.FindByName(userName);

                if (Email.Text.Contains("@"))
                {
                    using (var context = new ApplicationDbContext())
                    {
                        user = context.Users.SingleOrDefault(p => p.Email == Email.Text);
                        if (user != null)
                        {
                            userName = user.UserName;
                        }
                    }
                }

                if (user == null)
                {
                    FailureText.Text = "Invalid login attempt: User can not be found!";
                    ErrorMessage.Visible = true;
                }
                else if (!user.EmailConfirmed)
                {
                    FailureText.Text = "Invalid login attempt. You must have a confirmed email account.";
                    ErrorMessage.Visible = true;
                    ResendConfirm.Visible = true;
                }
                else
                {
                    //// This doen't count login failures towards account lockout
                    //// To enable password failures to trigger lockout, change to shouldLockout: true
                    var result = signinManager.PasswordSignIn(userName, Password.Text, RememberMe.Checked, shouldLockout: false);

                    switch (result)
                    {
                        case SignInStatus.Success:
                            WingtipToys.Logic.ShoppingCartActions usersShoppingCart = new WingtipToys.Logic.ShoppingCartActions();
                            String cartId = usersShoppingCart.GetCartId();
                            usersShoppingCart.MigrateCart(cartId, userName);

                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                            break;
                        case SignInStatus.LockedOut:
                            Response.Redirect("/Account/Lockout");
                            break;
                        case SignInStatus.RequiresVerification:
                            Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                            Request.QueryString["ReturnUrl"],
                                                            RememberMe.Checked),
                                              true);
                            break;
                        case SignInStatus.Failure:
                        default:
                            FailureText.Text = "Invalid login attempt";
                            ErrorMessage.Visible = true;
                            break;
                    } // End of switch (result)

                } // End of Else

            }  // End of if (IsValid)
        }  // End of protected void LogIn(object sender, EventArgs e)

        protected void SendEmailConfirmationToken(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var user = manager.FindByName(Email.Text);

            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.SingleOrDefault(p => p.Email == Email.Text);

                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        string code = manager.GenerateEmailConfirmationToken(user.Id);
                        string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                        manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                        FailureText.Text = "Confirmation email sent. Please view the email and confirm your account.";
                        ErrorMessage.Visible = true;
                        ResendConfirm.Visible = false;
                    }
                }
            }
        }

    } // End of public partial class Login : Page
} // End of namespace WingtipToys.Account