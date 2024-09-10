using Microsoft.EntityFrameworkCore;
using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Domain.Common;
using SecurityApp.Infrastructure.Persistence;

namespace SecurityApp.Infrastructure.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseDomain
    {
        protected readonly SecurityAppDbContext _context;

        public AsyncRepository(SecurityAppDbContext context)
        {
            _context = context;
        }


        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }



        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }


    }
}
