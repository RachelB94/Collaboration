<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HitCounter.aspx.cs" Inherits="Collaboration3.HitCounter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" runat="server">
        Total number of users since the Web server started:
        <asp:Label ID="lblTotalNumberOfUsers" runat="server"></asp:Label>
        Current number of users browsing the site:
        <asp:Label ID="lblCurrentNumberOfUsers" runat="server"></asp:Label>
    </form>
</body>
</html>
