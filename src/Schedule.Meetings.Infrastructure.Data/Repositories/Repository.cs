using Microsoft.EntityFrameworkCore;
using Schedule.Meetings.Domain.Interfaces.Repositories;
using Schedule.Meetings.Infrastructure.Data.Context;
using System;
using System.Linq;

namespace Schedule.Meetings.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ScheduleMeetingsContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ScheduleMeetingsContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
