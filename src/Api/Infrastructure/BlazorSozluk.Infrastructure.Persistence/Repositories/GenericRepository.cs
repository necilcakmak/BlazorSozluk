using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext dbContext;
        protected DbSet<T> entity => dbContext.Set<T>();
        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(T entity)
        {
            this.entity.Add(entity);
            return dbContext.SaveChanges();
        }

        public int Add(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                return 0;
            entity.AddRange(entities);
            return dbContext.SaveChanges();
        }

        public async Task<int> AddAsync(T entity)
        {
            await this.entity.AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> AddAsync(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                return 0;
            await entity.AddRangeAsync(entities);
            return await dbContext.SaveChangesAsync();
        }

        public virtual int AddOrUpdate(T entity)
        {
            if (!this.entity.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                dbContext.Update(entity);

            return dbContext.SaveChanges();
        }

        public virtual async Task<int> AddOrUpdateAsync(T entity)
        {
            if (!this.entity.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                dbContext.Update(entity);

            return await dbContext.SaveChangesAsync();
        }

        public IQueryable<T> AsQueryable() => entity.AsQueryable();

        public Task BulkAdd(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task BulkDelete(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task BulkDelete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task BulkDeleteById(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task BulkUpdate(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(Guid entityId)
        {
            var entity = this.entity.Find(entityId);
            return Delete(entity);
        }

        public virtual int Delete(T entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                this.entity.Attach(entity);
            }
            this.entity.Remove(entity);
            return dbContext.SaveChanges();
        }

        public virtual Task<int> DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> DeleteAsync(T entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                this.entity.Attach(entity);
            }
            this.entity.Remove(entity);
            return dbContext.SaveChangesAsync();
        }

        public virtual bool DeleteRange(Expression<Func<T, bool>> predicate)
        {
            dbContext.RemoveRange(entity.Where(predicate));
            return dbContext.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate)
        {
            dbContext.RemoveRange(entity.Where(predicate));
            return await dbContext.SaveChangesAsync() > 0;
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            return Get(predicate, noTracking, includes).FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = entity.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            query = ApplyIncludes(query, includes);
            if (noTracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            T found = await entity.FindAsync(id);
            if (found is null)
                return null;
            if (noTracking)
                dbContext.Entry(found).State = EntityState.Detached;
            foreach (Expression<Func<T, object>> include in includes)
            {
                dbContext.Entry(found).Reference(include).Load();
            }
            return found;
        }

        public virtual async Task<List<T>> GetList(Expression<Func<T, bool>> predicate, bool noTracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = entity;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (noTracking)
                query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = entity;
            if (predicate is not null)
                query = query.Where(predicate);
            query = ApplyIncludes(query, includes);
            if (noTracking)
                query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync();
        }

        public virtual int Update(T entity)
        {
            this.entity.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            this.entity.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }
        private static IQueryable<T> ApplyIncludes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }
    }
}
