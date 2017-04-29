using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework5
{
    public partial class Login : System.Web.UI.Page
    {
        static Dictionary<string, string> dict = new Dictionary<string, string>() {
            {"Hitendra", "Hit1234" },
            {"Santosh", "San1234" },
            { "Ayush", "Ayu1234"},
            {"Kushal","Kus1234" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName;
            string password = Login1.Password;
            String pass;

            if (dict.TryGetValue(username, out pass))
            {
                if (pass.Equals(password))
                {
                    Session["uname"] = username;
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    Login1.FailureText = "Invalid Password";
                }
            }
            else
            {
                Login1.FailureText = "Invalid Username. No such User Exists in System";
            }
            
        }
    }
}