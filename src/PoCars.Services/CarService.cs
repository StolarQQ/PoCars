using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoCars.Domain;
using PoCars.Infrastructure;
using PoCars.Services.Interfaces;

namespace PoCars.Services
{
    public class CarService : ICarService
    {
        private readonly PoCarsContext _context;

        public CarService(PoCarsContext context)
        {
            _context = context;
        }
        
        public async Task<Car> GetByIdAsync(int id)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                throw new ArgumentException($"Car with id '{id}' was not found.");
            }

            return car;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var cars = await _context.Cars.ToListAsync();

            return cars;
        }

        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var car = await _context.Cars.SingleOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                throw new ArgumentException($"Car with id '{id}' was not found.");
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}