﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain;
using Microsoft.EntityFrameworkCore;

namespace alten_assessment_project.Infrastructure.Persistence
{
    // Base repository implementation for basic CRUD operations. Anything else should be implemented in corresponding repository.
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> Entities;
        protected ApplicationDbContext DbContext;

        public GenericRepository(ApplicationDbContext context)
        {
            DbContext = context;
            Entities = DbContext.Set<TEntity>();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public async Task<IEnumerable<TEntity?>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity?>> GetAllAsync()
        {
            return await Entities.AsQueryable().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(long id)
        {
            return await Entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public long InsertAndGetId(TEntity entity)
        {
            Insert(entity);
            DbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }
    }
}
