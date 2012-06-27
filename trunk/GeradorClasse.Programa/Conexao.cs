using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
namespace GeradorClasse.Programa
{
    public class Conexao
    {
        public MySqlConnection conn;
        public Conexao(string servidor, string usuario, string senha)
        {
            conn = new MySqlConnection(string.Format("Persist Security Info=False;server={0};uid={1};pwd={2}", servidor, usuario, senha));
        }
        public Conexao(string servidor, string database, string usuario, string senha)
        {
            conn = new MySqlConnection(string.Format("Persist Security Info=False;server={0};database={1};uid={2};pwd={3}", servidor, database, usuario, senha));
        }
        public void Conectar()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }
        public void Desconectar()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
        public Boolean TestarConexao()
        {
            try
            {
                Conectar();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
