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
        public Endereco Endereco { get; set; }

        public string Buscar { get; set; }

        [Display(Name = "Companhia Aerea")]
        public string CompanhiasAereas { get; set; }

        [Required(ErrorMessage = "O valor da passagem deve ser informado!")]
        public double ValorPassage { get; set; }
    }
}
