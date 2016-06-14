using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models.ViewModels
{
    public class PAADModificadoJustificadoViewModel
    {
        public int PAAD_Id { get; set; }
        [Required]
        public PAADViewModel PAADViewModel { get; set; }
        [Required]
        [MaxLength(200)]
        public string MotivoModificacion { get; set; }
    }
}