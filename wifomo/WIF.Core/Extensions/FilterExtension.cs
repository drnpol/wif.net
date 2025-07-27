using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.Features.Kendo.Requests;
using WIF.PortfolioManager.Application.Helpers;

namespace WIF.PortfolioManager.Application.Extensions
{
    public static class FilterExtension
    {
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, List<Filter<T>> filters)
        {
            foreach (var filter in filters)
            {
                var propName = filter.Name;
                var param = Expression.Parameter(typeof(T), "x");
                var property = Expression.PropertyOrField(param, propName);
                var constant = Expression.Constant(Convert.ChangeType(filter.Value, property.Type));

                Expression predicate = filter.Operator switch
                {
                    "equal" => Expression.Equal(property, constant),
                    "neq" => Expression.NotEqual(property, constant),
                    "gt" => Expression.GreaterThan(property, constant),
                    "lt" => Expression.LessThan(property, constant),
                    "gte" => Expression.GreaterThanOrEqual(property, constant),
                    "lte" => Expression.LessThanOrEqual(property, constant),
                    "contains" => Expression.Call(
                                    property,
                                    typeof(string).GetMethod("Contains", new[] { typeof(string) })!,
                                    constant),
                    _ => throw new NotSupportedException($"Operator {filter.Operator} not supported.")
                };

                var lambda = Expression.Lambda<Func<T, bool>>(predicate, param);
                query = query.Where(lambda);
            }

            return query;
        }
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, List<KendoListFilter> kFilters)
        {
            List<Filter<T>> filters = new();
            
            foreach (KendoListFilter kFilter in kFilters)
            {
                Filter<T> filter = new();
                filter.Value = kFilter.Value;
                filter.Name = kFilter.Field;
                filter.Alias = kFilter.Field;
                filter.Operator = kFilter.Operator;

                filters.Add(filter);
            }
            return query.ApplyFilters(filters);
        }
    }
}
