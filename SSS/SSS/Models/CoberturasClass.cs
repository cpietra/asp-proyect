using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSS.Models
{
    public class CoberturasClass
    {
        private int id;
        private String codigo;
        private String cobertura;
        private String operador;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public String Cobertura
        {
            get { return cobertura; }
            set { cobertura = value; }
        }

        public String Operador
        {
            get { return operador; }
            set { operador = value; }
        }
    }
}