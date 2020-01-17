using ProjetoSGP.Conexao;
using ProjetoSGP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoSGP.Aplicacao
{
    public class ProjetoAplicacao
    {
        private ConexaoBanco conexao;

        public void Insert(Projeto projeto)
        {

            string strQuery = string.Format("insert into Projeto (Nome, DataInicio, Status, ValorContrato) values ('{0}', '{1}', '{2}', '{3}')", projeto.Nome, projeto.DataInicio, projeto.Status, projeto.ValorContrato);

            using (conexao = new ConexaoBanco()) //Após usar, o objeto e destruido.
            {
                conexao.ExecutaComandoSemRetorno(strQuery);
            }
        }

        public void Update(Projeto projeto)
        {
            string strQuery = string.Format("update Projeto set Nome = '{0}', DataInicio = '{1}', Status = '{2}', ValorContrato = {3} where IdProjeto = {4}", projeto.Nome, projeto.DataInicio, projeto.Status, projeto.ValorContrato, projeto.IdProjeto);

            using (conexao = new ConexaoBanco())
            {
                conexao.ExecutaComandoSemRetorno(strQuery);
            }
        }

        public void Deletar(int id)
        {
            using (conexao = new ConexaoBanco())
            {
                string strQuery = string.Format("delete from Projeto where IdProjeto = {0}", id);
                conexao.ExecutaComandoSemRetorno(strQuery);
            }

        }

        public List<Projeto> Select()
        {
            using (conexao = new ConexaoBanco())
            {
                string strQuery = string.Format("select * from Projeto");
                SqlDataReader dados = conexao.ExecutaComandoComRetorno(strQuery);
                return TransformerSqlDataReader(dados);
            }
        }

        private List<Projeto> TransformerSqlDataReader(SqlDataReader read)
        {
            var projeto = new List<Projeto>();
            while (read.Read())
            {
                var objeto = new Projeto();

                objeto.IdProjeto = int.Parse(read["IdProjeto"].ToString());
                objeto.Nome = read["Nome"].ToString();
                objeto.DataInicio = DateTime.Parse(read["DataInicio"].ToString());
                objeto.Status = read["Status"].ToString();
                objeto.ValorContrato = double.Parse(read["ValorContrato"].ToString());

                projeto.Add(objeto);

            }
            read.Close();
            return projeto;
        }

        public Projeto ListaPorID(int id)
        {
            using(conexao = new ConexaoBanco())
            {
                var strQuery = string.Format("select * from Projeto where IdProjeto = {0}", id);
                var dados = conexao.ExecutaComandoComRetorno(strQuery);
                return TransformerSqlDataReader(dados).FirstOrDefault();
            }
        }

    }
}