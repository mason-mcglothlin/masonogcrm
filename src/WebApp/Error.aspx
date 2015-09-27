<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="MasonOgCRM.WebApp.Error" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>OgCRM Error</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Error</h1>
     <p>Sorry, an unexpected error has occurred. Click <asp:HyperLink runat="server" NavigateUrl="~/">here</asp:HyperLink> to return to the home page.</p>
    <p>Note, since this is a demo site, you can check <asp:HyperLink runat="server" NavigateUrl="~/elmah">Elmah</asp:HyperLink> to see what the error is.</p>
    </div>
    </form>
</body>
</html>
