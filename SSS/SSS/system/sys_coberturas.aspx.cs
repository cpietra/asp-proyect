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
    public partial class sys_coberturas : System.Web.UI.Page
    {
        private CoberturasClass cobertura = new CoberturasClass();
        private DAO dao = new DAO();
        private String operador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                reader_gridview();
            }
        }

        private void reader_gridview()
        {

            GridView1.DataSource = dao.GetData("Select * FROM coberturas");
            GridView1.DataBind();
            //GridView1.Columns[7].Visible = false;

        }

        private void clear_fieds()
        {
            txtCodigo.Text = "";
            txtCobertura.Text = "";
            Button1.Enabled = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            var colsNoVisible = GridView1.DataKeys[row.RowIndex].Values;
            cobertura.Id = (Int32)colsNoVisible[0];
            if (row.Cells[2].Text != "" && row.Cells[2].Text.IndexOf("nbsp;") == -1)
            {
                cobertura.Codigo = row.Cells[2].Text;
            }
            else
            {
                cobertura.Codigo = "";
            }
            if (row.Cells[3].Text != "" && row.Cells[3].Text.IndexOf("nbsp;") == -1)
            {
                cobertura.Cobertura = row.Cells[3].Text;
            }
            else
            {
                cobertura.Cobertura = "";
            }
            txtCodigo.Text = cobertura.Codigo;
            txtCobertura.Text = cobertura.Cobertura;
            cobertura.Operador = User.Identity.Name;
            Session["cober_session"] = cobertura;
            Button1.Enabled = false;
            Button2.Enabled = true;
            Button3.Enabled = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                cobertura = new CoberturasClass();
                cobertura.Codigo = txtCodigo.Text;
                cobertura.Cobertura = txtCobertura.Text;
                operador = User.Identity.Name;
                cobertura.Operador = operador;
                String id_cobertura = dao.create_cobertura(cobertura);
                cobertura.Id = Convert.ToInt32(id_cobertura);
                clear_fieds();
                reader_gridview();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                cobertura = Session["cober_session"] as CoberturasClass;
                cobertura.Codigo = txtCodigo.Text;
                cobertura.Cobertura = txtCobertura.Text;
                operador = User.Identity.Name;
                cobertura.Operador = operador;
                dao.actualizar_cobertura(cobertura);
                clear_fieds();
                reader_gridview();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CoberturasClass cobertura = new CoberturasClass();
            cobertura = Session["cober_session"] as CoberturasClass;
            dao.borrar_cobertura(cobertura.Id);
            clear_fieds();
            reader_gridview();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            clear_fieds();
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