using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebsite.Domain.IRepositories
{
    // 仓储接口
    public interface IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="t">新实例</param>
        /// <returns></returns>
        TEntity Create(TEntity t);

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="t">删除的实例</param>
        void Delete(TEntity t);

        /// <summary>
        /// 删除满足条件的记录
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="t">更新的实例</param>
        void Update(TEntity t);

        /// <summary>
        /// 根据主键获取特定实例
        /// </summary>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        TEntity Single(object key);

        /// <summary>
        /// 根据条件获取特定的实例
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据条件获取特定的实例
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取当前表的所有记录
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> All();

        /// <summary>
        /// 通过过滤条件查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 通过过滤条件查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter<TSort>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSort>> orderLambda);

        /// <summary>
        /// 通过过滤条件查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="isDesc">是否降序</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter<TSort>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSort>> orderLambda, bool isDesc);

        /// <summary>
        /// 通过过滤条件查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="rows">总记录数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter<TSort>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSort>> orderLambda, out int rows, int pageIndex, int pageSize);

        /// <summary>
        /// 通过过滤条件查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="isDesc">是否降序</param>
        /// <param name="rows">总记录数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter<TSort>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSort>> orderLambda, bool isDesc, out int rows, int pageIndex, int pageSize);

        /// <summary>
        /// 是否存在满足条件的记录
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        bool Contains(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 统计满足条件的记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

    }
}
