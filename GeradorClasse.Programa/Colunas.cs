using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeradorClasse.Programa
{
    public class Colunas
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
