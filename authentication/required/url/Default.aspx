<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="authentication_required_url_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Authentication Required: Request URL - Not Supported/Recognized</title>
    <style>
		body {
	    	font-family: verdana;
			color: rgb(50, 50, 50);
			text-align: center;
			background-image: url(https://library.dynconfou.org/assets/images/family.jpg);
			background-size: cover;
			background-repeat: no-repeat;
			background-position: left top;
			min-height: 600px;
	    }							
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--
        In Development Mode - Please excuse the message...
        Authentication Required: Request URL - Not Supported/Recognized
        Client: <%=requestClient %>
        IP: <%=requestIP %>
        URL: <%=requestURL %>
    -->              
    </div>
    </form>
</body>
</html>
