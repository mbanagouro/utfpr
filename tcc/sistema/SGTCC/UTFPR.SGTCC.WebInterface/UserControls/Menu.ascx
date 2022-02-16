<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="menu.ascx.vb" Inherits="UTFPR.SGTCC.WebInterface.menu" %>

<table id="menu" width="0" cellpadding="0" cellspacing="0" border="0">
    <tr>
      <td id="menuHome" runat="server" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkHome" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuHome_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuHome_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuHome_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuHome_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuHome_0.png") %>'"
            width="67" height="32" border="0" alt="Página Principal" title="Página Principal" />
        </asp:LinkButton>
      </td>
      <td id="menuMateria" runat="server" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkMateria" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuMateria_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuMateria_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuMateria_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuMateria_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuMateria_0.png") %>'"
            width="84" height="32" border="0" alt="Sobre a Matéria de TCC" title="Sobre a Matéria de TCC" />
        </asp:LinkButton>
      </td>
      <td id="menuAgenda" runat="server" visible="false" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkAgenda" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuAgenda_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuAgenda_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuAgenda_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuAgenda_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuAgenda_0.png") %>'"
            width="84" height="32" border="0" alt="Agenda Pessoal" title="Agenda Pessoal" />
        </asp:LinkButton>
      </td>
      <td id="menuCorreio" runat="server" visible="false" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkCorreio" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuCorreio_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuCorreio_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuCorreio_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuCorreio_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuCorreio_0.png") %>'"
            width="80" height="32" border="0" alt="Correio" title="Correio" />
        </asp:LinkButton>
      </td>
      <td id="menuUsuarios" runat="server" visible="false" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkUsuarios" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuUsuarios_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuUsuarios_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuUsuarios_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuUsuarios_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuUsuarios_0.png") %>'"
            width="86" height="32" border="0" alt="Gerenciamento de Usuários" title="Gerenciamento de Usuários" />
        </asp:LinkButton>
      </td>
      <td id="menuTcc" runat="server" visible="false" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkTcc" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuTcc_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuTcc_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuTcc_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuTcc_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuTcc_0.png") %>'"
            width="64" height="32" border="0" alt="Gerenciamento dos TCC" title="Gerenciamento dos TCC" />
        </asp:LinkButton>
      </td>
      <td id="menuAvisos" runat="server" visible="false" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkAvisos" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuAvisos_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuAvisos_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuAvisos_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuAvisos_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuAvisos_0.png") %>'"
            width="94" height="32" border="0" alt="Gerenciamento de Avisos" title="Gerenciamento de Avisos" />
        </asp:LinkButton>
      </td>
      <td id="menuArquivos" runat="server" visible="false" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkArquivos" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuArquivos_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuArquivos_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuArquivos_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuArquivos_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuArquivos_0.png") %>'"
            width="94" height="32" border="0" alt="Gerenciamento de Arquivos" title="Gerenciamento de Arquivos" />
        </asp:LinkButton>
      </td>  
      <td id="menuConfig" runat="server" visible="false" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkConfig" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuConfig_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuConfig_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuConfig_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuConfig_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuConfig_0.png") %>'"
            width="94" height="32" border="0" alt="Configurações do Administrador" title="Configurações do Administrador" />
       </asp:LinkButton>
      </td> 
      <td id="menuDownloads" runat="server" style="padding-right:0px" title="">
        <asp:LinkButton ID="lnkDownloads" runat="server" CausesValidation="False">
            <img src="<% =Me.ResolveClientUrl("~/imagens/menu/menuDownloads_0.png") %>" 
            onmouseover="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuDownloads_1.png") %>'"
            onmouseout="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuDownloads_0.png") %>'"
            onmousedown="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuDownloads_2.png") %>'"
            onmouseup="this.src='<% =Me.ResolveClientUrl("~/imagens/menu/menuDownloads_0.png") %>'"
            width="94" height="32" border="0" alt="Área de Downloads" title="Área de Downloads" />
        </asp:LinkButton>
      </td>                                 
      <td style="width:8px;"></td>
    </tr>
</table>