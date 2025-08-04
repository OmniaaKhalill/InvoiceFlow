using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
      
            Task<T?> GetAsync(long id);
            Task<IReadOnlyList<T>> GetAllAsync();
        

            Task<bool> DeleteAsync(long id);
            Task<T?> UpdateAsync(long id, T entityToUpdate);
            Task<T?> AddAsync(T entity);
            Task<int> SaveChanges();
            Task<bool> CheckIfExistsAsync(long id);
        
    }

}
