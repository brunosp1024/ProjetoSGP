using System;
using System.Data.SqlClient;

namespace ProjetoSGP.Conexao
{
    public class ConexaoBanco : IDisposable //Herdar de IDisposable um método para fechar a conexão.
    {
        private readonly SqlConnection minhaConexao; //variável do tipo readonly.

        public ConexaoBanco() //Quando a classe for instanciada, será criada uma conexão, e ela é aberta instantaneamente.
        {
            minhaConexao = new SqlConnection(@"data source=DESKTOP-D50A3M7\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=BancoWebMVC");
            minhaConexao.Open();
        }

        //Para insert, update e delete no banco de dados.
        public void ExecutaComandoSemRetorno(string strQuery) //Executa comando no banco sem retorno (Select).
        {
            var cmdCommand = new SqlCommand(strQuery, minhaConexao); //salva o comando passado como string na conexão criada.
            cmdCommand.ExecuteNonQuery(); //Executa o comando sem nenhum retorno
        }

        //Apenas para o select.
        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdCommand = new SqlCommand(strQuery, minhaConexao);
            return cmdCommand.ExecuteReader(); //Executa o comando, retornando os dados do banco.
        }


        public void Dispose() //Quando a classe for finalizada, vai fechar a conexão.
        {
            if (minhaConexao.State == System.Data.ConnectionState.Open) //Verifica se a conexão está aberta.
            {
                minhaConexao.Close();
            }
        }
    }
}