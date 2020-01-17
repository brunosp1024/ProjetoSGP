using System;
using System.ComponentModel;

namespace ProjetoSGP.Models
{
    public class Atividade
    {

        [DisplayName("Id")] //Exibe o nome Id ao invés de IdAtividade
        public int IdAtividade { get; set; }

        public string Nome { get; set; }

        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }

        
        [DisplayName("Data de Término")]
        public DateTime DataTermino { get; set; }

        [DisplayName("Duração")]
        public int Duracao { get; set; }

        public string Status { get; set; }

        public int Recurso { get; set; }

        public int Projeto { get; set; }



    }
}