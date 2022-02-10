using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
          Task<T> GetByIdAsync(int id);
          Task<IEnumerable<T>> GetAllAsync();
        //   Task<IReadOnlyList<T>> GetAllAsync();
          Task<int> AddAsync(T entity);
          Task<int> UpdateAsync(T entity);
          Task<int> DeleteAsync(int id);
    }
}