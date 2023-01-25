using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.UseCases
{
    public interface IBarberUseCase
    {
        public void AddBarber(Barber barber);
    }
}
