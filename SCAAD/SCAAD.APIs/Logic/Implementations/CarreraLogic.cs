using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Logic.Implementations
{
    public class CarreraLogic : ICarreraLogic
    {
        public readonly ICarreraRepository carreraRepository;
        public CarreraLogic(ICarreraRepository carreraRepository)
        {
            this.carreraRepository = carreraRepository;
        }

        public List<Carrera> GetAll()
        {
            return carreraRepository.Get();
        }

        public Carrera GetCarreraById(int Id)
        {
            return carreraRepository.GetCarreraById(Id);

        }
    }
}