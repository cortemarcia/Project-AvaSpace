﻿using AvaSpace.Domain.Entities;
using AvaSpace.Domain.Interfaces.Repositories;
using Dapper;
using Dommel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AvaSpace.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> 
        where TEntity : BaseEntity
    {
        public virtual bool Delete(Guid id)
        {
            using (var cn = SqlConnectionFactory.Create())
            {
                return cn.Delete(id);
            }
        }

        public void Execute(string sql, object parameters)
        {
            using (var db = SqlConnectionFactory.Create())
            {
                db.Query(sql, parameters);
            }
        }

        public IEnumerable<T> Execute<T>(string sql, object parameters)
        {
            using (var db = SqlConnectionFactory.Create())
            {
                return db.Query<T>(sql, parameters);
            }
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (var cn = SqlConnectionFactory.Create())
            {
                return cn.Select(predicate);
            }
        }

        public virtual TEntity Get(Guid id)
        {
            using (var cn = SqlConnectionFactory.Create())
            {
                return cn.Get<TEntity>(id);
            }
        }

        public virtual Guid Insert(TEntity entity)
        {
            using (var cn = SqlConnectionFactory.Create())
            {
                cn.Insert(entity);

                return entity.Id;
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var cn = SqlConnectionFactory.Create())
            {
                entity.DateUpdate = DateTime.Now;

                return cn.Update(entity);
            }
        }
    }
}
