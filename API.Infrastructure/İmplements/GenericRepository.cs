using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Spesicifications;
using API.Infrastructure.Data;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<TEntity> GetEntityWithSpec(ISpesification<TEntity> spec)
        {
            return await ApplySpesification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync(ISpesification<TEntity> spec)
        {
            return await ApplySpesification(spec).ToListAsync();
        }

        private IQueryable<TEntity> ApplySpesification(ISpesification<TEntity> spec)
        {
            return SpesificationEveluator<TEntity>.GetQuery(_ctx.Set<TEntity>().AsQueryable(), spec);
        }
    }
}
