// using System;
// using System.ComponentModel;
// using Microsoft.EntityFrameworkCore;
// using System.Linq;
// using System.Linq.Expressions;
// using System.ComponentModel.DataAnnotations;
// using System.Collections.Generic;

// namespace Vcc.SocialNetwork.Domain.Model.Extension
// {

//     public static class Extensions
//     {
//         public static string GetEnumDescription<TEnum>(this TEnum item)
//             => item.GetType()
//                    .GetField(item.ToString())
//                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
//                    .Cast<DescriptionAttribute>()
//                    .FirstOrDefault()?.Description ?? string.Empty;

//         //public static void SeedEnumValues<T, TEnum>(this DbSet<T> dbSet, Func<TEnum, T> converter)
//         //    where T : class => Enum.GetValues(typeof(TEnum))
//         //                           .Cast<object>()
//         //                           .Select(value => converter((TEnum)value))
//         //                           .ToList()
//         //                           .ForEach(instance => addOrUpdate<string>(getEnumDescription<TEnum>(instance), instance));


//         /// <summary>
//         /// Adds instances of a new entity or updates an existing one if it exists already
//         /// </summary>
//         /// <typeparam name="T"></typeparam>
//         /// <param name="dbSet"></param>
//         /// <param name="identifierExpression"></param>
//         /// <param name="entities"></param>
//         public static void AddOrUpdate<T>(this DbSet<T> dbSet, Expression<Func<T, object>> identifierExpression, params T[] entities) where T : class
//         {
//             foreach (var entity in entities)
//                 AddOrUpdate(dbSet, identifierExpression, entity);
//         }

//         public static void AddOrUpdate<T>(this DbSet<T> dbSet, Expression<Func<T, object>> identifierExpression, T entity) where T : class
//         {
//             if (identifierExpression == null)
//                 throw new ArgumentNullException(nameof(identifierExpression));
//             if (entity == null)
//                 throw new ArgumentNullException(nameof(entity));

//             var keyObject = identifierExpression.Compile()(entity);
//             var parameter = Expression.Parameter(typeof(T), "p");

//             var lambda = Expression.Lambda<Func<T, bool>>(
//                 Expression.Equal(
//                     ReplaceParameter(identifierExpression.Body, parameter),
//                     Expression.Constant(keyObject)),
//                 parameter);

//             var item = dbSet.FirstOrDefault(lambda.Compile());
//             if (item == null)
//             {
//                 // easy case
//                 dbSet.Add(entity);
//             }
//             else
//             {
//                 // get Key fields, using KeyAttribute if possible otherwise convention
//                 var dataType = typeof(T);
//                 var keyFields = dataType.GetProperties().Where(p => p.GetCustomAttributes(typeof(KeyAttribute), true) != null).ToList();
//                 if (!keyFields.Any())
//                 {
//                     string idName = dataType.Name + "Id";
//                     keyFields = dataType.GetProperties().Where(p =>
//                         string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase) ||
//                         string.Equals(p.Name, idName, StringComparison.OrdinalIgnoreCase)).ToList();
//                 }

//                 // update all non key and non collection properties
//                 foreach (var p in typeof(T).GetProperties().Where(p => p.GetSetMethod() != null && p.GetGetMethod() != null))
//                 {
//                     // ignore collections
//                     if (p.PropertyType != typeof(string) && p.PropertyType.GetInterface(nameof(System.Collections.IEnumerable)) != null)
//                         continue;

//                     // ignore ID fields
//                     if (keyFields.Any(x => x.Name == p.Name))
//                         continue;

//                     var existingValue = p.GetValue(entity);
//                     if (!Equals(p.GetValue(item), existingValue))
//                     {
//                         p.SetValue(item, existingValue);
//                     }
//                 }

//                 // also update key values on incoming data item where appropriate
//                 foreach (var idField in keyFields.Where(p => p.GetSetMethod() != null && p.GetGetMethod() != null))
//                 {
//                     var existingValue = idField.GetValue(item);
//                     if (!Equals(idField.GetValue(entity), existingValue))
//                     {
//                         idField.SetValue(entity, existingValue);
//                     }
//                 }
//             }
//         }

//         private static Expression ReplaceParameter(Expression oldExpression, ParameterExpression newParameter)
//         {
//             switch (oldExpression.NodeType)
//             {
//                 case ExpressionType.MemberAccess:
//                     var m = (MemberExpression)oldExpression;
//                     return Expression.MakeMemberAccess(newParameter, m.Member);
//                 case ExpressionType.New:
//                     var newExpression = (NewExpression)oldExpression;
//                     var arguments = new List<Expression>();
//                     foreach (var a in newExpression.Arguments)
//                         arguments.Add(ReplaceParameter(a, newParameter));
//                     var returnValue = Expression.New(newExpression.Constructor, arguments.ToArray());
//                     return returnValue;
//                 default:
//                     throw new NotSupportedException("Unknown expression type for AddOrUpdate: " + oldExpression.NodeType);
//             }
//         }
//     }
// }
