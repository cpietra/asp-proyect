using System;

namespace SSS.Model
{
    public class CirugiasClass
    {
        private int id;
        private DateTime fecha;
        private String paciente;
        private Boolean laboratoriop;
        private Boolean agrupa;
        private DateTime fechaint;
        private DateTime fechacx;
        private String cirujano;
        private String diagnostico;
        private Boolean monitoreo;
        private String horario;
        private Boolean preecg;
        private Boolean prerx;
        private Boolean arcoc;
        private Boolean reservahab;
        private Boolean quirofano;
        private Boolean ambulatorio;
        private Boolean recuperacion;
        private String operador;
        private String cobertura;
        private int quirofanon;
        private String observacion;

        private int unidadesh;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public String Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public Boolean Laboratoriop
        {
            get { return laboratoriop; }
            set { laboratoriop = value; }
        }

        public Boolean Agrupa
        {
            get { return agrupa; }
            set { agrupa = value; }
        }

        public DateTime Fechaint
        {
            get { return fechaint; }
            set { fechaint = value; }
        }

        public DateTime Fechacx
        {
            get { return fechacx; }
            set { fechacx = value; }
        }

        public String Cirujano
        {
            get { return cirujano; }
            set { cirujano = value; }
        }

        public String Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        public Boolean Monitoreo
        {
            get { return monitoreo; }
            set { monitoreo = value; }
        }

        public String Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public Boolean Preecg
        {
            get { return preecg; }
            set { preecg = value; }
        }

        public Boolean Prerx
        {
            get { return prerx; }
            set { prerx = value; }
        }

        public Boolean Arcoc
        {
            get { return arcoc; }
            set { arcoc = value; }
        }

        public int Unidadesh
        {
            get { return unidadesh; }
            set { unidadesh = value; }
        }

        public Boolean Reservahab
        {
            get { return reservahab; }
            set { reservahab = value; }
        }

        public Boolean Quirofano
        {
            get { return quirofano; }
            set { quirofano = value; }
        }

        public Boolean Ambulatorio
        {
            get { return ambulatorio; }
            set { ambulatorio = value; }
        }

        public Boolean Recuperacion
        {
            get { return recuperacion; }
            set { recuperacion = value; }
        }

        public String Operador
        {
            get { return operador; }
            set { operador = value; }
        }

        public String Cobertura
        {
            get { return cobertura; }
            set { cobertura = value; }
        }

        public int Quirofanon
        {
            get { return quirofanon; }
            set { quirofanon = value; }
        }

        public String Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
    }
}