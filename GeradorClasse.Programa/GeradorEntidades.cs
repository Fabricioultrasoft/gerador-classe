using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeradorClasse.Programa
{
    public class GeradorEntidades
    {

        private bool usaPrefixo;
        private string prefixo;

        public string Prefixo
        {
            get { return prefixo; }
            set { prefixo = value; }
        }

        public bool UsaPrefixo
        {
            get { return usaPrefixo; }
            set { usaPrefixo = value; }
        }

        public GeradorEntidades(bool usaPrefixo,string prefixo)
        {
            this.usaPrefixo = usaPrefixo;
            this.prefixo = prefixo;
        }
        public string GerarClasse(string nome)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("\tpublic class {0}", nome));
            sb.AppendLine("\t{");

            sb.AppendLine("\t}");
            return sb.ToString();
        }
        public string GerarPropriedades(List<Colunas> colunas)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Colunas coluna in colunas)
            {
                if (usaPrefixo)
                {
                    if (coluna.nome.Length > prefixo.Length && coluna.nome.Substring(0, prefixo.Length) == prefixo)
                    {
                        string nome = coluna.nome.Substring(prefixo.Length-1);

                        sb.AppendLine(String.Format("\t\tprivate {0} {1};", coluna.tipo, coluna.nome.ToLower()));
                    }
                }
               
            }
            return sb.ToString();
        }
    }
}
