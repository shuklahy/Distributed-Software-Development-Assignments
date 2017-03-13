<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationHomework1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 319px; width: 540px">
    <form id="form1" runat="server">
    <div style="height: 311px">
    
&nbsp;<br />
    
        <table style="width:100%;">
            <tr>
                <td>
    
        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                
            </tr>

             <tr>
                <td>
        
                </td>
                <td>
        
        <asp:Button ID="Button1" runat="server" Text="Retrieve LogIn Details" OnClick="Button1_Click" />
        
                </td>
                
            </tr>

                </tr>

             <tr>
                <td>
        
        <asp:Label ID="Label4" runat="server" Text="LogIn Id"></asp:Label>
        
                </td>
                <td>
        
        <asp:Label ID="Label5" runat="server" Text="__"></asp:Label>
        
                </td>
                
            </tr>

                </tr>

             <tr>
                <td>
        
                    <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
        
                </td>
                <td>
        
        <asp:Label ID="Label7" runat="server" Text="___"></asp:Label>
        
                </td>
                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
