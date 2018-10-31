using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using Dapper;
using OrmSource.Attribute;
using OrmSource.SqlConnection;

namespace OrmSource.Method
{
    public static class Operate
    {
        public static int Insert<T>(this T model, bool isIncludeKeyColumn = false)
        {
            var type = typeof(T);

            var tableName = GetTableName(type);
            var columns = new List<string>();

            columns = GetProperityList(type, model);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(" insert into  ");
            stringBuilder.Append(tableName);
            stringBuilder.Append(" (");
            var loop = columns.Count;

            for (var i = 1; i < loop; i++)
            {
                stringBuilder.Append(columns[i]);

                if (i != loop - 1) stringBuilder.Append(",");
            }

            stringBuilder.Append(") values (");
            for (var i = 1; i < loop; i++)
            {
                stringBuilder.Append(" @");
                stringBuilder.Append(columns[i]);

                if (i != loop - 1) stringBuilder.Append(",");
            }

            stringBuilder.Append(");");

            PropertyInfo propertyInfo = null;
            var dapperParameters = new DynamicParameters(model);

            for (var i = 0; i < loop; i++)
            {
                propertyInfo = type.GetProperty(columns[i]);
                dapperParameters.Add("@" + columns[i], propertyInfo.GetValue(model, null),
                    GetMySqlDbType(propertyInfo.PropertyType));
            }

            if (isIncludeKeyColumn == false)
                return OrmSqlConnection.SqlConnection().Execute(stringBuilder.ToString(), dapperParameters,
                    commandType: CommandType.Text);
            return OrmSqlConnection.SqlConnection().Execute(stringBuilder.ToString(), propertyInfo);
        }

        public static string GetTableName(Type type)
        {
            var property = (PropertyAttribute) type.GetCustomAttributes(false)[0];
            return property.tableName;
        }

        public static List<string> GetProperityList<T>(Type type, T model)
        {
            var property = type.GetProperties();

            var properList = new List<string>();
            foreach (var info in property) properList.Add(info.Name);
            return properList;
        }

        private static DbType GetMySqlDbType(Type type)
        {
            var sqlDbType = DbType.String;

            if (type == typeof(string))
            {
            }
            else if (type == typeof(int))
            {
                sqlDbType = DbType.Int32;
            }
            else if (type == typeof(bool))
            {
                sqlDbType = DbType.Byte;
            }
            else if (type == typeof(DateTime))
            {
                sqlDbType = DbType.DateTime;
            }

            return sqlDbType;
        }
    }
}