using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

namespace hw41
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public XmlDocument doc = new XmlDocument();
        public XmlNode node;
        protected void Page_Load(object sender, EventArgs e)
        {
         

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string file = TextBox3.Text;
            doc.Load(file);
            node = doc.DocumentElement;
            TextBox1.Text = node.NodeType.ToString();
            TextBox2.Text = Convert.ToString(node.Name);

        }
    }
}