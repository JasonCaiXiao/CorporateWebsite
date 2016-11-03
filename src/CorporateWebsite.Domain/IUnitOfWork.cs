using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebsite.Domain
{
    /// <summary>
    /// 工作单元基类接口
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 获取相应的仓储
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <returns></returns>
        TRepository GetRepository<TRepository>() where TRepository : class;
        void ExecuteProcedure(string procedureName, SqlParameter[] parameters);

        void ExecuteSql(string procedureCommand, params object[] sqlParams);
        void Commit();
    }
}
