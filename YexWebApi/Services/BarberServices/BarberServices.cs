using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YexWebApi.Data;
using YexWebApi.Models.Barber;
using YexWebApi.Models.Barber.DAO;

namespace YexWebApi.Services.BarberServices
{
    public class BarberServices : IBarberServices
    {
        private readonly AppDbContext _context;

        public BarberServices([FromServices] AppDbContext context) {
            _context = context;
        }

        public async Task<List<Barber>> findAllAsync(int skip, int take)
        {
            var barbers = await _context.Barbers.AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return barbers;
        }

        public async Task<Barber> findById(int id)
        {
            var barber = await _context.Barbers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return barber;
        }

        public async Task<Barber> create(BarberModel model)
        {
            var barber = new Barber
            {
                NameUsual = model.NameUsual,
                Owner = model.Owner,
                CnpjCpf = model.CnpjCpf,
                Street = model.Street,
                District = model.District,
                BarberNum = model.BarberNum,
                Cep = model.Cep,
                City = model.City,
                Cellphone = model.Cellphone,
                Tellphone = model.Tellphone,
            };

            try
            {
                await _context.Barbers.AddAsync(barber);
                await _context.SaveChangesAsync();
                return barber;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Barber> update(int id, BarberModel model)
        {
            var barber = await _context.Barbers.FirstOrDefaultAsync(x => x.Id == id);

            if (barber == null) {
                return null;
            }

            try
            {
                barber.NameUsual = model.NameUsual;
                barber.Owner = model.Owner;
                barber.Street = model.Street;
                barber.District = model.District;
                barber.City = model.City;
                barber.updatedAt = DateTime.Now;

                _context.Barbers.Update(barber);
                await _context.SaveChangesAsync();

                return barber;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> delete(int id)
        {
            var barber = await _context.Barbers.FirstOrDefaultAsync(x => x.Id == id);

            if (barber == null)
            {
                return false;
            }

            try
            {
                _context.Remove(barber);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
