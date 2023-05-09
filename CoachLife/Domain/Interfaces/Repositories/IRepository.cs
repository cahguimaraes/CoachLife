using CoachLife.Domain.Models;

namespace CoachLife.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        void AddRange(List<TEntity> obj);
        Task Update(TEntity obj);
        Task<TEntity> RemoveById(int id);
        Task RemoveAll();
        Task<int> SaveChanges();
    }
}
