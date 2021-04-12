using API.Core.DbModels;
using API.Core.Spesicifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity:BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<TEntity> GetEntityWithSpec(ISpesification<TEntity> spec);
        Task<IReadOnlyList<TEntity>> ListAsync(ISpesification<TEntity> spec);

        Task<int> CountAsync(ISpesification<TEntity> spec);
    }
}
