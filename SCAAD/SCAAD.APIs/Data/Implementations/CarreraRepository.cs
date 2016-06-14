using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace SCAAD.APIs.Data.Implementations
{
    public class CarreraRepository : UpdatableRepositoryBase<Carrera>, ICarreraRepository
    {
        public Carrera GetCarreraById(int Id)
        {
            return context.Carreras.SingleOrDefault(x => x.Id == Id);
        }
    }
}