using System;
using Npgsql;
using System.Data;
using SSS.Model;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections;

namespace SSS.Models
{
    public class DAO
    {
        private conexion con = new conexion();
        private NpgsqlCommand pgcommand;

        public DataTable GetData(String sQuery)
        {

            DataTable ourDataTable = null;

            try
            {
                NpgsqlConnection conn = con.connections();
                ourDataTable = new DataTable();
                Npgsql.NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                ourAdapter.SelectCommand = new NpgsqlCommand(sQuery, conn);
                ourAdapter.Fill(ourDataTable);
            }
            catch (Exception ex)
            {
                //Response.Write(ex.ToString());
            }

            return ourDataTable;

        }

        public void borrar_cirugia(int id)
        {
            String erase = "delete FROM cirugias WHERE id = " + id;
            Ejecutar(erase);
        }

        private void Ejecutar(String sql)
        {
            NpgsqlConnection conn = con.connections();
            conn.Open();
            pgcommand = new NpgsqlCommand(sql, conn);
            pgcommand.ExecuteNonQuery();
            conn.Close();
        }

        public String create_cirugia(CirugiasClass cirugia)
        {
            String insert = "INSERT INTO cirugias (fecha, paciente, laboratoriop, preecg, prerx, arcoc, fechaint, fechacx, cirujano, diagnostico, monitoreo, horario, agrupa, unidadesh, reservahab, quirofanon, ambulatorio, recuperacion, operador, cobertura, observacion) "
                        + "VALUES (@fecha, @paciente, @laboratoriop, @preecg, @prerx, @arcoc, @fechaint, @fechacx, @cirujano, @diagnostico, @monitoreo, @horario, @agrupa, @unidadesh, @reservahab, @quirofanon, @ambulatorio, @recuperacion, @operador, @cobertura, @observacion);select currval('cirugias_id_seq');";
            NpgsqlConnection conn = con.connections();
            conn.Open();
            pgcommand = new NpgsqlCommand(insert, conn);
            pgcommand.Parameters.AddWithValue("@fecha", cirugia.Fecha);
            pgcommand.Parameters.AddWithValue("@paciente", cirugia.Paciente);
            pgcommand.Parameters.AddWithValue("@laboratoriop", cirugia.Laboratoriop);
            pgcommand.Parameters.AddWithValue("@fechaint", cirugia.Fechaint);
            pgcommand.Parameters.AddWithValue("@fechacx", cirugia.Fechacx);
            pgcommand.Parameters.AddWithValue("@cirujano", cirugia.Cirujano);
            pgcommand.Parameters.AddWithValue("@diagnostico", cirugia.Diagnostico);
            pgcommand.Parameters.AddWithValue("@monitoreo", cirugia.Monitoreo);
            pgcommand.Parameters.AddWithValue("@horario", cirugia.Horario);
            pgcommand.Parameters.AddWithValue("@preecg", cirugia.Preecg);
            pgcommand.Parameters.AddWithValue("@prerx", cirugia.Prerx);
            pgcommand.Parameters.AddWithValue("@arcoc", cirugia.Arcoc);
            pgcommand.Parameters.AddWithValue("@agrupa", cirugia.Agrupa);
            pgcommand.Parameters.AddWithValue("@unidadesh", cirugia.Unidadesh);
            pgcommand.Parameters.AddWithValue("@reservahab", cirugia.Reservahab);
            pgcommand.Parameters.AddWithValue("@quirofanon", cirugia.Quirofanon);
            pgcommand.Parameters.AddWithValue("@ambulatorio", cirugia.Ambulatorio);
            pgcommand.Parameters.AddWithValue("@recuperacion", cirugia.Recuperacion);
            pgcommand.Parameters.AddWithValue("@operador", cirugia.Operador);
            pgcommand.Parameters.AddWithValue("@cobertura", cirugia.Cobertura);
            pgcommand.Parameters.AddWithValue("@observacion", cirugia.Observacion);
            String id_cirugia = (String)pgcommand.ExecuteScalar().ToString();
            conn.Close();
            return id_cirugia;
        }

        public void actualizar_cirugia(CirugiasClass cirugia)
        {
            String insert = "UPDATE cirugias SET fecha = @fecha, paciente = @paciente, laboratoriop = @laboratoriop, preecg = @preecg, prerx = @prerx, arcoc = @arcoc, fechaint = @fechaint, fechacx = @fechacx, cirujano = @cirujano,"
                + " diagnostico = @diagnostico, monitoreo = @monitoreo, horario = @horario, agrupa = @agrupa, unidadesh = @unidadesh, reservahab = @reservahab, quirofanon = @quirofanon, ambulatorio = @ambulatorio, recuperacion = @recuperacion, operador = @operador, cobertura = @cobertura, observacion = @observacion WHERE id = " + cirugia.Id;
            NpgsqlConnection conn = con.connections();
            conn.Open();
            pgcommand = new NpgsqlCommand(insert, conn);
            pgcommand.Parameters.AddWithValue("@fecha", cirugia.Fecha);
            pgcommand.Parameters.AddWithValue("@paciente", cirugia.Paciente);
            pgcommand.Parameters.AddWithValue("@laboratoriop", cirugia.Laboratoriop);
            pgcommand.Parameters.AddWithValue("@fechaint", cirugia.Fechaint);
            pgcommand.Parameters.AddWithValue("@fechacx", cirugia.Fechacx);
            pgcommand.Parameters.AddWithValue("@cirujano", cirugia.Cirujano);
            pgcommand.Parameters.AddWithValue("@diagnostico", cirugia.Diagnostico);
            pgcommand.Parameters.AddWithValue("@monitoreo", cirugia.Monitoreo);
            pgcommand.Parameters.AddWithValue("@horario", cirugia.Horario);
            pgcommand.Parameters.AddWithValue("@preecg", cirugia.Preecg);
            pgcommand.Parameters.AddWithValue("@prerx", cirugia.Prerx);
            pgcommand.Parameters.AddWithValue("@arcoc", cirugia.Arcoc);
            pgcommand.Parameters.AddWithValue("@agrupa", cirugia.Agrupa);
            pgcommand.Parameters.AddWithValue("@unidadesh", cirugia.Unidadesh);
            pgcommand.Parameters.AddWithValue("@reservahab", cirugia.Reservahab);
            pgcommand.Parameters.AddWithValue("@quirofanon", cirugia.Quirofanon);
            pgcommand.Parameters.AddWithValue("@ambulatorio", cirugia.Ambulatorio);
            pgcommand.Parameters.AddWithValue("@recuperacion", cirugia.Recuperacion);
            pgcommand.Parameters.AddWithValue("@operador", cirugia.Operador);
            pgcommand.Parameters.AddWithValue("@cobertura", cirugia.Cobertura);
            pgcommand.Parameters.AddWithValue("@observacion", cirugia.Observacion);
            pgcommand.ExecuteScalar();
            conn.Close();
        }

        public String create_cobertura(CoberturasClass cobertura)
        {
            String insert = "INSERT INTO coberturas (codigo, cobertura, operador) "
                        + "VALUES (@codigo, @cobertura, @operador);select currval('coberturas_id_seq');";
            NpgsqlConnection conn = con.connections();
            conn.Open();
            pgcommand = new NpgsqlCommand(insert, conn);
            pgcommand.Parameters.AddWithValue("@codigo", cobertura.Codigo);
            pgcommand.Parameters.AddWithValue("@cobertura", cobertura.Cobertura);
            pgcommand.Parameters.AddWithValue("@operador", cobertura.Operador);
            String id_cobertura = (String)pgcommand.ExecuteScalar().ToString();
            conn.Close();
            return id_cobertura;
        }

        public void actualizar_cobertura(CoberturasClass cobertura)
        {
            String insert = "UPDATE coberturas SET codigo = @codigo, cobertura = @cobertura, operador = @operador WHERE id = " + cobertura.Id;
            NpgsqlConnection conn = con.connections();
            conn.Open();
            pgcommand = new NpgsqlCommand(insert, conn);
            pgcommand.Parameters.AddWithValue("@codigo", cobertura.Codigo);
            pgcommand.Parameters.AddWithValue("@cobertura", cobertura.Cobertura);
            pgcommand.Parameters.AddWithValue("@operador", cobertura.Operador);
            pgcommand.ExecuteScalar();
            conn.Close();
        }

        public void borrar_cobertura(int id)
        {
            String erase = "delete FROM coberturas WHERE id = " + id;
            Ejecutar(erase);
        }

        /*public String create_user(UsuariosClass usuario)
        {
            String insert = "INSERT INTO users (username, password, nivel) "
                        + "VALUES (@username, @password, @nivel);select currval('users_id_seq');";
            NpgsqlConnection conn = con.connections();
            conn.Open();
            pgcommand = new NpgsqlCommand(insert, conn);
            pgcommand.Parameters.AddWithValue("@username", usuario.Username);
            pgcommand.Parameters.AddWithValue("@password", usuario.Password);
            pgcommand.Parameters.AddWithValue("@nivel", usuario.Nivel);
            String id_user = (String)pgcommand.ExecuteScalar().ToString();
            conn.Close();
            return id_user;
        }
        public void update_user(UsuariosClass usuario)
        {
            String insert = "UPDATE users SET username = @username, password = @password, nivel = @nivel) WHERE id = " + usuario.Id;
            NpgsqlConnection conn = con.connections();
            conn.Open();
            pgcommand = new NpgsqlCommand(insert, conn);
            pgcommand.Parameters.AddWithValue("@username", usuario.Username);
            pgcommand.Parameters.AddWithValue("@password", usuario.Password);
            pgcommand.Parameters.AddWithValue("@nivel", usuario.Nivel);
            pgcommand.ExecuteScalar();
            conn.Close();
        }

        public void borrar_user(int id)
        {
            String erase = "delete FROM users WHERE id = " + id;
            Ejecutar(erase);
        }

        public void readexcelNPOI(String filename)
        {
            FileStream files = new FileStream(filename, FileMode.Open, FileAccess.Read);
            ISheet sheet; //Create the ISheet object to read the sheet cell values  
            var fileExt = Path.GetExtension(filename); //get the extension of uploaded excel file  
            if (fileExt == ".xls")
            {
                HSSFWorkbook hssfwb = new HSSFWorkbook(files); //HSSWorkBook object will read the Excel 97-2000 formats  
                sheet = hssfwb.GetSheetAt(0); //get first Excel sheet from workbook  
            }
            else
            {
                XSSFWorkbook hssfwb = new XSSFWorkbook(files); //XSSFWorkBook will read 2007 Excel format  
                sheet = hssfwb.GetSheetAt(0); //get first Excel sheet from workbook   
            }

            IRow headerRow = sheet.GetRow(3);
            IEnumerator rows = sheet.GetRowEnumerator();
            int colCount = 14;
            int rowCount = sheet.LastRowNum;
            IRow row;
            int reg = 0;
            CirugiasClass cirugia = new CirugiasClass();

            bool skipReadingHeaderRow = rows.MoveNext();
            while (rows.MoveNext())
            {
                cirugia = new CirugiasClass();
                if (fileExt == ".xls")
                {
                    row = (HSSFRow)rows.Current;

                } else
                {
                    row = (XSSFRow)rows.Current;
                }

                for (int i = 0; i < colCount; i++)
                {
                    ICell cell = row.GetCell(i);
                    if (cell !=null)
                    {
                        if (cell.CellType == CellType.String || cell.CellType == CellType.Blank)
                        {
                            string value = row.GetCell(i).StringCellValue;
                            switch (i)
                            {
                                case 1:
                                    if (value != null)
                                    {
                                        cirugia.Paciente = value;
                                    }
                                    break;
                                case 2:
                                    if (value != null)
                                    {
                                        cirugia.Laboratoriop = value;
                                    }
                                    break;
                                case 3:
                                    if (value != null)
                                    {
                                        if (value.Equals("X"))
                                        {
                                            cirugia.Preecg = true;
                                        }
                                        else
                                        {
                                            if (!value.Equals("X"))
                                            {
                                                cirugia.Preecg = false;
                                            }
                                        }
                                    }
                                    break;
                                case 4:
                                    if (value != null)
                                    {
                                        if (value.Equals("X"))
                                        {
                                            cirugia.Prerx = true;
                                        }
                                        else
                                        {
                                            if (!value.Equals("X"))
                                            {
                                                cirugia.Prerx = false;
                                            }
                                        }
                                    }
                                    break;
                                case 5:
                                    if (value != null)
                                    {
                                        cirugia.Monitoreo = value;
                                    }
                                    break;
                                case 6:
                                    if (value != null)
                                    {
                                        if (value.Equals("X"))
                                        {
                                            cirugia.Arcoc = true;
                                        }
                                        else
                                        {
                                            if (!value.Equals("X"))
                                            {
                                                cirugia.Arcoc = false;
                                            }
                                        }
                                    }
                                    break;
                                case 7:
                                    if (value != null)
                                    {
                                        cirugia.Hemoterapia = value;
                                    }
                                    break;
                                case 8:
                                    if (value != null)
                                    {
                                        cirugia.Reservah = value;
                                    }
                                    else
                                    {
                                        cirugia.Reservah = "";
                                    }
                                    break;
                                case 11:
                                    if (value != null)
                                    {
                                        cirugia.Horario = value;
                                    }
                                    else
                                    {
                                        cirugia.Horario = "";
                                    }
                                    break;
                                case 12:
                                    if (value != null)
                                    {
                                        cirugia.Medico = value;
                                    }
                                    else
                                    {
                                        cirugia.Medico = "";
                                    }
                                    break;
                                case 13:
                                    if (value != null)
                                    {
                                        cirugia.Diagnostico = value;
                                    }
                                    else
                                    {
                                        cirugia.Diagnostico = "";
                                    }
                                    break;
                            }
                        }
                        else if (cell.CellType == CellType.Numeric)
                        {
                            double value = row.GetCell(i).NumericCellValue;
                            switch (i)
                            {
                                case 0:
                                    if (value != 0)
                                    {
                                        cirugia.Fecha = DateTime.FromOADate(value);
                                    }
                                    break;
                                case 9:
                                    if (value != 0)
                                    {
                                        cirugia.Fechaint = DateTime.FromOADate(value);
                                    }
                                    break;
                                case 10:
                                    if (value != 0)
                                    {
                                        cirugia.Fechacx = DateTime.FromOADate(value);
                                    }
                                    break;
                                case 11:
                                    if (value != 0)
                                    {
                                        cirugia.Horario = value.ToString();
                                    }
                                    else
                                    {
                                        cirugia.Horario = "";
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                        else
                        {
                            //U Can Handel Boolean, Formula, Errors
                        }
                    }
                }
                if(!cirugia.Fecha.Equals(DateTime.MinValue) && !cirugia.Fechaint.Equals(DateTime.MinValue) && !cirugia.Fechacx.Equals(DateTime.MinValue))
                {
                    if (cirugia.Horario.Equals(null))
                    {
                        cirugia.Horario = "";
                    }
                    if (cirugia.Reservah.Equals(null))
                    {
                        cirugia.Reservah = "";
                    }
                    if (cirugia.Laboratoriop.Equals(null))
                    {
                        cirugia.Laboratoriop = "";
                    }
                    if (cirugia.Hemoterapia.Equals(null))
                    {
                        cirugia.Hemoterapia = "";
                    }
                    if (cirugia.Monitoreo.Equals(null))
                    {
                        cirugia.Monitoreo = "";
                    }
                    if (cirugia.Diagnostico.Equals(null))
                    {
                        cirugia.Diagnostico = "";
                    }
                    reg++;
                    create_cirugia(cirugia);
                }
                
            }

            sheet = null;

        }*/

    }
}