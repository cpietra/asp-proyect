<%@ Page Title="Cirugias" Language="C#" MasterPageFile="~/system/mastersys.master" AutoEventWireup="true" CodeBehind="sys_cirugias.aspx.cs" Inherits="SSS.system.sys_cirugias" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <br />
    <asp:Panel ID="Panel1" runat="server" Height="845px" Style="margin-left: 11px; margin-bottom: 116px; margin-right: 0px;" Width="1800px" HorizontalAlign="Left" Direction="LeftToRight">
        Fecha :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
        &nbsp;&nbsp; Paciente:
        <asp:TextBox ID="txtpaciente" runat="server" Width="259px" ></asp:TextBox>
        &nbsp; Cobertura:
        <asp:DropDownList ID="DropDownList1" runat="server" Width="135px">
        </asp:DropDownList>
        &nbsp;
        <br />
        Cirujano:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtcirujano" runat="server" Width="179px"></asp:TextBox>
        &nbsp; Diagnostico:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtdiag" runat="server" Width="229px"></asp:TextBox>
        <br />
        Fecha Cirugia:&nbsp;
        <asp:TextBox ID="txtfechacx" runat="server"></asp:TextBox>
        <ajk:CalendarExtender ID="cfechacx" runat="server" TargetControlID="txtfechacx" Format="dd/MM/yyyy" />
        <ajk:MaskedEditExtender ID="mskfcx" TargetControlID="txtfechacx" runat="server" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Date" ErrorTooltipEnabled="True" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtfechacx" Display="Dynamic" ErrorMessage="Formato Invalido" ForeColor="#CC0000" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
        &nbsp; Horario Cirugia:&nbsp;&nbsp;
        <asp:TextBox ID="txthorario" runat="server" Width="50px"></asp:TextBox>
        <ajk:MaskedEditExtender ID="mskhorario" TargetControlID="txthorario" runat="server" Mask="99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Time" ErrorTooltipEnabled="True" />
        &nbsp; Quirofano:
        <asp:TextBox ID="txtquirofanon" runat="server" Width="24px"></asp:TextBox>
        <ajk:MaskedEditExtender ID="mskquirofanon" TargetControlID="txtquirofanon" runat="server" Mask="9" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Number" ErrorTooltipEnabled="True" />
        &nbsp; Fecha Internacion:&nbsp;
        <asp:TextBox ID="txtfechaint" runat="server" ></asp:TextBox>
        <ajk:CalendarExtender ID="cfechaint" runat="server" TargetControlID="txtfechaint" Format="dd/MM/yyyy" />
        <ajk:MaskedEditExtender ID="mskfint" TargetControlID="txtfechaint" runat="server" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" MaskType="Date" ErrorTooltipEnabled="True" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtfechaint" Display="Dynamic" ErrorMessage="Formato Invalido" ForeColor="#CC0000" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
        &nbsp;<br />
        Estudios Previos - ECG:
        <asp:CheckBox ID="ECG0" runat="server" TextAlign="Left" />
        &nbsp;&nbsp;&nbsp; RX:
        <asp:CheckBox ID="RX0" runat="server" TextAlign="Left" />
        &nbsp; Laboratorio:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="Lab1" runat="server" TextAlign="Left" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Reserva Habitacion:
        <asp:CheckBox ID="RH1" runat="server" TextAlign="Left" />
        <br />
        Monitoreo:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="Monitoreo1" runat="server" TextAlign="Left" />
        &nbsp; Arco C:
        <asp:CheckBox ID="Arco" runat="server" TextAlign="Left" />
        &nbsp; Hemoterapia - Agrupado:
        <asp:CheckBox ID="agrupa1" runat="server" TextAlign="Left" />
        &nbsp;Reserva Unidades:&nbsp;
        <asp:TextBox ID="txtunidadesh" runat="server" Width="44px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ambulatorio:
        <asp:CheckBox ID="Ambu1" runat="server" TextAlign="Left" />
        / Recuperacion:<asp:CheckBox ID="Recupera1" runat="server" TextAlign="Left" />
        <br />
        Obsercacion:<asp:TextBox ID="txtobservacion" runat="server" Width="412px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Eliminar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Actualizar" OnClick="Button3_Click" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Limpiar" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" DataKeyNames="id, fecha" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSorting="gridview1_Sorting" PageSize="15">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="fecha" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha" Visible="false" />
                <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                <asp:BoundField DataField="cobertura" HeaderText="Cobertura" />
                <asp:BoundField DataField="cirujano" HeaderText="Cirujano" />
                <asp:BoundField DataField="diagnostico" HeaderText="Diagnostico" />
                <asp:BoundField DataField="fechacx" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha CX" />
                <asp:BoundField DataField="horario" HeaderText="Horario" />
                <asp:BoundField DataField="quirofanon" HeaderText="Quirofano" />
                <asp:BoundField DataField="fechaint" DataFormatString="{0:dd-MM-yyyy}" HeaderText="Fecha Int" />
                <asp:TemplateField HeaderText="Hab.">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkhab" Checked='<%# Convert.ToBoolean(Eval("reservahab")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amb.">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkambu" Checked='<%# Convert.ToBoolean(Eval("ambulatorio")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Recup.">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkrecu" Checked='<%# Convert.ToBoolean(Eval("recuperacion")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lab.">
                    <ItemTemplate>
                        <asp:CheckBox ID="chklab" Checked='<%# Convert.ToBoolean(Eval("laboratoriop")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ECG">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkpreecg" Checked='<%# Convert.ToBoolean(Eval("preecg")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RX">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkrx" Checked='<%# Convert.ToBoolean(Eval("prerx")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Monitoreo">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkmoni" Checked='<%# Convert.ToBoolean(Eval("monitoreo")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Arco C">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkarcoc" Checked='<%# Convert.ToBoolean(Eval("arcoc")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agrupa">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkagrup" Checked='<%# Convert.ToBoolean(Eval("agrupa")) %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="unidadesh" HeaderText="Unidades" />
                <asp:BoundField DataField="observacion" HeaderText="Observacion" />
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
        <br />
    </asp:Panel>
    <br />
</asp:Content>
