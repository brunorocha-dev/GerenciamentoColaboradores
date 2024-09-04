using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace GerenciadorColaboradores.Models
{
    public class ColaboradorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a matrícula!")]

        [MaxLength(10)] // Ajustar o tamanho conforme necessário
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Informe o cargo!")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Informe o salário!")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "Informe o horário de entrada!")]
        public DateTime RegistroEntrada { get; set; }

        [Required(ErrorMessage = "Informe o horário de saída!")]
        public DateTime RegistroSaida { get; set; }

        // Validação personalizada para garantir que a data de entrada seja menor que a data de saída
        public bool IsValid()
        {
            return RegistroEntrada < RegistroSaida;
        }
    }
}
