using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace GeradorClasse.Programa
{
    public class Colunas
    {
        private string nome;
        private bool isPk;

        public bool IsPk
        {
            get { return isPk; }
            set { isPk = value; }
        }

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


        public List<Colunas> GetColumnsByTable(string servidor, string database, string usuario, string senha, Tabela tabela)
        {
            Conexao conexao = new Conexao(servidor, database, usuario, senha);

            MySqlCommand command = new MySqlCommand("SHOW COLUMNS FROM " + tabela.Nome, conexao.conn);
            MySqlDataAdapter da = new MySqlDataAdapter()
            {
                SelectCommand = command,

            };
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Colunas> lstColuna = new List<Colunas>();
            foreach (DataRow dr in dt.Rows)
            {
                Colunas objColuna = new Colunas()
                {
                    Nome = dr["Field"].ToString(),
                    Tipo = dr["Type"].ToString().Contains('(') ? dr["Type"].ToString().Substring(0, dr["Type"].ToString().IndexOf('(')) : dr["Type"].ToString(),
                    isPk = dr["Key"].ToString() == "PRI" ? true : false
                };
                lstColuna.Add(objColuna);
            }
            return lstColuna;
        }

    }
}
