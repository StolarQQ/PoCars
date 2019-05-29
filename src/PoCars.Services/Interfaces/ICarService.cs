using System.Collections.Generic;
using System.Threading.Tasks;
using PoCars.Domain;

namespace PoCars.Services.Interfaces
{
    public interface ICarService
    {
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(int id);
    }
}