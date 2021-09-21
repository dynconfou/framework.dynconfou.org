<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

    <div runat="server" visible="true">
	    <!-- 	DCF:CSS-Internal -->
	    <link href="/handler/ui-css/authenticate.ashx" type="text/css" rel="stylesheet" />		
	    <!-- 	JQuery -->
	    <script src="https://library.dynconfou.org/dcf/script/jq/jquery.js" type="text/javascript"></script>	

        <!-- 	DCF:URLs -->	
	    <script src="/handler/ui-urls/authenticate.ashx" type="text/javascript"></script>	
        <!-- 	DCF:API -->
	    <script src="/handler/ui-coms/authenticate.ashx" type="text/javascript"></script>	
	    <!-- 	DCF:Framework -->
	    <script src="/handler/ui-framework/authenticate.ashx" type="text/javascript"></script>				    
    </div>
    
</body>
</html>
