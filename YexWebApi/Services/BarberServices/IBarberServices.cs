using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YexWebApi.Models.Barber;
using YexWebApi.Models.Barber.DAO;

namespace YexWebApi.Services.BarberServices
{
    public interface IBarberServices
    {
        public Task<Barber> findById(int id);
        public Task<List<Barber>> findAllAsync(int skip, int take);
        public Task<Barber> update(int id, BarberModel model);
        public Task<Barber> create(BarberModel model);
        public Task<bool> delete(int id);

    }
}
