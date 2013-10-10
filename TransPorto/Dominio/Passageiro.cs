﻿using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Passageiro : Entidade
    {
        public Passageiro()
        {
            Endereco = new Endereco();
        }

        [Required(ErrorMessage = "O Nome do passageiro deve ser informado!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Algum contato deve ser informado!")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "O Endereço deve ser informado!")]
        [Display(Name = "Endereço")]
        private Endereco Endereco { get; set; }
    }
}
