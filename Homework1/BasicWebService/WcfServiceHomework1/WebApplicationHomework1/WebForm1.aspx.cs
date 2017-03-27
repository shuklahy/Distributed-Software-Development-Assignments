using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplicationHomework1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoginDetailsService.Service1Client loginService = new LoginDetailsService.Service1Client();
            String fname, lname;
            int age;
            try
            {
                fname = TextBox1.Text;
                lname = TextBox2.Text;
                age = int.Parse(TextBox3.Text);

                Regex r = new Regex(@"^[a-zA-Z]+$");

                if (!r.IsMatch(fname))
                    throw new System.Exception("First Name should contain only string");

                if (!r.IsMatch(lname))
                    throw new System.Exception("Last Name should conatain only string");

                if (fname.Length < 2)
                    throw new System.Exception("First Name > 2");


                if (lname.Length < 2)
                    throw new System.Exception("Last Name > 2");

                if (age <= 0)
                    throw new System.Exception("age should be > 0");

                String pass = loginService.password(fname, lname, age);
                int loginId = loginService.loginId(age);

                Label5.Text = "" + loginId;
                Label7.Text = pass;
            }
            catch (Exception exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exception.Message + "');", true);
            }
            finally
            {
                loginService.Close();
            }
            

            
        }
    }
}