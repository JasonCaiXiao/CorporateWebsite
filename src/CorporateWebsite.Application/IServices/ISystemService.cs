using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CorporateWebsite.Application.ModelDTO;
using CorporateWebsite.Domain.Model;

namespace CorporateWebsite.Application.IServices
{
   public interface  ISystemService
    {
        #region 功能模块管理
        /// <summary>
        /// 获取模块分页列表
        /// </summary>
        /// <param name="wh"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        IList<PermissionDto> GetListPermissionDto(Expression<Func<Permission, bool>> wh, int limit, int offset, out int total);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult Insert(List<PermissionDto> model);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult Update(List<PermissionDto> model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult Delete(List<PermissionDto> model);
        #endregion
    }
}
