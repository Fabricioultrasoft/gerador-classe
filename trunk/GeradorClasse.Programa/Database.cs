using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace GeradorClasse.Programa
{
    public class Database
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public List<Database> GetDatabases(string servidor, string usuario, string senha)
        {
            Conexao conexao = new Conexao(servidor, usuario, senha);
            MySqlCommand command = new MySqlCommand()
            {
                CommandText = "show databases",
                Connection = conexao.conn
            };
            MySqlDataAdapter da = new MySqlDataAdapter()
            {
                SelectCommand = command
            };
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Database> lstDatabase = new List<Database>();
            foreach (DataRow dr in dt.Rows)
            {
                lstDatabase.Add(new Database()
                {
                    Nome = dr["database"].ToString()
                });
            }
            return lstDatabase;
        }
    }
}
