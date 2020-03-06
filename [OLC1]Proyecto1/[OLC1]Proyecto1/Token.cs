using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1
{
    class Token
    {
        public enum Type
        {
            id, //Identificador
            flecha, //Asignacion ->
            puntoC, //Punto y coma ;
            dosP, //Dos Puntos :
            punto, //Punto .
            or, //OR |
            interrogacionC, //Interrogacion Cerrado ?
            asterisco, //Asterisco *
            mas, //Mas +
            separador, //Separador ~
            coma, //Coma ,
            prConj, //Palabra reservada CONJ
            caracter, //Caracter
            numero, //Numero
            comentario //Comentario
        }

        private String lexema;

        public String Lexema
        {
            get { return lexema; }
            set { lexema = value; }
        }
        private Type id;

        internal Type Id
        {
            get { return id; }
            set { id = value; }
        }
        private String token;

        public String Token1
        {
            get { return token; }
            set { token = value; }
        }
        private int fila;

        public int Fila
        {
            get { return fila; }
            set { fila = value; }
        }
        private int columna;

        public int Columna
        {
            get { return columna; }
            set { columna = value; }
        }

        public Token(String lexema, Type id, String token, int fila, int columna)
        {
            this.lexema = lexema;
            this.id = id;
            this.token = token;
            this.fila = fila;
            this.columna = columna;
        }


    }
}
