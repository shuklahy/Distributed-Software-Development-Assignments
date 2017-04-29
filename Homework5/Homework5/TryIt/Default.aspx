<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <style type="text/css">
@import "http://fonts.googleapis.com/css?family=Montserrat:300,400,700";
.rwd-table {
  margin: 1em 0;
  min-width: 300px;
}
.rwd-table tr {
  border-top: 1px solid #ddd;
  border-bottom: 1px solid #ddd;
}
.rwd-table th {
  display: none;
}
.rwd-table td {
  display: block;
}
.rwd-table td:first-child {
  padding-top: .5em;
}
.rwd-table td:last-child {
  padding-bottom: .5em;
}
.rwd-table td:before {
  content: attr(data-th) ": ";
  font-weight: bold;
  width: 6.5em;
  display: inline-block;
}
@media (min-width: 480px) {
  .rwd-table td:before {
    display: none;
  }
}
.rwd-table th, .rwd-table td {
  text-align: left;
}
@media (min-width: 480px) {
  .rwd-table th, .rwd-table td {
    display: table-cell;
    padding: .25em .5em;
  }
  .rwd-table th:first-child, .rwd-table td:first-child {
    padding-left: 0;
  }
  .rwd-table th:last-child, .rwd-table td:last-child {
    padding-right: 0;
  }
}

body {
  padding: 0 2em;
  font-family: Montserrat, sans-serif;
  -webkit-font-smoothing: antialiased;
  text-rendering: optimizeLegibility;
  color: white;
  background: white;
}

h1 {
  font-weight: normal;
  letter-spacing: -1px;
  color: #34495E;
}

.rwd-table {
  background: gray;
  color: #fff;
  border-radius: .4em;
  overflow: hidden;
}
.rwd-table tr {
  border-color: #46637f;
}
.rwd-table th, .rwd-table td {
  margin: .5em 1em;
}
@media (min-width: 480px) {
  .rwd-table th, .rwd-table td {
    padding: 1em !important;
  }
}
.rwd-table th, .rwd-table td:before {
  color: #dd5;
}
    </style>
</head>
<body>
    <center><h1>City Guide</h1></center>
    <br />
    <br />
    <br />
    <table class="rwd-table">
        <tr>
            <th>Service Name</th>
            <th>TryIt Link</th>
            <th>Service Description</th>
            <th>Resources Used</th>
        </tr>
        <tr>
            <td><b>Find the Nearest Store.</b></td>
            <td><a href="http://10.1.22.105:8018/WebForm1.aspx">http://10.1.22.105:8018/WebForm1.aspx</a></td>
            <td>Provides storeName closest to the zip code and returns the address. </td>
            <td>Retrieved information from the service at <a href="https://developers.google.com/places">https://developers.google.com/places</a></td>
        </tr>
        <tr>
            <td><b>Weather Description</b></td>
            <td><a href="http://10.1.22.105:8019/WebFormWeather.aspx">http://10.1.22.105:8019/WebFormWeather.aspx</a></td>
            <td>Provides a 5 Day weather forecast of the zip code.</td>
            <td>Retrieved information from the service at <a href="https://openweathermap.org/api">https://openweathermap.org/api</a></td>
        </tr>
        <tr>
            <td><b>Latitude/Longitude Provider</b></td>
            <td><a href="http://10.1.22.105:8020/WebFormZipCode.aspx">http://10.1.22.105:8020/WebFormZipCode.aspx</a></td>
            <td>Provides Latitude and Longitude details of a particular zipcode.</td>
            <td>Retrieved information from the service at <a href="https://developers.google.com/places/">https://developers.google.com/places</a></td>
        </tr>
        <tr>
            <td>
                <b>Find Nearest Restaurant</b></td>
            <td><a href="http://10.1.22.105:8017/WebFormRestaurant.aspx">http://10.1.22.105:8017/WebFormRestaurant.aspx</a></td>
            <td>Provides details of nearby restaurants in the area.</td>
            <td>Retrieved information from the service at <a href="https://www.yelp.com/developers">https://www.yelp.com/developers</a></td>
        </tr>
        <tr>
            <td>
                <b>Wind Energy Service</b>
            </td>
            <td><a href="http://10.1.22.105:80/WindService_TryIt.aspx">http://10.1.22.105:80/WindService_TryIt.aspx</a></td>
            <td>Provides the annual average wind index of a given position.</td>
            <td>Retrieved information from the file at <a href="https://eosweb.larc.nasa.gov/cgi-bin/sse/global.cgi?email=skip@larc.nasa.gov">https://eosweb.larc.nasa.gov/cgi-bin/sse/global.cgi?email=skip@larc.nasa.gov</a></td>
        </tr>
        <tr>
            <td>
                <b>Solar Energy Service</b>
            </td>
            <td><a href="http://10.1.22.105:80/SolarService_TryIt.aspx">http://10.1.22.105:80/SolarService_TryIt.aspx</a></td>
            <td>Provides the annual average sunshine index of a given position. </td>
            <td>Retrieved information from the file at <a href="https://eosweb.larc.nasa.gov/cgi-bin/sse/global.cgi?email=skip@larc.nasa.gov">https://eosweb.larc.nasa.gov/cgi-bin/sse/global.cgi?email=skip@larc.nasa.gov</a></td>
        </tr>
        <tr>
            <td>
                <b>Find Nearest Gas Stations</b>
            </td>
            <td><a href="http://10.1.22.105:80/GasStationService_TryIt.aspx">http://10.1.22.105:80/GasStationService_TryIt.aspx</a></td>
            <td>Provides gas stations closest to the location based on latitude and longitude.</td>
            <td>Retrieved information from the service at <a href="https://developers.google.com/places">https://developers.google.com/places</a></td>
        </tr>
        <tr>
            <td>
                <b>Display Locations</b>
            </td>
            <td><a href="http://10.1.22.105:80/GoogleMapLocatorService_TryIt.aspx">http://10.1.22.105:80/GoogleMapLocatorService_TryIt.aspx</a></td>
            <td>Displays the locations on Google Map.</td>
            <td>Retrieved information from the service at <a href="https://developers.google.com/maps/">https://developers.google.com/maps/</a></td>
        </tr>
        <tr>
            <td>
                <b>Natural Hazards Service</b>
            </td>
            <td><a href="http://10.1.22.105:8014/TryIt.aspx">http://10.1.22.105:8014/TryIt.aspx</a></td>
            <td>Provides a natural hazard index of a given position.</td>
            <td>Retrieved information from the service at <a href="www.reliefweb.int">www.reliefweb.int</a></td>
        </tr>
        <tr>
            <td>
                <b>Crime Data Service</b>
            </td>
            <td><a href="http://10.1.22.105:8013/TryIt.aspx">http://10.1.22.105:8013/TryIt.aspx</a></td>
            <td>Provides a crime data index of a given position.</td>
            <td>Retrieved information from the service at <a href="https://spotcrime.com">https://spotcrime.com</a></td>
        </tr>
        <tr>
            <td>
                <b>Nearby Places to Live</b>
            </td>
            <td><a href="http://10.1.22.105:8016/TryIt.aspx">http://10.1.22.105:8016/TryIt.aspx</a></td>
            <td>Provides options of dwelling places nearby</td>
            <td>Retrieved information from the service at <a href="https://developer.foursquare.com/">https://developer.foursquare.com/</a></td>
        </tr>
        <tr>
            <td>
                <b>Nearby Banks and ATMs</b>
            </td>
            <td><a href="http://10.1.22.105:8015/TryIt.aspx">http://10.1.22.105:8015/TryIt.aspx</a></td>
            <td>Provides details of Banks and ATMs nearby in the location.</td>
            <td>Retrieved information from the service at <a href="https://developers.google.com/places">https://developers.google.com/places</a></td>
        </tr>
    </table>
</body>
</html>
