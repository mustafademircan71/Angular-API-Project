using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.İmplements
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly StoreContext _ctx;
        public GenericRepository(StoreContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }
    }
}
