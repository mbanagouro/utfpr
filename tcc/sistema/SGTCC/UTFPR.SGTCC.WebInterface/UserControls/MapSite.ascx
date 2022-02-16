<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MapSite.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.MapSite" %>

<div id="map">

	<asp:SiteMapPath runat="server" id="siteMap" Font-Names="Verdana" 
        Font-Size="0.8em" PathSeparator=" : ">
        <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
        <CurrentNodeStyle ForeColor="#333333" />
        <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
        <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
	</asp:SiteMapPath>
	
</div>