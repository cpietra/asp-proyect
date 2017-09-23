<%@ Page Title="Coberturas" Language="C#" MasterPageFile="~/system/mastersys.master" AutoEventWireup="true" CodeBehind="sys_coberturas.aspx.cs" Inherits="SSS.system.sys_coberturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="845px" Style="margin-left: 11px; margin-bottom: 116px; margin-right: 0px;" Width="1449px" HorizontalAlign="Left" Direction="LeftToRight">
        Codigo :<asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        &nbsp;&nbsp; Cobertura:
        <asp:TextBox ID="txtCobertura" runat="server" Width="259px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Eliminar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Actualizar" OnClick="Button3_Click" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Limpiar" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" AutoGenerateSelectButton="True" CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSorting="gridview1_Sorting" PageSize="15">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="cobertura" HeaderText="Cobertura" />
                <asp:BoundField DataField="operador" HeaderText="Operador" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </asp:Panel>
    </asp:Content>
