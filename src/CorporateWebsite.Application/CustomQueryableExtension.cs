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
    /// </summary>

    public static class CustomQueryableExtension
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

        /// <summary>
        /// 拼接and 条件语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return ParameterRebinder.Compose(first, second, Expression.And);
        }

        /// <summary>
        /// 拼接or 条件语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return ParameterRebinder.Compose(first, second, Expression.Or);
        }

    }

    /// <summary>
    /// Expression表达式组合
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        public static Expression<T> Compose<T>(Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            var secondBody = ReplaceParameters(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
}
