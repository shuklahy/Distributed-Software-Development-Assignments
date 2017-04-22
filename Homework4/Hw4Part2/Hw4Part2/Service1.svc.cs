using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace Hw4Part2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static string error = "";
        private static void validate(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                error += " Warning" + e.Message;
            else // Error
                error += " Error message" + e.Message;
        }

        result IService1.verification(string xmlPath, string xsdPath)
        {
            result output = new result();
            output.status = "No Error";
            output.errorMsg = "";
            output.value = "";

            error = "";
            try
            {
                easyValidate(xmlPath, xsdPath);
            }
            catch (Exception err)
            {
                error += err.Message;
            }

            if (!error.Equals(""))
            {
                output.status = "Error";
                output.errorMsg = error;
            }

            return output;
        }


        
        result IService1.XPathSearch(string xmlPath, string expression)
        {
            result output = new result();
            output.status = "No Error";
            output.errorMsg = "";
            output.value = "";

            XPathDocument dx = new XPathDocument(xmlPath);
            XPathNavigator nav = dx.CreateNavigator();

            
            XPathNodeIterator iterator = nav.Select(expression);
            while (iterator.MoveNext())
            {
                output.value += iterator.Current.Value + "\n";
            }
            return output;
        }


        /*
         * Helper Functions
         */


        public static void easyValidate(string xmlPath, string xsdPath)
        {
            
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, xsdPath);
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.IgnoreWhitespace = true;

                XmlReader xmldoc = XmlReader.Create(xmlPath, settings);
                XmlDocument document = new XmlDocument();
                document.Load(xmldoc);

                ValidationEventHandler eventHandler = new ValidationEventHandler(validate);

                // the following call to Validate succeeds.
                document.Validate(eventHandler);
                
            }
            
        }
        
        
    }

