using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplicationHomework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            LoginGeneratorService.Service1Client loginService = new LoginGeneratorService.Service1Client();
            String fname, lname;
            int age;

            try
            {
                fname = textBox1.Text;
                lname = textBox2.Text;
                age = int.Parse(textBox3.Text);

                Regex r = new Regex(@"^[a-zA-Z]+$");

               if(!r.IsMatch(fname))
                    throw new System.Exception("First Name should contain only string");

                if (!r.IsMatch(lname))
                    throw new System.Exception("Last Name should conatain only string");

                if(fname.Length < 2)
                    throw new System.Exception("First Name > 2");


                if (lname.Length < 2)
                    throw new System.Exception("Last Name > 2");

                if(age <= 0)
                    throw new System.Exception("age should be > 0");

                String pass = loginService.password(fname, lname, age);
                int loginId = loginService.loginId(age);

                label5.Text = "" + loginId;
                label7.Text = pass;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                loginService.Close();
            }
            
        }

      
    }
}
