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
    public partial class Form12 : Form
    {
        List<Modalidade> listaModalidade = new List<Modalidade>();
        List<Turma> listaTurma = new List<Turma>();
        List<Aluno> listaAluno = new List<Aluno>();
        public Form12()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            Modalidade conMod = new Modalidade();
            MySqlDataReader r = conMod.consultartodasModal();
            while (r.Read())
            {
                listBox1.Items.Add(r["descricaoModalidade"].ToString());
            }
            DAOConexao.con.Close();

            Aluno conAlu = new Aluno();
            MySqlDataReader h = conAlu.consultartodosAlunoCompleto();
            while (h.Read())
            {
                listBox2.Items.Add(h["nomeAluno"].ToString());
            }
            DAOConexao.con.Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            
        }
        int idTurma, idModal;
        String idAluno;
        int nalunosmatriculadosTurma;
        int qtde_alunos;
        private void button1_Click(object sender, EventArgs e)
        {
             

            String nomeModal = listBox1.SelectedItem.ToString();
            String nomeAluno = listBox2.SelectedItem.ToString();

          

            Modalidade modalidade = new Modalidade(nomeModal);
            MySqlDataReader r = modalidade.consultarModal();

            while (r.Read())
            {
                idModal = (int)r["idEstudio_Modalidade"];
                string descricao = r["descricaoModalidade"].ToString();
                float preco = (float)r["precoModalidade"];
                qtde_alunos = (int)r["qtdeAlunos"];
                int qtde_aulas = (int)r["qtdeAulas"];
             
                Modalidade modalidade1 = new Modalidade(idModal, descricao, preco, qtde_alunos, qtde_aulas);

                listaModalidade.Add(modalidade1);
            }

            DAOConexao.con.Close();

            Turma turma = new Turma(idModal);
            
            MySqlDataReader h = turma.consultarTurma();
            while (h.Read())
            {
                idTurma = (int)h["idEstudio_Turma"];
                 idModal = (int)h["idModalidade"];
                String professorTurma = h["professorTurma"].ToString();
                String diasemanaTurma = h["diasemanaTurma"].ToString();
                String horaTurma = h["horaTurma"].ToString();
                nalunosmatriculadosTurma = (int)h["nalunosmatriculadosTurma"];

               
                
            }
           
            DAOConexao.con.Close();

            
            Aluno aluno = new Aluno(nomeAluno);
            MySqlDataReader i = aluno.consultarAlunoCompleto();
            while (i.Read())
            {
                idAluno = i["CPFAluno"].ToString();
               
         
            }

            DAOConexao.con.Close();
            
            TurmaAluno cad = new TurmaAluno(idTurma, idAluno,nomeAluno);
            if (nalunosmatriculadosTurma < qtde_alunos)
            {
                if (cad.cadastrarAlunoTurma() && cad.aumentarAlunos())
                {
                    MessageBox.Show("Aluno cadastrado na Turma");
                }
                else
                    MessageBox.Show("Erro ");
            }
            else
                MessageBox.Show("Máximo de alunos já atingido");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
