using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1
{
    class ErrorA
    {
        private String error;

        public String Error
        {
          get { return error; }
          set { error = value; }
        }

        private String tipo;

        public String Tipo
        {
          get { return tipo; }
          set { tipo = value; }
        }

        private String descripcion;

        public String Descripcion
        {
          get { return descripcion; }
          set { descripcion = value; }
        }

        private int fila;

        public int Fila
        {
            get { return fila; }
            set { fila = value; }
        }

        private int column;

        public int Columna
        {
            get { return columna; }
            set { columna = value; }
        }

        public ErrorA(String error, String tipo, String descripcion, int fila, int columna)
        {
            this.error = error;
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.fila = fila;
            this.columna = columna;
        }


    }
}
