using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NLog;
using System;

namespace RecruitmentApplication.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T GetById(int id, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = _dbSet;

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                var entity = query.FirstOrDefault(e => e.GetType().GetProperty("Id") != null && (int)e.GetType().GetProperty("Id").GetValue(e) == id);

                if (entity == null)
                {
                    Logger.Warn("Entity of type {0} with id {1} not found.", typeof(T).Name, id);
                    return null;
                }

                Logger.Info("Retrieved entity of type {0} with id {1}", typeof(T).Name, id);
                return entity;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving entity of type {0} with id {1}", typeof(T).Name, id);
                throw;
            }
        }

        public List<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = _dbSet;

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                var entities = query.ToList();

                Logger.Info("Retrieved {0} entities of type {1}", entities.Count, typeof(T).Name);
                return entities;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving all entities of type {0}", typeof(T).Name);
                throw;
            }
        }

        public void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                Logger.Info("Added entity of type {0}", typeof(T).Name);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error adding entity of type {0}", typeof(T).Name);
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                Logger.Info("Updated entity of type {0}", typeof(T).Name);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error updating entity of type {0}", typeof(T).Name);
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
                _context.SaveChanges();
                Logger.Info("Deleted entity of type {0}", typeof(T).Name);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error deleting entity of type {0}", typeof(T).Name);
                throw;
            }
        }
    }

}
