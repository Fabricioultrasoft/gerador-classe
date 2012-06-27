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
           
            if(!File.Exists(caminho))
            {
                throw new FileNotFoundException();
            }
        
            StreamWriter streamWriter = new StreamWriter(caminho, true);
            streamWriter.WriteLine(texto);
            streamWriter.Close();
            streamWriter.Dispose();
        }
        public static string FormatPascalCase(string texto)
        {
            if (texto == string.Empty)
                return string.Empty;
            string temp = null;
            string[] palavras = texto.Split('_');
            foreach (string palavra in palavras)
            {
                temp += palavra[0].ToString().ToUpper() + palavra.Substring(1);
                
            }
            return temp;
        }
    }
}
