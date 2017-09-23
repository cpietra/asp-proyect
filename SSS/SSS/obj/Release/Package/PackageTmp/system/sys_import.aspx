<%@ Page Title="" Language="C#" MasterPageFile="~/system/mastersys.master" AutoEventWireup="true" CodeBehind="sys_import.aspx.cs" Inherits="SSS.system.sys_import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:FileUpload ID="FileUploadControl" runat="server" />
    <asp:Button runat="server" ID="UploadButton" Text="Subir" OnClick="UploadButton_Click" />
    <br />
    <br />
    <asp:Label runat="server" ID="StatusLabel" Text="Estado de la Carga: " />
</asp:Content>
