using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class TurmaAluno
    {
        private int idTurmaAluno, idTurma;

        

        private String descricaoModalidade, nomeAluno, idAluno;


        public int IdTurmaAluno { get => idTurmaAluno; set => idTurmaAluno = value; }
        public int IdTurma { get => idTurma; set => idTurma = value; }
    
        public string DescricaoModalidade { get => descricaoModalidade; set => descricaoModalidade = value; }
        public string NomeAluno { get => NomeAluno1; set => NomeAluno1 = value; }
        public string NomeAluno1 { get => nomeAluno; set => nomeAluno = value; }

        public TurmaAluno(int idTurma, String nomeAluno)
        {
         
            this.idTurma = idTurma;
            this.nomeAluno = nomeAluno;
        }

          

        public TurmaAluno(int idTurma, string idAluno, string nomeAluno) : this(idTurma, nomeAluno)
        {
            this.idAluno = idAluno;
        }

        public TurmaAluno(string descricaoModalidade, string nomeAluno)
        {
            this.descricaoModalidade = descricaoModalidade;
            this.NomeAluno1 = nomeAluno;
        }

        public TurmaAluno(int idTurma)
        {
            this.idTurma = idTurma;
        }

        public TurmaAluno()
        {

        }


        public bool cadastrarAlunoTurma()
        {
            bool resultado = false;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Turma_Aluno (codigoTurma, codigoAluno, nomeAluno) values (" + idTurma + ", '" + idAluno+"', '"+nomeAluno+"');",DAOConexao.con);
                insere.ExecuteNonQuery();
             
                resultado = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }

            return resultado;
        }

        public MySqlDataReader consultarAlunos()
        {
            MySqlDataReader result = null;
            try
            {
                DAOConexao.con.Open();
                MySqlCommand insere = new MySqlCommand("select * from Turma_Aluno where codigoTurma = '"+idTurma+"';",DAOConexao.con);
                result = insere.ExecuteReader();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public bool excluirAlunos()
        {
            bool exc = false;
            try
            {
               

                DAOConexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("Delete from Turma_Aluno where codigoTurma = '"+idTurma+"' and nomeAluno = '"+nomeAluno+"';", DAOConexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAOConexao.con.Close();
            }
            return exc;
        }
    }
}
