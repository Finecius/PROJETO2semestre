using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            Modalidade con_mod = new Modalidade();

            MySqlDataReader r = con_mod.consultartodasModal();
            while (r.Read())
                listBox1.Items.Add(r["descricaoModalidade"].ToString());
            DAOConexao.con.Close();

        }
        List<Modalidade> listaModalidade = new List<Modalidade>();



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Selecione uma modalidade!");
            }
            else
            {
                int idModalidadeEscolhida = 0;
                String mod = textBox1.Text;
                String professor = textBox2.Text;
                String dia = textBox3.Text;
                String hora = maskedTextBox1.Text;



                Modalidade modalidadeEscolhida = new Modalidade(mod);
                MySqlDataReader r = modalidadeEscolhida.consultartodasModal();

                while (r.Read())
                {
                    string descricao = r["descricaoModalidade"].ToString();
                    float preco = (float)r["precoModalidade"];
                    int qtde_alunos = (int)r["qtdeAlunos"];
                    int qtde_aulas = (int)r["qtdeAulas"];
                    int id = (int)r["idEstudio_Modalidade"];
                    Modalidade modalidade = new Modalidade(id, descricao, preco, qtde_alunos, qtde_aulas);

                    listaModalidade.Add(modalidade);
                }

                DAOConexao.con.Close();

                idModalidadeEscolhida = listaModalidade[listBox1.SelectedIndex].Id;

                Turma turma = new Turma(idModalidadeEscolhida, professor, dia, hora);
                if (turma.verificaTurma() == true)
                {
                    if (turma.atualizarTurma(textBox1.Text))
                        MessageBox.Show("Turma atualizada");
                    else
                        MessageBox.Show("Erro!");
                }
                else
                {
                    MessageBox.Show("Erro durante a verificação!");
                }
            }



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";


            String modalidadeescolhida = listBox1.SelectedItem.ToString();
            textBox1.Text = modalidadeescolhida;

            string a = textBox1.Text;
            Modalidade modal = new Modalidade(a);
            MySqlDataReader r = modal.consultarModal();



            r.Read();

            int id = (int)r["idEstudio_Modalidade"];




            DAOConexao.con.Close();

            Turma turma = new Turma(id);
            MySqlDataReader h = turma.consultarTurma();

            while (h.Read())
            {


                textBox2.Text = h["professorTurma"].ToString();
                textBox3.Text = h["diasemanaTurma"].ToString();
                maskedTextBox1.Text = h["horaTurma"].ToString();
                textBox4.Text = h["nalunosmatriculadosTurma"].ToString();
            }


            DAOConexao.con.Close();

        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }
    }
}
