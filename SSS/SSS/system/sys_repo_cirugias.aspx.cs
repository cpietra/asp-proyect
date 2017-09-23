using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using SSS.Model;
using SSS.Models;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using NPOI.HSSF.UserModel;

namespace SSS.system
{
    public partial class sys_repo_ciugias : System.Web.UI.Page
    {
        private CirugiasClass cirugia = new CirugiasClass();
        private DAO dao = new DAO();
        private String operador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                DropDownList2.Items.Clear();
                
                DropDownList2.DataTextField = "cobertura";
                DropDownList2.DataValueField = "id";
                DropDownList2.DataSource = dao.GetData("Select * from coberturas");
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Cobertura", ""));
                DropDownList2.SelectedIndex = 0;
                String sql = "Select id, fecha, paciente, laboratoriop, preecg, prerx, arcoc, fechaint, fechacx, cirujano, diagnostico, monitoreo, horario, agrupa, unidadesh, reservahab, quirofano, ambulatorio, recuperacion, operador, cobertura, quirofanon, observacion FROM cirugias ORDER BY fecha";
                reader_gridview(sql);
                Session["sql"] = sql;
                Button3.Enabled = false;
                Button4.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var bl = !string.IsNullOrEmpty(txtFDesde.Text) &&
                         !string.IsNullOrEmpty(txtFHasta.Text);
                if (bl)
                {
                    String sql = "Select id, fecha, paciente, laboratoriop, preecg, prerx, arcoc, fechaint, fechacx, cirujano, diagnostico, monitoreo, horario, agrupa, unidadesh, reservahab, quirofano, ambulatorio, recuperacion, operador, cobertura, quirofanon, observacion FROM cirugias"
                        + " WHERE fechacx BETWEEN '" + Convert.ToDateTime(txtFDesde.Text) + "' AND '" + Convert.ToDateTime(txtFHasta.Text) + "'";
                    if (!string.IsNullOrEmpty(txtcirujanob.Text)) { sql = sql + " AND cirujano = '" + txtcirujanob.Text + "'"; }
                    if (!string.IsNullOrEmpty(DropDownList2.SelectedItem.Text) && DropDownList2.SelectedItem.Text != "Cobertura") { sql = sql + " AND cobertura = '" + DropDownList2.SelectedItem.Text + "'"; }
                    sql = sql + " ORDER BY fecha ";
                    reader_gridview(sql);
                    Session["sql"] = sql;
                }
            }
        }

        private void reader_gridview(String sql)
        {
            GridView1.DataSource = dao.GetData(sql);
            GridView1.DataBind();
            //GridView1.Columns[7].Visible = false;

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String sql = Session["sql"] as String;
            GridView1.PageIndex = e.NewPageIndex;
            reader_gridview(sql);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            Session["Ciru_Session"] = cirugia;
            String sql = Session["sql"] as String;
            Session["sql"] = sql;
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("Cobertura");
            DropDownList1.DataTextField = "cobertura";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataSource = dao.GetData("Select * from coberturas");
            DropDownList1.DataBind();
            Button4.Enabled = true;
            if (cirugia != null)
            {
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
                System.Web.UI.WebControls.ListItem itemCober = DropDownList1.Items.FindByText(cirugia.Cobertura);
                if (itemCober != null)
                {
                    DropDownList1.Items.FindByText(cirugia.Cobertura).Selected = true;
                }
                Session["Ciru_Session"] = cirugia;
                Session["id_Ciru"] = cirugia.Id.ToString();
                //Button1.Enabled = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtFDesde.Text = "";
            txtFHasta.Text = "";
            txtcirujanob.Text = "";
            DropDownList2.SelectedIndex = 0;
            String sql = "Select id, fecha, paciente, laboratoriop, preecg, prerx, arcoc, fechaint, fechacx, cirujano, diagnostico, monitoreo, horario, agrupa, unidadesh, reservahab, quirofano, ambulatorio, recuperacion, operador, cobertura, quirofanon, observacion FROM cirugias ORDER BY fecha";
            reader_gridview(sql);
            Session["Ciru_Session"] = null;
            Session["sql"] = sql;
            Button4.Enabled = false;
            GridView1.SelectedIndex = -1;
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            String sql = Session["sql"] as String;
            if (sql != null)
            {
                string ruta = "G:\\Christian\\Documents\\Visual Studio 2015\\Projects\\SSS\\SSS\\Uploads\\reporte.pdf";
                createPDF(dao.GetData(sql), ruta);
            }
        }

        public void createPDF(DataTable dataTable, string destinationPath)
        {
            //Document document = new Document();
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationPath, FileMode.Create));
            //document.Open();

            PdfPTable table = new PdfPTable(dataTable.Columns.Count);
            table.WidthPercentage = 100;
            float[] anchoDeColumnas = new float[] { 10f, 20f, 60f, 10f, 10f, 10f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f };
            table.SetWidths(anchoDeColumnas);
            //Set columns names in the pdf file
            for (int k = 0; k < dataTable.Columns.Count; k++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataTable.Columns[k].ColumnName));

                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

                table.AddCell(cell);
            }

            //Add values of DataTable in pdf file
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dataTable.Rows[i][j].ToString()));

                    //Align the cell in the center
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    table.AddCell(cell);
                }
            }
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(table);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" +
                                           "filename=GridViewExport.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                cirugia = Session["Ciru_Session"] as CirugiasClass;
                cirugia.Id = Convert.ToInt32(Session["id_Ciru"] as String);
                if (cirugia.Id != 0)
                {
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
                    cirugia.Observacion = txtobservacion.Text;
                    operador = User.Identity.Name;
                    cirugia.Operador = operador;
                    dao.actualizar_cirugia(cirugia);
                    
                }
                String sql = Session["sql"] as String;
                reader_gridview(sql);
                mp1.Hide();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            mp1.Hide();
        }

    }
}
