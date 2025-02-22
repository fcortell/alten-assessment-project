﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace alten_assessment_project.Domain
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);

        void Delete(TEntity entity);

        Task<IEnumerable<TEntity?>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity?>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(long id);

        void Insert(TEntity entity);

        long InsertAndGetId(TEntity entity);

        void Update(TEntity entity);
    }
}
