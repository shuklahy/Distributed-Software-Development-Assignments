<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WindService_TryIt.aspx.cs" Inherits="TryIt.WindService_TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Wind Energy Service - TryIt Page</h2>

    <strong>Description: </strong>This <span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
SimSun;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA">service that returns the annual average wind index of a given position (latitude, longitude).
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This service can be used for deciding if installing windmill device is effective at the location.</span><strong><br />
    <br />
    URL</strong>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="http://10.1.22.105:8003/Service1.svc?wsdl">http://10.1.22.105:8003/Service1.svc?wsdl</a><br />
    <strong>
    <br />
    Method:<br />
    </strong> <em>Name </em>:<b>&nbsp;&nbsp;&nbsp;&nbsp; </b>WindIntensity<br />
    <em>Input Parameter</em><strong>: </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [decimal <strong>latitude</strong>, decimal <strong>longitude ]</strong> <br />
    <em>Output Parameter</em><strong>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>decimal <strong>windIntensity</strong>
    <br />
    <br />
    <strong>Test:</strong><br />

    <form id="form1" runat="server">
    <div>
    Latitude: &nbsp;&nbsp; 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br>
    Longitude: 
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Evaluate" />
        <br />
        <br />
        <strong>Output :<br />
        </strong><br />

    Wind Intensity Value&nbsp; <i/>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
