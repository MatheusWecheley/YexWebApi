using System;
using System.ComponentModel.DataAnnotations;

namespace YexWebApi.Models.Barber.DAO
{
    public class BarberModel
    {
        [Required(ErrorMessage = "O Campo Nome Usual é óbrigatório!")]
        public string NameUsual { get; set; }

        [Required(ErrorMessage = "O Campo Dono é óbrigatório!")]
        public string Owner { get; set; }

        [EmailAddress(ErrorMessage = "Email Inválido")]
        [Required(ErrorMessage = "O Campo Email é óbrigatório!")]
        public string email { get; set; }

        [Required(ErrorMessage = "O Campo CPF/CNPJ é óbrigatório!")]
        [StringLength(15, MinimumLength = 11)]
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "O Campo Rua é óbrigatório!")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O Campo Bairro é óbrigatório!")]
        public string District { get; set; }

        [Required(ErrorMessage = "O Campo Numero é óbrigatório!")]
        public int BarberNum { get; set; }

        [Required(ErrorMessage = "O Campo Cep é óbrigatório!")]
        public int Cep { get; set; }

        [Required(ErrorMessage = "O Campo Cidade é óbrigatório!")]
        public string City { get; set; }

        [Required(ErrorMessage = "O Campo Celular é óbrigatório!")]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "O Campo Telefone é óbrigatório!")]
        public string Tellphone { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime updatedAt { get; set; }
    }
}
