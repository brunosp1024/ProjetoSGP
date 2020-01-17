using ProjetoSGP.Conexao;
using ProjetoSGP.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoSGP.Aplicacao
{
    public class RecursoAplicacao
    {
        private ConexaoBanco conexao;

        public void Insert(Recurso recurso)
        {

            string strQuery = string.Format("insert into Recurso (Nome, Email, Telefone) values ('{0}', '{1}', '{2}')", recurso.Nome, recurso.Email, recurso.Telefone);

            using (conexao = new ConexaoBanco()) //Após usar, o objeto e destruido.
            {
                conexao.ExecutaComandoSemRetorno(strQuery);
            }
        }

        public void Update(Recurso recurso)
        {
            string strQuery = string.Format("update Recurso set Nome = '{0}', Email = '{1}', Telefone = '{2}' where IdRecurso = {3}", recurso.Nome, recurso.Email, recurso.Telefone, recurso.IdRecurso);

            using (conexao = new ConexaoBanco())
            {
                conexao.ExecutaComandoSemRetorno(strQuery);
            }
        }

        public void Deletar(int id)
        {
            using (conexao = new ConexaoBanco())
            {
                string strQuery = string.Format("delete from Recurso where IdRecurso = {0}", id);
                conexao.ExecutaComandoSemRetorno(strQuery);
            }

        }

        public List<Recurso> Select()
        {
            using (conexao = new ConexaoBanco())
            {
                string strQuery = string.Format("select * from Recurso");
                SqlDataReader dados = conexao.ExecutaComandoComRetorno(strQuery);
                return TransformerSqlDataReader(dados);
            }
        }

        private List<Recurso> TransformerSqlDataReader(SqlDataReader read)
        {
            var recurso = new List<Recurso>();
            while (read.Read())
            {
                var objeto = new Recurso();

                objeto.IdRecurso = int.Parse(read["IdRecurso"].ToString());
                objeto.Nome = read["Nome"].ToString();
                objeto.Email = read["Email"].ToString();
                objeto.Telefone = read["Telefone"].ToString();

                recurso.Add(objeto);

            }
            read.Close();
            return recurso;
        }

        public Recurso ListaPorID(int id)
        {
            using(conexao = new ConexaoBanco())
            {
                var strQuery = string.Format("select * from Recurso where IdRecurso = {0}", id);
                var dados = conexao.ExecutaComandoComRetorno(strQuery);
                return TransformerSqlDataReader(dados).FirstOrDefault();
            }
        }

    }
}