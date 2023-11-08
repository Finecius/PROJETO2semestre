using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            Aluno con_ALN = new Aluno();

            MySqlDataReader r = con_ALN.consultartodosAlunoCompleto();
            while (r.Read())
                listBox1.Items.Add(r["nomeAluno"].ToString());
            DAOConexao.con.Close();
        }
        String id;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCPF.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtTelefone.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtEstado.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";


            String modalidadeescolhida = listBox1.SelectedItem.ToString();
            txtCPF.Text = modalidadeescolhida;

            string a = txtCPF.Text;
            Aluno aln = new Aluno(a);
            MySqlDataReader r = aln.consultarAlunoCompleto();



            while (r.Read()) { 
             id = r["nomeAluno"].ToString();
            }



            DAOConexao.con.Close();

            Aluno turma = new Aluno(id);
            MySqlDataReader h = turma.consultarAlunoCompleto();

            while (h.Read())
            {


                txtCPF.Text = h["CPFAluno"].ToString();
                txtEndereco.Text = h["ruaAluno"].ToString();
                txtBairro.Text = h["bairroAluno"].ToString();
                txtCEP.Text = h["CEPAluno"].ToString();
                txtTelefone.Text = h["telefoneAluno"].ToString();
                txtNumero.Text = h["numeroAluno"].ToString();
                txtComplemento.Text = h["complementoAluno"].ToString();
                txtEstado.Text = h["estadoAluno"].ToString();
                txtCidade.Text = h["cidadeAluno"].ToString();
                txtEmail.Text = h["emailAluno"].ToString();
                
            }


            DAOConexao.con.Close();

        }
    }
}
