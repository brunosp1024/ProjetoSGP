using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoSGP.Models
{
    public class Recurso
    {
        [DisplayName("Id")]
        public int IdRecurso { get; set; }

        [Required(ErrorMessage = "O Nome deve ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email deve ser preenchido")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O email informado não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Telefone deve ser preenchido com todos os dígitos")]
        [RegularExpression(@"^\([0-9]{2}\) [0-9]{1} [0-9]{4}\-[0-9]{4}$", ErrorMessage = "O Telefone deve ser preenchido")]
        public string Telefone { get; set; }

    }
}