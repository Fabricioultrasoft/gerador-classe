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

        public GeradorEntidades(bool usaPrefixo, string prefixo, Tabela tabela)
        {
            this.usaPrefixo = usaPrefixo;
            this.prefixo = prefixo;
            GerarArquivoClasse(tabela);
        }
        public GeradorEntidades(Tabela tabela)
        {
            GerarArquivoClasse(tabela);
        }

        public void GerarArquivoClasse(Tabela tabela)
        {
            string classe = GerarClasse(tabela);
            Util.WriterFile(@"C:\classes\" + Util.FormatPascalCase(tabela.Nome) + ".cs", classe);
        }
        private string GerarReferencias()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;\n");
            return sb.ToString();
        }
        private string GerarClasse(Tabela tabela)
        {
            StringBuilder sb = new StringBuilder();
            string propriedades = GerarPropriedades(tabela.Colunas);
            string metodos = GerarMetodosEncapsulados(tabela.Colunas);

            sb.AppendLine(String.Format("\tpublic class {0}", Util.FormatPascalCase(tabela.Nome)));
            sb.AppendLine("\t{");
            sb.AppendLine(propriedades);
            sb.AppendLine(metodos);
            sb.AppendLine("\t}");
            return sb.ToString();
        }
        private string GerarPropriedades(List<Colunas> colunas)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Colunas coluna in colunas)
            {
                if (usaPrefixo)
                {
                    if (coluna.Nome.StartsWith(prefixo.ToUpper()))
                    {
                        if (coluna.IsPk)
                        {
                            sb.AppendLine(String.Format("\t\tprivate {0} {1};", Util.ConvertToCSharpTypes(coluna.Tipo), Util.FormatPkColumnName(coluna.Nome, prefixo)));
                        }
                        else
                        {
                            string nome = coluna.Nome.Substring(prefixo.Length);
                            sb.AppendLine(String.Format("\t\tprivate {0} {1};", Util.FormatPascalCase(nome), Util.FormatCamelCase(nome)));
                        }
                    }
                    else
                    {

                        sb.AppendLine(String.Format("\t\tprivate {0} {1};", Util.ConvertToCSharpTypes(coluna.Tipo), Util.FormatCamelCase(coluna.Nome)));
                    }
                }
                // Implementar codigo para quando não usar

            }
            return sb.ToString();
        }

        private string GerarMetodosEncapsulados(List<Colunas> colunas)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Colunas coluna in colunas)
            {
                if (usaPrefixo)
                {
                    if (coluna.Nome.StartsWith(prefixo.ToUpper()))
                    {
                        string nome = coluna.Nome.Substring(prefixo.Length);
                        sb.AppendLine(String.Format("\t\tpublic {0} {1}", Util.FormatPascalCase(nome), Util.FormatPascalCase(nome)));
                        sb.AppendLine("\t\t{");
                        sb.AppendLine(String.Format("\t\t\tget {{ return {0}; }}", Util.FormatCamelCase(nome)));
                        sb.AppendLine(String.Format("\t\t\tset {{ {0} = value; }}", Util.FormatCamelCase(nome)));
                        sb.AppendLine("\t\t}");
                    }
                    else
                    {
                        sb.AppendLine(String.Format("\t\tpublic {0} {1};", coluna.Tipo, Util.FormatPascalCase(coluna.Nome)));
                        sb.AppendLine("\t\t{");
                        sb.AppendLine(String.Format("\t\t\tget {{ return {0}; }}", Util.FormatCamelCase(coluna.Nome)));
                        sb.AppendLine(String.Format("\t\t\tset {{ {0} = value; }}", Util.FormatCamelCase(coluna.Nome)));
                        sb.AppendLine("\t\t}");
                    }
                }
                // Implementar codigo para quando não usar o prefixo

            }
            return sb.ToString();
        }

    }
}
