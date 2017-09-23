using SSS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSS.system
{
    public partial class sys_import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                //try
                //{
                    if (FileUploadControl.PostedFile.ContentType == "application/vnd.ms-excel" ||
                        FileUploadControl.PostedFile.ContentType == "application/excel" ||
                        FileUploadControl.PostedFile.ContentType == "application/x-msexcel" ||
                        FileUploadControl.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 1024000)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            if (File.Exists(filename))
                            {
                                File.Delete(filename);
                            }
                            FileUploadControl.SaveAs(Server.MapPath("~/Uploads/") + filename);
                            StatusLabel.Text = "Estado de la Carga: Archivo subido con exito...";
                            String pathfilename = Server.MapPath("~/Uploads/") + filename;
                            DAO dao = new DAO();
                            //dao.readexcelNPOI(pathfilename);

                        }
                        else
                            StatusLabel.Text = "Estado de la Carga: El archivo tiene que ser menos de 1 MB!";
                    }
                    else
                        StatusLabel.Text = "Estado de la Carga: ¡Sólo se aceptan archivos XLS o XLSX!";
                //}
                //catch (Exception ex)
                //{
                  //  StatusLabel.Text = "Estado de la Carga: No se pudo cargar el archivo. El siguiente error ha ocurrido: " + ex.Message;
                //}
            }
        }


    }
}