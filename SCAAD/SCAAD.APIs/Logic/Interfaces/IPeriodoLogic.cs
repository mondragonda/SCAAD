﻿using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface IPeriodoLogic
    {
        void AddPeriodo(Periodo periodo);
        Periodo GetPeriodoActual();

        IEnumerable<Periodo> GetPeriodos();
        void ModificarPeriodo(Periodo periodoModel);
    }
}