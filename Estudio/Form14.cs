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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            Modalidade con_mod = new Modalidade();

            MySqlDataReader r = con_mod.consultartodasModal();
            while (r.Read())
                comboBox1.Items.Add(r["descricaoModalidade"].ToString());
            DAOConexao.con.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }
        int id;
        int idTurma;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();


            String turmaescolhida = comboBox1.SelectedItem.ToString();



            Modalidade modal = new Modalidade(turmaescolhida);
            MySqlDataReader r = modal.consultarModal();



            while (r.Read())
            {

                id = (int)r["idEstudio_Modalidade"];
            }



            DAOConexao.con.Close();

            Turma turma = new Turma(id);
            MySqlDataReader h = turma.consultarTurma();


            while (h.Read())
            {
                idTurma = (int)h["idEstudio_Turma"];
                textBox1.Text =h["diasemanaTurma"].ToString();
                textBox2.Text = h["horaTurma"].ToString();
                textBox3.Text = h["nalunosmatriculadosTurma"].ToString();
            }
            DAOConexao.con.Close();
            TurmaAluno TA = new TurmaAluno(idTurma);
            MySqlDataReader i = TA.consultarAlunos();

            while (i.Read())
            {
                listBox1.Items.Add(i["nomeAluno"].ToString());
            }



            DAOConexao.con.Close();
        }
    }
    }

