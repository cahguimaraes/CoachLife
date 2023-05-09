using CoachLife.Domain.Interfaces.Repositories;
using CoachLife.Domain.Models;
using CoachLife.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CoachLife.Infra.Repositories
{
    [ExcludeFromCodeCoverage]
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly LifeCoachContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(LifeCoachContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task Add(TEntity obj)
        {
            DbSet.Add(obj);
            await SaveChanges();
        }

        public void AddRange(List<TEntity> obj)
        {
            DbSet.AddRange(obj);
            Db.SaveChanges();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync(true);
        }

        public async Task<TEntity> RemoveById(int id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity != null)
                DbSet.Remove(entity);
            return entity;
        }

        public async Task RemoveAll()
        {
            Db.Database.ExecuteSqlRaw($"DELETE FROM {typeof(TEntity).Name}");
            await SaveChanges();
        }

        public async Task Update(TEntity obj)
        {
            DbSet.Update(obj);
            await SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Db?.Dispose();
        }
    }
}
