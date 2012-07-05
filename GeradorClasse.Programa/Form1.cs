using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeradorClasse.Programa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Events

        private void cbxDatabase_Click(object sender, EventArgs e)
        {
            BindCbxDatabase();
        }
        private void btnTestar_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao(txtServidor.Text, cbxDatabase.Text, txtUsuario.Text, txtSenha.Text);
            if (conexao.TestarConexao())
                MessageBox.Show("Conexão feita com sucesso!");
            else
                MessageBox.Show("Não foi possivel fazer a conexão");
        }

        private void ckbPrefixo_CheckedChanged(object sender, EventArgs e)
        {
            txtPrefixo.Enabled = !ckbPrefixo.Checked;
        }

        private void btnGerarEntidades_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Binds
        private void BindCbxDatabase()
        {
            cbxDatabase.Items.Clear();
            foreach (Database objDatabase in GetDatabases())
            {
                cbxDatabase.Items.Add(objDatabase.Nome);
            }
        }



        #endregion

        private List<Database> GetDatabases()
        {
            Database database = new Database();
            return database.GetDatabases(txtServidor.Text, txtUsuario.Text, txtSenha.Text);
        }

        private void btnGerarEntidades_Click_1(object sender, EventArgs e)
        {
            Tabela tabela = new Tabela();
            try
            {
                progressBar.Value = 0;
                List<Tabela> lstTabela = tabela.GetTablesFromDatabase(txtServidor.Text, cbxDatabase.Text, txtUsuario.Text, txtSenha.Text);
                progressBar.Maximum = lstTabela.Count;
                progressBar.Step = 1;
                foreach (Tabela objTabela in lstTabela)
                {
                    progressBar.PerformStep();
                    objTabela.GetColunas(txtServidor.Text, cbxDatabase.Text, txtUsuario.Text, txtSenha.Text);
                    GeradorEntidades geradorEntidade = new GeradorEntidades(ckbPrefixo.Checked, txtPrefixo.Text, objTabela);
                }
                MessageBox.Show("Classes criadas com sucesso");
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void ckbUsaNamespace_CheckedChanged(object sender, EventArgs e)
        {
            txtNamespace.Enabled = ckbUsaNamespace.Enabled;
        }

       






    }
}
