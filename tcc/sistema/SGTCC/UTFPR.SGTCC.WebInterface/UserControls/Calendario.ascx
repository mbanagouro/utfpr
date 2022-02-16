<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Calendario.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.Calendario" %>

<div>
    <label class="cssTitulo">Calendário de Eventos</label>
<div>

<br />

<asp:Calendar ID="calEventos" runat="server" BackColor="White" ForeColor="Black"
BorderColor="Black" BorderStyle="Solid" CellSpacing="1"
Font-Names="Verdana" Font-Size="9pt" Height="340px" Width="100%"
NextPrevFormat="FullMonth" BorderWidth="0px" DayNameFormat="Full">
    <SelectedDayStyle BackColor="DarkOrange" ForeColor="White" />
    <DayStyle Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" BackColor="Orange" Font-Bold="True" ForeColor="White" />
    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
    <TitleStyle BackColor="Black" BorderStyle="None" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
    <OtherMonthDayStyle BackColor="Gainsboro" Font-Bold="False" ForeColor="White" />
</asp:Calendar>
