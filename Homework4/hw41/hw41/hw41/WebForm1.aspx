﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="hw41.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
        .auto-style2 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <span class="auto-style2"><strong>XML Reader</strong></span><br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        URL for the XML<br />
        <asp:TextBox ID="TextBox3" runat="server" Width="465px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox4" runat="server" Height="272px" ReadOnly="True" TextMode="MultiLine" Width="1066px"></asp:TextBox>
        <br />
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Read" />
        <br />
    
    </div>
    </form>
</body>
</html>
