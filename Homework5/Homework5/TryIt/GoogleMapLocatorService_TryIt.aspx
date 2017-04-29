<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleMapLocatorService_TryIt.aspx.cs" Inherits="TryIt.GoogleMapLocatorService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Google Map Locator Service - TryIt Page</h2>

    <strong>Description: </strong>This service<span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
SimSun;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA"> returns the map url of a given position (latitude, longitude).
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This URL can be used inside &lt;img&gt; tag to display the location(latitude, longitude) in google maps.</span><strong><br />
    <br />
    URL</strong>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="http://10.1.22.105:8002/Service1.svc?wsdl">http://10.1.22.105:8002/Service1.svc?wsdl</a><br />
    <strong>
    <br />
    Method:<br />
    </strong> <em>Name </em>:<b>&nbsp;&nbsp;&nbsp;&nbsp; getMapURL</b><br />
    <em>Input Parameter</em><strong>: </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [double <strong>latitude</strong>, double <strong>longitude ]</strong> <br />
    <em>Output Parameter</em><strong>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String</strong> url<br />
    <br />
    <strong>Test:</strong><br />

    <form id="form1" runat="server">
    <div aria-readonly="True">
    Latitude: &nbsp;&nbsp; 
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br>
    Longitude: 
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br>
    
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Find" />
        <br />
        <br />
        <strong>Output :
        <br />
        <asp:Label ID="Label1" runat="server" Text="MapURL"></asp:Label>
        </strong><br />

        

        <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" Width="1075px"></asp:TextBox>

        

    </div>
        <p>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/xyz.jpeg" AlternateText="No Maps to display"/>
        </p>
    </form>
</body>
</html>
