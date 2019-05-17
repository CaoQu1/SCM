using Abp.Application.Services.Dto;
using Abp.WebApi.Authorization;
using Abp.WebApi.Controllers;
using Lottak.Application.Dto;
using Lottak.Application.IService;
using Lottak.Core.Common;
using Lottak.Core.Extension;
using Lottak.Core.Suppliers;
using Lottak.SCM.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Lottak.SCM.Controllers
{
    /// <summary>
    /// 供应商模块
    /// </summary>
    [RoutePrefix("api/supplier")]
    public class SupplierController : BaseApiController
    {
        /// <summary>
        /// 供应商服务
        /// </summary>
        private readonly ISupplierService _supplierService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="supplierService"></param>
        public SupplierController(ISupplierService supplierService,
            ISystemUserService systemUserService)
        {
            this._supplierService = supplierService;
            this._systemUserService = systemUserService;
        }

        /// <summary>
        /// 查询供应商列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("list")]
        [HttpGet]
        public ResultJson<PageResultJson<SupplierDto>> List(QueryParameter query) => Response<PageResultJson<SupplierDto>>(() =>
            {
                var result = _supplierService.GetAll(ObjectMapper.Map<PagedAndSortedResultRequestDto>(query ?? new QueryParameter()));
                return ObjectMapper.Map<PageResultJson<SupplierDto>>(result);
            });

        /// <summary>
        /// 获取供应商详情
        /// </summary>
        [HttpGet]
        [Route("detail")]
        public ResultJson<SupplierDetailDto> Detail(int id) => Response<SupplierDetailDto>(() =>
             {
                 var supplier = _supplierService.First(x => x.Id == id);
                 var supplierDetailDto = ObjectMapper.Map<SupplierDetailDto>(supplier);
                 supplierDetailDto.Operator = _companyEmployeeService.GetByWhere(x => x.UserGuid == supplier.CreateBy && x.CompanyNo == supplier.CompanyNo).FirstOrDefault().RealName;
                 return supplierDetailDto;
             });

        /// <summary>
        /// 编辑供应商信息
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        public ResultJson<dynamic> Update(SupplierDetailDto supplier) => Response<dynamic>(() =>
        {
            var supplierEntity = ObjectMapper.Map<Supplier>(supplier);
            supplierEntity.CompanyNo = _webContext.CurrentCompany.SeletedCompany.CompanyNo;
            if (supplier.Id > 0)
            {
                supplierEntity.UpdateBy = _webContext.CurrentUser.UserGuid;
                supplierEntity.UpdateOnUtc = DateTime.UtcNow;
            }
            else
            {
                supplierEntity.CreateBy = _webContext.CurrentUser.UserGuid;
                supplierEntity.CreateOnUtc = DateTime.UtcNow;
            }
            return new { Id = _supplierService.InsertOrUpdateAndGetId(supplierEntity) };
        });

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("delete")]
        [HttpPost]
        public ResultJson<dynamic> Delete(dynamic Id) => Response<dynamic>(() =>
         {
             _supplierService.Delete(Id);
             return new { Id = Id };
         });

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        private ResultJson<T> Response<T>(Func<T> method)
        {
            ResultJson<T> resultJson = new ResultJson<T>
            {
                code = EnumStatusCode.OK,
                message = EnumStatusCode.OK.ToDescription()
            };
            try
            {
                resultJson.data = method();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                resultJson.code = EnumStatusCode.Normal;
                resultJson.message = ex.Message;
            }
            return resultJson;
        }
    }
}