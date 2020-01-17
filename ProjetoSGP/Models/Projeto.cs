using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoSGP.Models
{
    public class Projeto
    {

        [DisplayName("Id")]
        public int IdProjeto  { get; set; }

        [Required(ErrorMessage = "O Nome deve ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Uma data de início deve ser preenchido")]
        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "O valor do contrato deve ser preenchido")]
        [DisplayName("Valor do Contrato")]
        public double ValorContrato { get; set; }

        public List<Atividade> listaAtividades { get; set; }

    }
}