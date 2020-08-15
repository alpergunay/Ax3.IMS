using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;

namespace Ax3.IMS.DataAccess.EntityFramework
{
    public static class ModelBuilderExtensions
    {
        internal static bool IsEnabledSoftDelete = false;

        public static ModelBuilder SnakeCaseifyNames(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(CamelCaseToSnakeCase(entity.GetTableName()));
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(CamelCaseToSnakeCase(property.GetColumnName()));
                }
            }

            return modelBuilder;
        }

        public static ModelBuilder EnableSoftDelete(this ModelBuilder modelBuilder)
        {
            IsEnabledSoftDelete = true;

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.AddProperty("is_deleted", typeof(bool));

                var parameter = Expression.Parameter(entityType.ClrType);

                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("is_deleted"));

                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty,
                    Expression.Constant(false));
                var lambda = Expression.Lambda(compareExpression, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
            return modelBuilder;
        }

        private static string CamelCaseToSnakeCase(string clrName)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < clrName.Length; i++)
            {
                var c = clrName[i];
                if (char.IsUpper(c))
                {
                    if (i > 0)
                        sb.Append('_');
                    sb.Append(char.ToLowerInvariant(c));
                    continue;
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}