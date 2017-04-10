<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GasStationService_TryIt.aspx.cs" Inherits="TryIt.GasStationService_TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Gas Station Service - TryIt Page</h2>

    <strong>Description: </strong>This service<span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
SimSun;mso-fareast-theme-font:minor-fareast;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:ZH-CN;mso-bidi-language:AR-SA"> returns the gas stations within 5000m radius of a given position (latitude, longitude).
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This service can be used during transportation to decide nearest gas stations.</span><strong><br />
    <br />
    URL</strong>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="http://10.1.22.105:8001/Service1.svc?wsdl">http://10.1.22.105:8001/Service1.svc?wsdl</a><br />
    <strong>
    <br />
    Method:<br />
    </strong> <em>Name </em>:<b>&nbsp;&nbsp;&nbsp;&nbsp; getGasStation</b><br />
    <em>Input Parameter</em><strong>: </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; [double <strong>latitude</strong>, double <strong>longitude ]</strong> <br />
    <em>Output Parameter</em><strong>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result[]</strong> gasStationDetails<br />
    <br />
    public class result {<br />&nbsp; public String name;<br />&nbsp; public String openNow;<br />&nbsp; public String address;<br /> }<br /><br />
    <strong>Test:</strong><br />

    <form id="form1" runat="server">
    <div>
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
        </strong><br />

        <asp:ListView ID="ListView1" runat="server">
            <LayoutTemplate>
                <table runat="server" id="table1" >
                    <tr runat="server" id="itemPlaceholder" ></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                    <tr runat="server">
                        <td runat="server">
                            <asp:Label ID="lblName" runat="server" Text="Name of GasStation:" Font-Bold="true"></asp:Label>
                        </td>
                        <td>

                       </td>
                        <td runat="server">
                            <asp:Label ID="name" runat="server" Text='<%#Eval("name") %>' />
                        </td>
                    </tr>
                    <tr runat="server">
                         <td runat="server">
                            <asp:Label ID="lblPhone" runat="server" Text="Address:" Font-Bold="true"></asp:Label>
                        </td>
                        <td>

                       </td>
                        <td runat="server">
                            <asp:Label ID="phone" runat="server" Text='<%#Eval("address") %>' />
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server">
                            <asp:Label ID="lblAddress" runat="server" Text="Open Now?" Font-Bold="true"></asp:Label>
                        </td>
                        <td>

                       </td>
                        <td runat="server">
                            <asp:Label ID="address" runat="server"  Text='<%#Eval("openNow") %>' />
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server">
                            <asp:Label ID="Label1" runat="server" Text="------------" ></asp:Label>
                        </td>
                        <td>

                       </td>
                        <td runat="server">
                            <asp:Label ID="Label2" runat="server"  Text="------------" />
                        </td>
                    </tr>
                
            </ItemTemplate>
            <EmptyDataTemplate>
              
            </EmptyDataTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>

    </div>
    </form>
</body>
</html>
