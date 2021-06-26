using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class VeiculoViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        [DisplayName("Ano")]
        public DateTime Ano { get; set; }

        [Required(ErrorMessage = "O campo Quiometragem é obrigatório")]
        [DisplayName("Quilometragem")]
        public string Quilometragem { get; set; }
    }
}
