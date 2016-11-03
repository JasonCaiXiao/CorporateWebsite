using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CorporateWebsite.Domain;
using CorporateWebsite.Domain.IRepositories;
using CorporateWebsite.Repositories.UnitOfWork;

namespace CorporateWebsite.Repositories.EntityFramework
{
   public abstract class EntityFrameworkRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {

        protected readonly DbContext context;
        protected DbSet<TEntity> DbSet
        {
            get
            {
                return context.Set<TEntity>();
            }
        }

        public EntityFrameworkRepository(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="t">新实例</param>
        /// <returns></returns>
        public TEntity Create(TEntity t)
        {
            return DbSet.Add(t);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="t">删除的实例</param>
        public void Delete(TEntity t)
        {
            DbSet.Remove(t);
        }

        /// <summary>
        /// 删除满足条件的记录
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                context.Configuration.AutoDetectChangesEnabled = false;  //关闭数据库上下文的自动更新跟踪功能，可提高批量操作的性能
                var items = Filter(predicate);
                foreach (var item in items)
                {
                    DbSet.Remove(item);
                }
            }
            finally
            {
                context.Configuration.AutoDetectChangesEnabled = true;  //完成批量操作后，打开数据库上下文的自动更新跟踪功能
            }
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="t">更新的实例</param>
        public void Update(TEntity t)
        {
            var entry = context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// 根据主键获取特定实例
        /// </summary>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        public TEntity Single(object key)
        {
            return DbSet.Find(key);
        }

        /// <summary>
        /// 根据条件获取特定的实例
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        /// <summary>
        /// 根据条件获取特定的实例
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// 获取当前表的所有记录
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> All()
        {
            return DbSet.AsQueryable();
        }

        /// <summary>
        /// 通过过滤条件查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return Filter<string>(predicate, null);
        }

        /// <summary>
        /// 通过过滤条件查询（默认升序排序）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns></returns>
        public IQueryable<TEntity> Filter<TSort>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSort>> orderLambda)
        {
            return Filter(predicate, orderLambda, false);
        }

        /// <summary>
        /// 通过过滤条件查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="isDesc">是否降序</param>
        /// <returns></returns>
        public IQueryable<TEntity> Filter<TSort>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSort>> orderLambda, bool isDesc)
        {
            var items = predicate != null ? DbSet.Where(predicate) : DbSet.AsQueryable();
            if (orderLambda != null)
            {
                items = isDesc ? items.OrderByDescending(orderLambda) : items.OrderBy(orderLambda);
            }
            return items;
        }

        /// <summary>
        /// 通过过滤条件查询（默认升序排序）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="rows">总记录数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public IQueryable<TEntity> Filter<TSort>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSort>> orderLambda, out int rows, int pageIndex, int pageSize)
        {
            return Filter(predicate, orderLambda, false, out rows, pageIndex, pageSize);
        }

        /// <summary>
        /// 通过过滤条件查询
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="isDesc">是否降序（默认是升序）</param>
        /// <param name="rows">总记录数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public IQueryable<TEntity> Filter<TSort>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TSort>> orderLambda, bool isDesc, out int rows, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0)  //当前页面默认为第一页
            {
                pageIndex = 1;
            }
            if (pageSize < 0)  //每页默认为10条记录
            {
                pageSize = 10;
            }
            var items = predicate != null ? DbSet.Where(predicate) : DbSet.AsQueryable();
            if (items.Any())
            {
                rows = items.Count();
                if (orderLambda != null)
                {
                    items = isDesc ? items.OrderByDescending(orderLambda) : items.OrderBy(orderLambda);
                }
                items = items.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return items;
            }
            else
            {
                rows = 0;
                return null;
            }
        }

        /// <summary>
        /// 是否存在满足条件的记录
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        /// <summary>
        /// 统计满足条件的记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }
    }
}
