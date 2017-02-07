using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DinamicSqlBuilder
{
    /// <summary>
    /// static class for creating query strings to SQL servers 
    /// </summary>
    public static class SqlBuilder
    {
        /// <summary>
        ///     static method for creating string for delete data from table.
        /// </summary>
        /// <param name="tableName">Table name for delete items</param>
        /// <returns></returns>
        public static string Delete(string tableName)
        {
            return String.Format("DELETE FROM {0}", tableName);
        }
        /// <summary>
        ///     static method for creating query string for insert data to table.
        /// </summary>
        /// <param name="tableName">Table name for insert items</param>
        /// <param name="itemsList">List of table items for insert</param>
        /// <returns></returns>
        public static string Insert(string tableName, object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + tableName.ToUpper() + " (");

            //object o = Activator.CreateInstance(obj);
            //dynamic d = obj;
            //int i = d.id;

            //Type type = typeof(objType);


            PropertyInfo[] info = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in info)
            {
                sb.Append(item.Name + ", ");
            }
            sb.Remove(sb.Length - 2, 2);

            sb.Append(@") VALUES (");
            foreach (var item in info)
            {
                var propertyName = item.Name;
                var propertyValue = obj.GetType().GetProperty(propertyName).GetValue(obj, null);

                if (item.PropertyType == typeof(string))
                {
                    sb.Append("'" + propertyValue.ToString() + "', ");
                }
                else
                {
                    if (item.PropertyType == typeof(Boolean))
                    {
                        if (propertyValue.ToString() == true.ToString())
                        {
                            sb.Append("1, ");
                        }
                        else
                        {
                            sb.Append("0, ");
                        }
                    }
                    else
                    {
                        sb.Append(propertyValue.ToString() + ", ");
                    }
                }
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(@")");
            return sb.ToString();
        }
    }
}
