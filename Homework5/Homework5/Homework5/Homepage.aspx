<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Homework5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 782px">
    Welcome
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
            <asp:Panel ID="Panel1" runat="server" Height="192px">
                <br />
                <asp:Label ID="Label2" runat="server" Text="Enter ZipCode"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <br />
                Latitude :<asp:Label ID="Label4" runat="server"></asp:Label>
                <br />
                <br />
                Longitude :
                <asp:Label ID="Label5" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" Text="GetLatLon" OnClick="Button2_Click" />
                <br />
                <br />
                <br />
                <asp:Panel ID="Panel2" runat="server" Height="510px">
                    <strong>CITY INFO :<br />
                    <br />
                    Cached Data :
                    </strong>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Check Cache" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>(Current timeout is 10s)<br />
                    <br />
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Get City Info" />
                    &nbsp; (If the cache becomes Invalid clicking this will clear all city information)<br /> &nbsp;<asp:Panel ID="Panel3" runat="server" Height="362px">
                        <br />
                        Wind Energy Intensity :<asp:Label ID="Label6" runat="server"></asp:Label>
                        <br />
                        <br />
                        Solar Energy Intensity:<asp:Label ID="Label7" runat="server"></asp:Label>
                        <br />
                        <br />
                        Location on Map:<br />
                        <br />
                        <asp:Image ID="Image1" runat="server" />
                        <br />
                        <br />
                        Gas Stations Near city:<br />
                        <br />
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
                    </asp:Panel>
                </asp:Panel>
                <br />
                <br />
                <br />
            </asp:Panel>
    <br />
</div>
    </form>
</body>
</html>
