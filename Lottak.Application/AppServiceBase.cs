using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Lottak.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application
{
    /// <summary>
    /// 服务基类
    /// </summary>
    public abstract class AppServiceBase<TEntity> : ApplicationService, IApplicationServiceExtension<TEntity> where TEntity : class, IEntity<int>
    {
        /// <summary>
        /// 数据仓储服务
        /// </summary>
        protected readonly IRepositoryExtesion<TEntity> _repository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="repository"></param>
        public AppServiceBase(IRepositoryExtesion<TEntity> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetByWhere(filter).FirstOrDefault();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<TEntity> GetByWhere(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetByWhere(filter).ToList();
        }
    }

    /// <summary>
    /// 服务扩展接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApplicationServiceExtension<TEntity> : IApplicationService where TEntity : class, IEntity<int>
    {
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        TEntity First(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<TEntity> GetByWhere(Expression<Func<TEntity, bool>> filter);
    }

    /// <summary>
    /// 分页扩展接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    public interface ICrudAppServiceExtension<TEntity, TEntityDto>
  : ICrudAppServiceExtension<TEntity, TEntityDto, int>
  where TEntityDto : IEntityDto<int>
  where TEntity : IEntity<int>
    {

    }

    /// <summary>
    /// 分页扩展接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface ICrudAppServiceExtension<TEntity, TEntityDto, TPrimaryKey>
    : ICrudAppServiceExtension<TEntity, TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>
    where TEntityDto : IEntityDto<TPrimaryKey>
    where TEntity : IEntity<TPrimaryKey>
    {

    }

    /// <summary>
    /// 分页扩展接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TListDto"></typeparam>
    public interface ICrudAppServiceExtension<TEntity, TEntityDto, TPrimaryKey, in TListDto>
        : ICrudAppServiceExtension<TEntity, TEntityDto, TPrimaryKey, TListDto, TEntityDto>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TListDto : PagedAndSortedResultRequestDto
    {

    }

    /// <summary>
    /// 分页扩展接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TListDto"></typeparam>
    /// <typeparam name="TEditDto"></typeparam>
    public interface ICrudAppServiceExtension<TEntity, TEntityDto, TPrimaryKey, in TListDto, in TEditDto> : ICrudAppService<TEntityDto, TPrimaryKey, TListDto, TEditDto>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TListDto : PagedAndSortedResultRequestDto
        where TEditDto : IEntityDto<TPrimaryKey>
    {
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        TEntity First(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<TEntity> GetByWhere(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// 编辑实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
    }

    /// <summary>
    /// 分页基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    public abstract class CrudAppServiceBase<TEntity, TEntityDto>
        : CrudAppServiceBase<TEntity, TEntityDto, int>, ICrudAppServiceExtension<TEntity, TEntityDto>
        where TEntityDto : IEntityDto<int>
        where TEntity : class, IEntity<int>
    {
        public CrudAppServiceBase(IRepositoryExtesion<TEntity, int> repository) : base(repository)
        {
        }
    }

    /// <summary>
    /// 分页基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey>
        : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>, ICrudAppServiceExtension<TEntity, TEntityDto, TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public CrudAppServiceBase(IRepositoryExtesion<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }

    /// <summary>
    /// 分页基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TListDto"></typeparam>
    public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TListDto>
        : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TListDto, TEntityDto>, ICrudAppServiceExtension<TEntity, TEntityDto, TPrimaryKey, TListDto>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TListDto : PagedAndSortedResultRequestDto
    {
        public CrudAppServiceBase(IRepositoryExtesion<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }

    /// <summary>
    /// 分页基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TListDto"></typeparam>
    /// <typeparam name="TEditDto"></typeparam>
    public abstract class CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TListDto, TEditDto> : CrudAppService<TEntity, TEntityDto, TPrimaryKey, TListDto, TEditDto>, ICrudAppServiceExtension<TEntity, TEntityDto, TPrimaryKey, TListDto, TEditDto>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEditDto : IEntityDto<TPrimaryKey>
        where TListDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 数据仓储服务
        /// </summary>
        protected readonly IRepositoryExtesion<TEntity, TPrimaryKey> _repository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="repository"></param>
        public CrudAppServiceBase(IRepositoryExtesion<TEntity, TPrimaryKey> repository) : base(repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<TEntity> GetByWhere(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetByWhere(filter).ToList();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetByWhere(filter).FirstOrDefault();
        }

        /// <summary>
        /// 编辑实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            return _repository.InsertOrUpdateAndGetId(entity);
        }
    }
}
