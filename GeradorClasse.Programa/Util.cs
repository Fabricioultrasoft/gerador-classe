using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeradorClasse.Programa
{
    public class Util
    {
        public static void WriterFile(string caminho, string texto)
        {
            StreamWriter streamWriter = new StreamWriter(caminho, false);
            streamWriter.WriteLine(texto);
            streamWriter.Close();
            streamWriter.Dispose();
        }
        public static string FormatPascalCase(string texto)
        {
            texto = texto.ToLower();
            if (texto == string.Empty)
                return string.Empty;
            string temp = null;
            string[] palavras = texto.Split('_');
            foreach (string palavra in palavras)
            {
                if (!string.IsNullOrEmpty(palavra))
                {
                    temp += palavra[0].ToString().ToUpper() + palavra.Substring(1);
                }

            }
            return temp;
        }
        public static string FormatCamelCase(string texto)
        {
            texto = texto.ToLower();
            if (texto == string.Empty)
                return string.Empty;
            string temp = null;
            string[] palavras = texto.Split('_');
            int cont = 0;
            foreach (string palavra in palavras)
            {
                if (!string.IsNullOrEmpty(palavra))
                {
                    if (cont == 0)
                        temp += palavra[0].ToString().ToLower() + palavra.Substring(1);
                    else
                        temp += palavra[0].ToString().ToUpper() + palavra.Substring(1);
                    cont++;
                }
            }
            return temp;
        }

        public static string ConvertToCSharpTypes(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "int": return "int";

                case "varchar": return "string";

                case "char": return "char";

                case "date": return "DateTime";

                case "double": return "double";

                case "text": return "string";

                default: return "NotType";
            }
        }
    }
}
