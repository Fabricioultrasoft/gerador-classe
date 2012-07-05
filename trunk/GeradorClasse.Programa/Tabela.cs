using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using MySql.Data.MySqlClient;

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

        public List<Tabela> GetTablesFromDatabase(string servidor, string database, string usuario, string senha)
        {
            Conexao conexao = new Conexao(servidor, database, usuario, senha);

            MySqlCommand command = new MySqlCommand("SHOW TABLE STATUS", conexao.conn);
            MySqlDataAdapter da = new MySqlDataAdapter()
            {
                SelectCommand = command,

            };
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Tabela> lstTabela = new List<Tabela>();
            foreach (DataRow dr in dt.Rows)
            {
                Tabela objTabela = new Tabela()
                {
                    Nome = dr[0].ToString()
                };
                lstTabela.Add(objTabela);
            }
            return lstTabela;
        }

        public void GetColunas(string servidor, string database, string usuario, string senha)
        {
            Colunas coluna = new Colunas();
            this.Colunas =  coluna.GetColumnsByTable(servidor, database, usuario, senha, this);
        }
    }
}
