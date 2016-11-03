using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using CorporateWebsite.Domain;
using CorporateWebsite.Repositories.EntityFramework;

namespace CorporateWebsite.Repositories.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IComponentContext componentContext;
        protected readonly DbContext context;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        /// <param name="componentContext"></param>
        public EFUnitOfWork(DbContext context, IComponentContext componentContext)
        {
            this.context = context;
            this.componentContext = componentContext;
        }

        /// <summary>
        /// 回收资源
        /// </summary>
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        public void ExecuteProcedure(string procedureName, SqlParameter[] parameters)
        {
            DbCommand cmd = context.Database.Connection.CreateCommand();
            cmd.CommandText = procedureName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="sqlParams"></param>
        public void ExecuteSql(string sqlCommand, params object[] sqlParams)
        {
            context.Database.ExecuteSqlCommand(sqlCommand, sqlParams);
        }

        /// <summary>
        /// 获取相应的仓储
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <returns></returns>
        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return componentContext.Resolve<TRepository>(new TypedParameter(typeof(DbContext), context));
        }

        /// <summary>
        /// 提交操作
        /// </summary>
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
