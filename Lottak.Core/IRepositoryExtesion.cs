using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core
{
    /// <summary>
    /// 数据仓库扩展
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryExtesion<TEntity> : IRepositoryExtesion<TEntity, int> where TEntity : class, IEntity<int>
    {

    }

    /// <summary>
    /// 数据仓库扩展
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>

    public interface IRepositoryExtesion<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetByWhere(Expression<Func<TEntity, bool>> filter);
    }
}
