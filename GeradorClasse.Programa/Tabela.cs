using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeradorClasse.Programa
{
    public class Tabela
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private List<Colunas> colunas;

        public List<Colunas> Colunas
        {
            get { return colunas; }
            set { colunas = value; }
        }
    }
}
