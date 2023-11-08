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

            MessageBox.Show("Pressione enter no campo de CPF para consultar um CPF!");

            Aluno con_ALN = new Aluno();

            MySqlDataReader r = con_ALN.consultartodosAlunoCompleto();
            while (r.Read()) {
                listBox1.Items.Add(r["CPFAluno"].ToString());
            }
            DAOConexao.con.Close();
        }
        String id;
        String a;
        List<Aluno> listaAL = new List<Aluno>();

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
            a = txtCPF.Text;

            Aluno aln = new Aluno(a);
           MySqlDataReader r = aln.consultarAlunoCompleto();

            while (r.Read())
            {
                id = r["CPFAluno"].ToString();
            }
            DAOConexao.con.Close();
            

            Aluno turma = new Aluno(id);
            MySqlDataReader h = turma.consultartodosAlunoCompleto();

            while (h.Read())
            {
                string nome = h["nomeAluno"].ToString();
                string Endereco = h["ruaAluno"].ToString();
                string bairro = h["bairroAluno"].ToString();
                string cep = h["CEPAluno"].ToString();
                string telefone = h["telefoneAluno"].ToString();
                string numero = h["numeroAluno"].ToString();
                string complemento = h["complementoAluno"].ToString();
                string estado = h["estadoAluno"].ToString();
                string cidade = h["cidadeAluno"].ToString();
                string email = h["emailAluno"].ToString();

                listaAL.Add(new Aluno(nome, Endereco, numero, bairro, complemento, cep, cidade, estado, telefone, email));
            }
            DAOConexao.con.Close();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
                
                    txtNome.Text = listaAL[listBox1.SelectedIndex].getNome().ToString();
                    txtEndereco.Text = listaAL[listBox1.SelectedIndex].getRua().ToString();
                    txtBairro.Text = listaAL[listBox1.SelectedIndex].getBairro().ToString();
                    txtCEP.Text = listaAL[listBox1.SelectedIndex].getCEP().ToString();
                    txtTelefone.Text = listaAL[listBox1.SelectedIndex].getTelefone().ToString();
                    txtNumero.Text = listaAL[listBox1.SelectedIndex].getNumero().ToString();
                    txtComplemento.Text = listaAL[listBox1.SelectedIndex].getComplemento().ToString();
                    txtEstado.Text = listaAL[listBox1.SelectedIndex].getEstado().ToString();
                    txtCidade.Text = listaAL[listBox1.SelectedIndex].getCidade().ToString();
                    txtEmail.Text = listaAL[listBox1.SelectedIndex].getEmail().ToString();

                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                txtBairro.Enabled = false;
                txtCEP.Enabled = false;
                txtTelefone.Enabled = false;
                txtNumero.Enabled = false;
                txtComplemento.Enabled = false;
                txtEstado.Enabled = false;
                txtCidade.Enabled = false;
                txtEmail.Enabled = false;
            }
            
        }
    }