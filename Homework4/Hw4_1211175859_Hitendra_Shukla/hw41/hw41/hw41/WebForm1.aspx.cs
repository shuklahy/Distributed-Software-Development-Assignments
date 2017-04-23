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
        String outStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
         

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string file = TextBox3.Text;
            doc.Load(file);
            XmlNode root = doc.DocumentElement;

            outStr = "NType\tNName\n";
            displayNode(root);


            // Set show all the elements
            TextBox4.Text = outStr;
            

        }

        // This is preorder traversal of xml file
        private int displayNode(XmlNode root)
        {
            if(root == null)
            {
                return 0;
            }
            //print node data
            outStr += "" + root.NodeType;
            outStr+= "\t" + root.Name ;
            outStr += "\t" + root.Value;
            if(root.Attributes != null)
            {
                XmlAttributeCollection attrcollection = root.Attributes;
                foreach(XmlAttribute attribute in attrcollection)
                {
                    outStr += "\t AttrName: " + attribute.Name;
                    outStr += "\tAttrValue: " + attribute.Value;
                }
            }

            outStr += "\n";
            //print node data somewhere

            if (root.HasChildNodes)
            {
                XmlNodeList children = root.ChildNodes;
                foreach (XmlNode child in children)
                {
                    displayNode(child);
                }
            }

            //Code never reaches here but to avoid warning I am writing this
            return 0;
        }
    }
}