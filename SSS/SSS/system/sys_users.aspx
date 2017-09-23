<%@ Page Title="" Language="C#" MasterPageFile="~/system/mastersys.master" AutoEventWireup="true" CodeBehind="sys_users.aspx.cs" Inherits="SSS.system.sys_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Panel ID="Panel3" runat="server" Height="846px">
        Usuario:
        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
        <br />
        Contraseña:
        <asp:TextBox ID="txtpassword" runat="server" Width="259px" ></asp:TextBox>
        &nbsp;
        <br />
        Nivel:&nbsp;
        <asp:TextBox ID="txtnivel" runat="server" AutoPostBack="True" Width="55px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Actualizar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Eliminar" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Limpiar" OnClick="Button4_Click" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" HorizontalAlign="Center" CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSorting="gridview1_Sorting" PageSize="15">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="username" HeaderText="Usuario" />
                <asp:BoundField DataField="password" HeaderText="Contraseña" DataFormatString="*"/>
                <asp:BoundField DataField="nivel" HeaderText="Nivel" />
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
