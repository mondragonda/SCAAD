using System.ComponentModel.DataAnnotations;

namespace SCAAD.APIs.Models.ViewModels
{
    public class CategoriaViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
    }
}