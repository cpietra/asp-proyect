using SSS.Model;
using SSS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSS.system
{
    public partial class sys_cirugias : System.Web.UI.Page
    {
        private CirugiasClass cirugia = new CirugiasClass();
        private DAO dao = new DAO();
        private String operador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                reader_gridview();
                txtFecha.Text = Convert.ToDateTime(DateTime.Now).ToShortDateString();
                txtFecha.Enabled = false;
                Button2.Enabled = false;
                Button3.Enabled = false;
            }
        }

        private void reader_gridview()
        {
            llena_combo();
            GridView1.DataSource = dao.GetData("Select id, fecha, paciente, laboratoriop, preecg, prerx, arcoc, fechaint, fechacx, cirujano, diagnostico, monitoreo, horario, agrupa, unidadesh, reservahab, quirofano,"
                + " ambulatorio, recuperacion, operador, cobertura, quirofanon, observacion FROM cirugias WHERE fecha = '" + Convert.ToDateTime(DateTime.Now).ToShortDateString() + "' and operador = '"+ User.Identity.Name + "' ORDER BY fecha");
            GridView1.DataBind();
            //GridView1.Columns[7].Visible = false;

        }

        private void llena_combo()
        {
            DropDownList1.Items.Clear();
            DropDownList1.DataTextField = "cobertura";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataSource = dao.GetData("Select * from coberturas");
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                cirugia = new CirugiasClass();
                if (!string.IsNullOrEmpty(txtfechacx.Text)) { cirugia.Fecha = Convert.ToDateTime(txtFecha.Text); }
                cirugia.Paciente = txtpaciente.Text;
                cirugia.Laboratoriop = Lab1.Checked;
                cirugia.Preecg = ECG0.Checked;
                cirugia.Prerx = RX0.Checked;
                cirugia.Arcoc = Arco.Checked;
                cirugia.Monitoreo = Monitoreo1.Checked;
                cirugia.Agrupa = agrupa1.Checked;
                if (!string.IsNullOrEmpty(txtfechaint.Text)){ cirugia.Fechaint = Convert.ToDateTime(txtfechaint.Text); }
                if (!string.IsNullOrEmpty(txtfechacx.Text)){ cirugia.Fechacx = Convert.ToDateTime(txtfechacx.Text); }
                cirugia.Horario = txthorario.Text;
                cirugia.Cirujano = txtcirujano.Text;
                cirugia.Diagnostico = txtdiag.Text;
                cirugia.Ambulatorio = Ambu1.Checked;
                if (!string.IsNullOrEmpty(txtquirofanon.Text)){ cirugia.Quirofanon = Convert.ToInt32(txtquirofanon.Text); }
                cirugia.Recuperacion = Recupera1.Checked;
                cirugia.Reservahab = RH1.Checked;
                cirugia.Cobertura = DropDownList1.SelectedItem.Text;
                if (!string.IsNullOrEmpty(txtunidadesh.Text)) { cirugia.Unidadesh = Convert.ToInt32(txtunidadesh.Text); }
                cirugia.Observacion = txtobservacion.Text;
                operador = User.Identity.Name;
                cirugia.Operador = operador;
                String id_cir = dao.create_cirugia(cirugia);
                cirugia.Id = Convert.ToInt32(id_cir);
                clear_fieds();
                reader_gridview();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            cirugia = new CirugiasClass();
            cirugia = Session["Ciru_Session"] as CirugiasClass;
            dao.borrar_cirugia(cirugia.Id);
            clear_fieds();
            reader_gridview();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                cirugia = new CirugiasClass();
                cirugia = Session["Ciru_Session"] as CirugiasClass;
                if (!string.IsNullOrEmpty(txtfechacx.Text)) { cirugia.Fecha = Convert.ToDateTime(txtFecha.Text); }
                cirugia.Paciente = txtpaciente.Text;
                cirugia.Laboratoriop = Lab1.Checked;
                cirugia.Preecg = ECG0.Checked;
                cirugia.Prerx = RX0.Checked;
                cirugia.Arcoc = Arco.Checked;
                cirugia.Monitoreo = Monitoreo1.Checked;
                cirugia.Agrupa = agrupa1.Checked;
                if (!string.IsNullOrEmpty(txtfechaint.Text)) { cirugia.Fechaint = Convert.ToDateTime(txtfechaint.Text); }
                if (!string.IsNullOrEmpty(txtfechacx.Text)) { cirugia.Fechacx = Convert.ToDateTime(txtfechacx.Text); }
                cirugia.Horario = txthorario.Text;
                cirugia.Cirujano = txtcirujano.Text;
                cirugia.Diagnostico = txtdiag.Text;
                cirugia.Ambulatorio = Ambu1.Checked;
                if (!string.IsNullOrEmpty(txtquirofanon.Text)) { cirugia.Quirofanon = Convert.ToInt32(txtquirofanon.Text); }
                cirugia.Recuperacion = Recupera1.Checked;
                cirugia.Reservahab = RH1.Checked;
                cirugia.Cobertura = DropDownList1.SelectedItem.Text;
                if (!string.IsNullOrEmpty(txtunidadesh.Text)) { cirugia.Unidadesh = Convert.ToInt32(txtunidadesh.Text); }
                cirugia.Observacion = txtobservacion.Text; ;
                operador = User.Identity.Name;
                cirugia.Operador = operador;
                dao.actualizar_cirugia(cirugia);
                clear_fieds();
                reader_gridview();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            clear_fieds();
            reader_gridview();
        }

        private void clear_fieds()
        {
            //txtFecha.Text = "";
            txtpaciente.Text = "";
            Lab1.Checked = false;
            ECG0.Checked = false;
            RX0.Checked = false;
            Monitoreo1.Checked = false;
            Arco.Checked = false;
            agrupa1.Checked = false;
            txtfechaint.Text = "";
            txtfechacx.Text = "";
            txthorario.Text = "";
            txtcirujano.Text = "";
            txtdiag.Text = "";
            txtunidadesh.Text = "";
            txtquirofanon.Text="";
            Ambu1.Checked = false;
            RH1.Checked = false;
            Recupera1.Checked = false;
            txtobservacion.Text = "";
            Button1.Enabled = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            llena_combo();
            GridViewRow row = GridView1.SelectedRow;
            var colsNoVisible = GridView1.DataKeys[row.RowIndex].Values;
            cirugia.Id = (Int32)colsNoVisible[0];
            cirugia.Fecha = Convert.ToDateTime(colsNoVisible[1]);
            cirugia.Paciente = row.Cells[3].Text;
            if (row.Cells[4].Text != "" && row.Cells[4].Text.IndexOf("nbsp;") == -1)
            {
                cirugia.Cobertura = row.Cells[4].Text;
            }
            else
            {
                cirugia.Cobertura = "";
            }
            if (row.Cells[5].Text != "" && row.Cells[5].Text.IndexOf("nbsp;") == -1)
            {
                cirugia.Cirujano = row.Cells[5].Text;
            }
            else
            {
                cirugia.Cirujano = "";
            }
            if (row.Cells[6].Text != "" && row.Cells[6].Text.IndexOf("nbsp;") == -1)
            {
                cirugia.Diagnostico = row.Cells[6].Text;
            }
            else
            {
                cirugia.Diagnostico = "";
            }
            cirugia.Fechacx = Convert.ToDateTime(row.Cells[7].Text);
            if (row.Cells[8].Text != "" && row.Cells[8].Text.IndexOf("nbsp;") == -1)
            {
                cirugia.Horario = row.Cells[8].Text;
            }
            else
            {
                cirugia.Horario = "";
            }
            if (row.Cells[9].Text != "" && row.Cells[9].Text.IndexOf("nbsp;") == -1)
            {
                cirugia.Quirofanon = Convert.ToInt32(row.Cells[9].Text);
            }
            else
            {
                cirugia.Quirofanon = 0;
            }
            foreach (GridViewRow rowchk in GridView1.Rows)
            {
                if (rowchk.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkhab = (row.Cells[11].FindControl("chkhab") as CheckBox);
                    CheckBox chkambu = (row.Cells[12].FindControl("chkambu") as CheckBox);
                    CheckBox chklab = (row.Cells[13].FindControl("chklab") as CheckBox);
                    CheckBox chkrecu = (row.Cells[14].FindControl("chkrecu") as CheckBox);
                    CheckBox chkpreecg = (row.Cells[15].FindControl("chkpreecg") as CheckBox);
                    CheckBox chkrx = (row.Cells[16].FindControl("chkrx") as CheckBox);
                    CheckBox chkmoni = (row.Cells[17].FindControl("chkmoni") as CheckBox);
                    CheckBox chkarcoc = (row.Cells[18].FindControl("chkarcoc") as CheckBox);
                    CheckBox chkagrup = (row.Cells[19].FindControl("chkagrup") as CheckBox);
                    if (chkpreecg.Checked)
                    {
                        cirugia.Preecg = true;
                    }
                    else
                    {
                        cirugia.Preecg = false;
                    }
                    if (chkrx.Checked)
                    {
                        cirugia.Prerx = true;
                    }
                    else
                    {
                        cirugia.Prerx = false;
                    }
                    if (chkarcoc.Checked)
                    {
                        cirugia.Arcoc = true;
                    }
                    else
                    {
                        cirugia.Arcoc = false;
                    }
                    if (chkagrup.Checked)
                    {
                        cirugia.Agrupa = true;
                    }
                    else
                    {
                        cirugia.Agrupa = false;
                    }
                    if (chkambu.Checked)
                    {
                        cirugia.Ambulatorio = true;
                    }
                    else
                    {
                        cirugia.Ambulatorio = false;
                    }
                    if (chkrecu.Checked)
                    {
                        cirugia.Recuperacion = true;
                    }
                    else
                    {
                        cirugia.Recuperacion = false;
                    }
                    if (chkhab.Checked)
                    {
                        cirugia.Reservahab = true;
                    }
                    else
                    {
                        cirugia.Reservahab = false;
                    }
                    if (chklab.Checked)
                    {
                        cirugia.Laboratoriop = true;
                    }
                    else
                    {
                        cirugia.Laboratoriop = false;
                    }
                    if (chkmoni.Checked)
                    {
                        cirugia.Monitoreo = true;
                    }
                    else
                    {
                        cirugia.Monitoreo = false;
                    }
                }
            }
            cirugia.Fechaint = Convert.ToDateTime(row.Cells[10].Text);

            if (row.Cells[20].Text != "" && row.Cells[20].Text.IndexOf("nbsp;") == -1)
            {
                cirugia.Unidadesh = Convert.ToInt32(row.Cells[20].Text);
            }
            else
            {
                cirugia.Unidadesh = 0;
            }
            if (row.Cells[21].Text != "" && row.Cells[21].Text.IndexOf("nbsp;") == -1)
            {
                cirugia.Observacion = row.Cells[21].Text;
            }
            else
            {
                cirugia.Observacion = "";
            }

            txtFecha.Text = cirugia.Fecha.ToString("dd/MM/yyyy");
            txtpaciente.Text = cirugia.Paciente;
            Lab1.Checked = cirugia.Laboratoriop;
            ECG0.Checked = cirugia.Preecg;
            RX0.Checked = cirugia.Prerx;
            Monitoreo1.Checked = cirugia.Monitoreo;
            Arco.Checked = cirugia.Arcoc;
            agrupa1.Checked = cirugia.Agrupa;
            txtfechaint.Text = cirugia.Fechaint.ToString("dd/MM/yyyy");
            txtfechacx.Text = cirugia.Fechacx.ToString("dd/MM/yyyy");
            txthorario.Text = cirugia.Horario;
            txtcirujano.Text = cirugia.Cirujano;
            txtdiag.Text = cirugia.Diagnostico;
            txtunidadesh.Text = cirugia.Unidadesh.ToString();
            txtquirofanon.Text = cirugia.Quirofanon.ToString();
            Recupera1.Checked = cirugia.Recuperacion;
            Ambu1.Checked = cirugia.Ambulatorio;
            RH1.Checked = cirugia.Reservahab;
            txtobservacion.Text = cirugia.Observacion;
            ListItem itemCober = DropDownList1.Items.FindByText(cirugia.Cobertura);
            if (itemCober != null)
            {
                DropDownList1.Items.FindByText(cirugia.Cobertura).Selected = true;
            }
            Session["Ciru_Session"] = cirugia;
            Button1.Enabled = false;
            Button2.Enabled = true;
            Button3.Enabled = true;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            reader_gridview();
        }

        protected void gridview1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = GridView1.DataSource as DataTable;
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirection(e.SortDirection);
                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }

        }

        private string ConvertSortDirection(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

    }
}