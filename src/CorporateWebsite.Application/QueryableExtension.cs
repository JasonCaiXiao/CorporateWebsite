using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;

namespace CorporateWebsite.Application
{
    /// <summary>
    /// IQueryable扩展
    /// 使用DynamicQueryable、AutoMap进行扩展
    /// </summary>

    public static class QueryableExtension
    {
        /// <summary>
        /// WhereIf语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> func)
        {
            return condition ? query.Where(func) : query;
        }

        /// <summary>
        /// 需要在 Global.asax 配置映射 Mapper.CreateMap<T, DTO>();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> Select<T>(this IQueryable query)
        {
            if (query == null)
                throw new ArgumentNullException("IQueryable扩展类Select方法中query为空");
            return query.ProjectTo<T>();
        }
        /// <summary>
        ///组合OrderBy语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string ordering, params object[] values)
        {
            if (query == null)
                throw new ArgumentNullException("IQueryable扩展类Select方法中OrderBy为空");
            return DynamicQueryable.OrderBy(query, ordering, values);
        }

    }
}
