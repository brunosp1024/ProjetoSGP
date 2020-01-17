using ProjetoSGP.Conexao;
using ProjetoSGP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoSGP.Aplicacao
{
    public class AtividadeAplicacao
    {
        private ConexaoBanco conexao;

        public void Insert(Atividade atividade)
        {

            string strQuery = string.Format("insert into Atividade (Nome, DataInicio, DataTermino, Duracao, Recurso, Status, Projeto) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", atividade.Nome, atividade.DataInicio, atividade.DataTermino, atividade.Duracao, atividade.Recurso, atividade.Status, atividade.Projeto);

            using (conexao = new ConexaoBanco()) //Após usar, o objeto e destruido.
            {
                conexao.ExecutaComandoSemRetorno(strQuery);
            }
        }

        public void Update(Atividade atividade)
        {
            string strQuery = string.Format("update Atividade set Nome = '{0}', DataInicio = '{1}', DataTermino = '{2}', Duracao = '{3}', Recurso = '{4}', Status = '{5}', Projeto = '{6}' where IdAtividade = {7}", atividade.Nome, atividade.DataInicio, atividade.DataTermino, atividade.Duracao, atividade.Recurso, atividade.Status, atividade.Projeto, atividade.IdAtividade);

            using (conexao = new ConexaoBanco())
            {
                conexao.ExecutaComandoSemRetorno(strQuery);
            }
        }

        public void Deletar(int id)
        {
            using (conexao = new ConexaoBanco())
            {
                string strQuery = string.Format("delete from Atividade where IdAtividade = {0}", id);
                conexao.ExecutaComandoSemRetorno(strQuery);
            }

        }

        public List<Atividade> Select()
        {
            using (conexao = new ConexaoBanco())
            {
                string strQuery = string.Format("select * from Atividade");
                SqlDataReader dados = conexao.ExecutaComandoComRetorno(strQuery);
                return TransformerSqlDataReader(dados);
            }
        }

        private List<Atividade> TransformerSqlDataReader(SqlDataReader read)
        {
            var atividade = new List<Atividade>();
            while (read.Read())
            {
                var objeto = new Atividade();

                objeto.IdAtividade = int.Parse(read["IdAtividade"].ToString());
                objeto.Nome = read["Nome"].ToString();
                objeto.DataInicio = DateTime.Parse(read["DataInicio"].ToString());
                objeto.DataTermino = DateTime.Parse(read["DataTermino"].ToString());
                objeto.Duracao = int.Parse(read["Duracao"].ToString());
                objeto.Recurso = int.Parse(read["Recurso"].ToString());
                objeto.Status = read["Status"].ToString();
                objeto.Projeto = int.Parse(read["Projeto"].ToString());

                atividade.Add(objeto);

            }
            read.Close();
            return atividade;
        }

        public Atividade ListaPorID(int id)
        {
            using(conexao = new ConexaoBanco())
            {
                var strQuery = string.Format("select * from Atividade where IdAtividade = {0}", id);
                var dados = conexao.ExecutaComandoComRetorno(strQuery);
                return TransformerSqlDataReader(dados).FirstOrDefault();
            }
        }

    }
}