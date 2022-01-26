
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatty.Models;

namespace Chatty.Data
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // Get all data
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllAsQueryable();

        // Create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity); //Task este folosit pentru metodele asincrone 
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        // Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        // Delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        // Find
        public TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);

    }
}
