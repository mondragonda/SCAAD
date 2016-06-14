using SCAAD.APIs.Models;
using SCAAD.APIs.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Infrastructure.MyMapper
{
    public class DocenteMapper
    {
        public static Docente Map(DocenteViewModel docenteViewModel)
        {
            var docente = new Docente();

            docente.Nombre = docenteViewModel.Nombre;
            docente.Apellido = docenteViewModel.Apellido;
            docente.NumeroEmplado = docenteViewModel.NumeroEmplado;
            docente.Carrera_Id = docenteViewModel.CarreraId;
            docente.idUsuario = docenteViewModel.userId;

            return docente;

        }
    }
}
