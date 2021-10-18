<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<%--<head runat="server" visible="true">
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
<body runat="server" visible="true"></body>--%>

<head runat="server" visible="true">
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
</head>
<body role="content" runat="server" visible="true">
    <modal></modal>

    <script>
        /* load complete */
        function _loadComplete() {
            obModal.identifiers.header.class = 't-l';
            obModal.identifiers.header.type = '<h2>';
            obModal.identifiers.subheader.class = 't-l';
            obModal.identifiers.subheader.type = '<h4>';
            obModal.updateUI();
            obModal.events.showthis();
        }

        /* setup modal */
        dcf.urls.items.global.modal.template = ['', 'handler', 'ui-modal', 'modal.template.ashx'].join('/');
        dcf.urls.items.global.modal.script = ['', 'handler', 'ui-modal', 'modal.script.ashx'].join('/');

        /* modal */
        dcf.require('modal').load(function (data) {
            dcf.registerUI(obModal);
            $('modal').replaceWith(obModal.buildUI());
            obModal.initUI();
            _loadComplete();
        });                        
    </script>    
</body>
</html>
