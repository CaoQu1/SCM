using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Lottak.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.EntityFramework
{
    public class LottakEfRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<LottakDataContext, TEntity, TPrimaryKey>, IRepositoryExtesion<TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
    {
        public LottakEfRepositoryBase(IDbContextProvider<LottakDataContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public IQueryable<TEntity> GetByWhere(Expression<Func<TEntity, bool>> filter)
        {
            return GetAll().Where(filter);
        }
    }

    public class LottakEfRepositoryBase<TEntity> : LottakEfRepositoryBase<TEntity, int>, IRepositoryExtesion<TEntity>
        where TEntity : class, IEntity<int>
    {
        public LottakEfRepositoryBase(IDbContextProvider<LottakDataContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
