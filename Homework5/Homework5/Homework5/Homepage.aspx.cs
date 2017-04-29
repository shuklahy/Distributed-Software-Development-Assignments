using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework5
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("/Login.aspx");
            if(Session["uname"] == null)
            {
                Button1.Text = "Login";
                Label1.Text = "[Guest]";
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            else
            {
                Button1.Text = "Logout";
                string label = Session["uname"].ToString();
                Label1.Text = label;

                if (Cache["cacheProfile"] == null)
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    //Cache.Insert("cacheProfile", d);
                    //string p = File.ReadAllText(Server.MapPath("cacheData.txt"));
                }
                else
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    //Cache.Insert("cacheProfile", d, new CacheDependency(Server.MapPath("cacheData.txt")));
                }
                //b = Cache["cacheProfile"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Button1.Text == "Login")
            {
                Response.Redirect("Login.aspx");

            }else if(Button1.Text == "Logout")
            {
                Session["uname"] = null;
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Console.WriteLine("Don't know what state the Button is in currently.");
            }
        }

        private locationObject processJsonJavaScriptSerializer(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            locationObject latLonDetails = js.Deserialize<locationObject>(json);
            return latLonDetails;
        }

        public class locationObject
        {


            public double latitude { get; set; }
            public double longitude { get; set; }
            public string placeId { get; set; }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            locationObject result = new locationObject();

            String lat, lon;
            try
            {
                string url = @"http://localhost:57770/Service1.svc/GetLatLon/address=" + TextBox1.Text;

                Console.WriteLine(url);



                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                String json = reader.ReadToEnd();

                result = processJsonJavaScriptSerializer(json);

                lat = result.latitude.ToString();
                lon = result.longitude.ToString();

                Label4.Text = lat;
                Label5.Text = lon;

                loadcache(result);

                Panel2.Visible = true;
                Label3.Text = "Lat:" + lat + " ,Lon:" + lon;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            finally
            {

            }
        }

        public void loadcache(locationObject locObject)
        {
            if (Cache["locObject"] == null)
            {
                Cache.Insert("locObject", locObject,null,DateTime.UtcNow.AddSeconds(10.00), System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String lat = "";
            String lon = "";

            Panel2.Visible = true;
            locationObject locObject;
            if (Cache["locObject"] == null)
            {
                lat = "";
                lon = "";
            }
            else
            {
                locObject = Cache["locObject"] as locationObject;
                lat = locObject.latitude.ToString();
                lon = locObject.longitude.ToString();
            }
                if (lat == "" && lon == "")
            {
                Label3.Text = "Cache Expired";
            }
            else
            {
                Label3.Text = "Lat:" + lat + " ,Lon:" + lon;
            }
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            locationObject locObject = Cache["locObject"] as locationObject;
            if(locObject == null)
            {
                //Cache is invalid now make panel invisible
                Panel2.Visible = true;
                Panel3.Visible = false;
            }
            else
            {

                Panel2.Visible = true;
                Panel3.Visible = true;
                // Cache is valid 
                // Get All city Info

                Double lat = locObject.latitude;
                Double lon = locObject.longitude;

                String solarbaseurl = "http://localhost:52501/Service1.svc/";
                string solarurl = @solarbaseurl + "SolarIntensity?lat=" + lat + "&lon =" + lon;

                String windbaseurl = "http://localhost:49872/Service1.svc/";
                string windurl = @windbaseurl + "WindIntensity?lat=" + lat + "&lon =" + lon;

                String mapbaseurl = "http://localhost:62235/Service1.svc";
                string mapurl = @mapbaseurl + "/getMapURL?lat=" + lat + "&lon=" + lon;

                String gasbaseurl = "http://localhost:61564/Service1.svc";
                string gasurl = @gasbaseurl + "/getGasStation?lat=" + lat + "&lon=" + lon;


                try
                {
                    string solarjson = getJsonString(solarurl);
                    string windjson  = getJsonString(windurl);
                    string mapjson   = getJsonString(mapurl);
                    string gasjson   = getJsonString(gasurl);

                    wsresult solarws = processJsonWS(solarjson);
                    wsresult windws = processJsonWS(windjson);
                    imgresult imgrs = processJsonImg(mapjson);
                    gasresult[] gasoutput = processJsonGas(gasjson);
                    ListView1.DataSource = gasoutput;
                    ListView1.DataBind();


                    if (solarws.status.Equals("Invalid Input"))
                    {
                        Label7.Text = "Invalid Input";
                    }
                    else
                    {
                        Label7.Text = solarws.avgIntensity.ToString();
                    }


                    if (windws.status.Equals("Invalid Input"))
                    {
                        Label6.Text = "Invalid Input";
                    }
                    else
                    {
                        Label6.Text = windws.avgIntensity.ToString();
                    }

                    Image1.ImageUrl = imgrs.url;


                }
                catch(Exception err)
                {
                    Console.WriteLine(err);
                }
            }
        }

        public string getJsonString(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            return reader.ReadToEnd();
        }


        [Serializable]
        public class wsresult
        {
            public decimal avgIntensity { get; set; }
            public String status { get; set; }

        }


        [Serializable]
        public class imgresult
        {

            public String url { get; set; }
            public String status { get; set; }

        }

        static wsresult processJsonWS(String data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            wsresult r = js.Deserialize<wsresult>(data);
            return r;
        }

        static imgresult processJsonImg(String data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            imgresult r = js.Deserialize<imgresult>(data);
            return r;
        }

        static gasresult[] processJsonGas(String data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            gasresult[] r = js.Deserialize<gasresult[]>(data);
            return r;
        }

        [Serializable]
        public class gasresult
        {
            public String name { get; set; }
            public String openNow { get; set; }
            public String address { get; set; }
        }
    }
       
    
}