using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Infrastructure.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbcontext;
        public GenericRepo(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>()
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<T?> GetAsync(long id)
        {
            return await _dbcontext.Set<T>()
                .Where(e => !e.IsDeleted && e.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            T? entity = await _dbcontext.Set<T>().FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return false;

            entity.IsDeleted = true;
            _dbcontext.Set<T>().Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<T?> UpdateAsync(long id, T entityToUpdate)
        {
            T? entity = await _dbcontext.Set<T>()
                .Where(e => !e.IsDeleted && e.ID == id)
                .FirstOrDefaultAsync();

            if (entity != null)
            {
                _dbcontext.Entry(entity).CurrentValues.SetValues(entityToUpdate);
                await _dbcontext.SaveChangesAsync();
            }

            return entityToUpdate;
        }

        public async Task<T?> AddAsync(T entity)
        {
            await _dbcontext.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> SaveChanges()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfExistsAsync(long id)
        {
            T? entity = await _dbcontext.Set<T>()
                .Where(e => !e.IsDeleted && e.ID == id)
                .FirstOrDefaultAsync();

            return entity != null;
        }
    }
}