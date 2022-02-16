<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VisualizaRelatorio.aspx.vb" 
   Title="UTFPR - Visualização de Relatórios" Inherits="UTFPR.SGTCC.WebInterface.RelatorioBanca" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server"></head>
<body>
    <form id="frmRelatorios" runat="server">
        <asp:Label ID="lblMensagem" runat="server" Font-Bold="True" Text=""></asp:Label>
        <rsweb:ReportViewer ID="rvwTCC" runat="server" Width="100%" 
            Font-Names="Verdana" Font-Size="8pt" ShowBackButton="True" 
            SizeToReportContent="True">
            <LocalReport ReportPath="" >
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>
