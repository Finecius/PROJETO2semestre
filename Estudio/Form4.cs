﻿using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        string id;

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            id = maskedTextBox1.Text;

            Aluno aluno = new Aluno(id);
            if (e.KeyChar == 13)
            {
                if (aluno.consultarAluno())
                {
                    if (aluno.excluirAluno())
                    {
                        MessageBox.Show("Aluno Excluído");

                    }
                    else
                        MessageBox.Show("Erro na exclusão");
                }
                else
                    MessageBox.Show("Erro na verificação");

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno a = new Aluno(maskedTextBox1.Text);
            if (a.consultarAluno())
            {
                if (a.excluirAluno())
                    MessageBox.Show("Aluno excluído");
                else
                    MessageBox.Show("Erro na exclusão");
            }
            else
                MessageBox.Show("Erro na verificação");
        }
    }
}
