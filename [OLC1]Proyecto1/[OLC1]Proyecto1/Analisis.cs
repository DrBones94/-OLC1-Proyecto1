using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using 

namespace _OLC1_Proyecto1
{
  class Analisis
  {
    static List<Token> LTokens = new List<Token>(); //Lista de tokens a enviar en el Analizador Sintactico.
    static List<ErrorA> LError = new List<ErrorA>(); //Lista de errores encontrados 
    static int posicion;
    static Type preanalisis;



    /*Analizador Lexico*/
    public void A_Lexico(String entrada)
    {
      String[] entradaA = entrada.Split('\n');
      int caracter = 0; //ASCII del caracter.
      int estado = 0;
      bool isChar = true; //Bandera para saber si es solo un caracter
      char car;
      String lexema = "";

      for(int i = 0; i <= entradaA.Length - 1; i++)
      {
        String linea = entradaA[i] + "\n";

        for(int j = 0; j <= linea.Length - 1; j++)
        {
          caracter = (int)linea.ElementAt(j);
          car = linea.ElementAt(j);

          switch(estado)
          {
            case 0:
              if(caracter == 32 || caracter == 9 || caracter == 10 || caracter == 13){ //Espacio en blanco
                estado = 0;
              }else if(caracter == 209 || caracter == 241){ //Letra ñ y Ñ
                estado = 1;
                lexema += car;
              }else if(65 <= caracter && caracter <= 90){ //Letras Mayusculas
                estado = 1;
                lexema += car;
              }else if(97 <= caracter && caracter <= 122){ //Letras Minusculas
                estado = 1;
                lexema += car;
              }else if(48 <= caracter && caracter <= 57){ //Numeros
                estado = 2;
                lexema += car;
              }else if(caracter == 44){ //Coma ,
                lexema += car;
                Token s = new Token(lexema, Type.coma, "Coma", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 43){ //Signo +
                lexema += car;
                Token s = new Token(lexema, Type.mas, "Signo +", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 42){ //Signo * 
                lexema += car;
                Token s = new Token(lexema, Type.asterisco, "Signo *", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 63){ //Signo ?
                lexema += car;
                Token s = new Token(lexema, Type.interrogacionC, "Signo ?", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 46){ //Punto .
                lexema += car;
                Token s = new Token(lexema, Type.punto, "Punto", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 45){ //Signo -
                estado = 3;
                lexema += car;
              }else if(caracter == 123){ //Corchete Abierto {
                lexema += car;
                Token s = new Token(lexema, Type.corcheteA, "Corchete Abierto", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 125){ //Corchete Cerrado
                lexema += car;
                Token s = new Token(lexema, Type.corcheteC, "Corchete Cerrado", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 166){ //Pipe |
                lexema += car;
                Token s = new Token(lexema, Type.or, "OR", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 129){ //Separador ~
                lexema += car;
                Token s = new Token(lexema, Type.separador, "Separador ~", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 58){ //Dos Puntos :
                lexema += car;
                Token s = new Token(lexema, Type.dosP, "Dos Puntos", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 59){ //Punto y Coma ;
                lexema += car;
                Token s = new Token(lexema, Type.puntoC, "Punto y Coma", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else if(caracter == 47){ // Simbolo /
                estado = 5;
                lexema += car;
              }else if(caracter == 60){ // Simbolo <
                estado = 7;
                lexema += car;
              }else if(caracter == 34){ // Simbolo "
                estado = 10;
                lexema += car;
              }else if(caracter > 32 || caracter <= 125){
                lexema += car;
                Token s = new Token(lexema, Type.caracter, "Caracter", i, j);
                LTokens.Add(s);
                estado = 0;
                lexema = "";
              }else{
                lexema += car;
                ErrorA e = new ErrorA(lexema, "Error Léxico", "Carácter Desconocido", i, j);
                LError.Add(e);
                estado = 0;
                lexema = "";
              }
            break;
            //ID
            case 1:
              if(65 <= caracter && caracter <= 90){ //Letras Mayusculas
                estado = 1;
                isChar = false;
                lexema += car;
              }else if(caracter == 241 || caracter == 209){// ñ y Ñ
                estado = 1;
                isChar = false;
                lexema += car;
              }else if(97 < = caracter && caracter <= 57){ //Letras minusculas
                estado = 1;
                isChar = false;
                lexema += car;
              }else if(48 <= caracter && caracter <= 57){ //Numeros
                estado = 1;
                isChar = false;
                lexema += car;
              }else if(caracter == 95){ //Guion Bajo _
                estado = 1;
                isChar = false;
                lexema += car;
              }else{
                if(lexema.Equals("CONJ")){
                  Token t = new Token(lexema, Type.prConj, "Palabra Reservada", i, j);
                  LTokens.Add(t);
                  lexema = "";
                  estado = 0;
                  isChar = true; //Revisar por que aqui es true.
                  j = j - 1;
                }else{
                  Token t = new Token(lexema, Type.id, "Identificador", i, j);
                  LTokens.Add(t);
                  lexema = "";
                  estado = 0;
                  isChar = true; //Revisar por que aqui es true.
                }
              }
            break;
            //Numero
            case 2:
              if(48 <= caracter && caracter <= 57){ // Números
                estado = 2;
                lexema += car;
              }else{
                Token t = new Token(lexema, Type.numero, "Numero", i, j);
                LTokens.add(t);
                lexema = "";
                estado = 0;
                j = j - 1;
              }
            break;
            //Asignacion ->
            case 3:
              if(caracter == 62){ // Simbolo >
                lexema += car;
                Token s = new Token(lexema, Type.flecha, "Asignacion", i, j);
                LTokens.add(s);
                lexema = "";
                estado = 0;
              }else{
                Token s = new Token(lexema, Type.caracter, "Caracter", i, j);
                LTokens.add(s);
                lexema = "";
                estado = 0;
                j = j - 1;
              }
            break;
            //Inicio de comentarios
            case 5:
              switch (caracter) {
                case 47:
                  //Simbolo /
                  //Comentario de una linea
                  estado = 6;
                  lexema += car;
                  break;
                default:
                  Token s = new Token(lexema, Type.caracter, "Caracter", i, j);
                  LTokens.add(s);
                  lexema = "";
                  estado = 0;
                  j = j - 1;
                  break;
              }
            break;
            //Comentario de una línea
            case 6:
              if(caracter == 10 || caracter == 13){ //Salto de Linea
                Token c = new Token(lexema, Type.comentario, "Comentario L", i, j);
                lexema = "";
                estado = 0;
                j = j - 1;
              }else{
                System.out.println("Caracter: " + caracter);
                estado = 6;
                lexema += car;
              }
            break;
            //Comentario Multilinea
            case 7:
              if(caracter == 33){ //Simbolo !
                estado = 8;
                lexema += car;
              }else{
                Token s = new Token(lexema, Type.caracter, "Caracter", i, j);
                LTokens.add(s);
                lexema = "";
                estado = 0;
                j = j - 1;
              }
            break;
            case 8:
              if(caracter == 33){ //Simbolo !
                estado = 9;
                lexema += car;
              }else{
                estado = 8;
                lexema += car;
              }
            break;
                    
            case 9:
              if(caracter == 62){ //Simbolo >
                lexema += car;
                Token c = new Token(lexema, Type.comentario, "Comentario", i, j);
                lexema = "";
                estado = 0;
              }else{
                estado = 8;
                lexema += car;
              }
            break;
                    
            case 10:
              if(caracter == 34){
                lexema += car;
                Token s = new Token(lexema, Type.cadena, "Cadena", i, j);
                LTokens.add(s);
                lexema = "";
                estado = 0;
              }else{
                lexema += car;
                estado = 10;
              }
            break;
          }
        }
      }
    }

   // //Analizador Sintactico
   // public void A_Sintactico(){
   //   posicion = 0;
   //   preanalisis = LTokens.ElementAt(posicion).Id;

   //   S(); //Simbolo Inicial

   //   if(posicion != LTokens.Count){
   //     ErrorA e = new ErrorA(LTokens.ElementAt(posicion).Lexema, "Error Sintactico", "Se esperaban mas tokens", LTokens.ElementAt(posicion).Fila, LTokens.ElementAt(posicion).Columna);
   //     LError.Add(e);
   //   }else{
   //     //Investigar bien que debe ir en este codigo
   //   }
   // }

   // //Método de Parea
   // public void parea(Type analisis){
   //   if(preanalisis == analisis){
   //     posicion++;

   //     if(posicion == LTokens.Count){
   //       preanalisis = Type.eof;
   //     }else{
   //       preanalisis = LTokens.ElementAt(posicion).Id;
   //     }
   //   }else{
   //     ErrorA e = new ErrorA(LTokens.ElementAt(posicion).Lexema, "Error Sintactico", "Se esperaba idToken" + analisis, LTokens.ElementAt(posicion).Fila, LTokens.ElementAt(posicion).Columna);
   //     LError.Add(e);
   //   }
   // }

   // public void S(){
   //   switch(preanalisis){
   //     case Type.prConj:
   //       CONJUNTOS();
   //       EXPRESIONES();
   //       LEXEMAS();
   //     break;
   //     default:
   //     break;
   //   }
   // }

   // public void CONJUNTOS(){
   //   switch(preanalisis){
   //     case Type.prConj:
   //       parea(Type.prConj);
   //       parea(Type.dosP);
   //       parea(Type.id);
   //       parea(Type.flecha);
   //       EXP();
   //       parea(Type.puntoC);
   //       CONJUNTOSP();
   //     break;
   //     default:
   //       ErrorA e = new ErrorA(LTokens.ElementAt(posicion).Lexema, "Error Sintactico", "Se esperaba CONJ", LTokens.ElementAt(posicion).Fila, LTokens.ElementAt(posicion).Columna);
   //       LError.Add(e);
   //     break;
   //   }
   //  }

   // public void EXP(){
   //   switch(preanalisis){
   //     case Type.asterisco:
          
   //     break;
   //     case Type.mas:
   //     break;
   //     case Type.interrogacionC:
   //     break;
   //     case 
   //   }
   // }

   // public void CONJUNTOSP(){
   //   switch(preanalisis){
   //     case Type.prConj:
   //       parea(Type.prConj);
   //       parea(Type.dosP);
   //       parea(Type.id);
   //       parea(Type.flecha);
   //       EXP();
   //       parea(Type.puntoC);
   //       CONJUNTOSP();
   //     break;
   //     default:
        
   //   }
   // }
   //}
}
