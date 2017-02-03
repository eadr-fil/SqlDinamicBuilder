using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamicSqlBuilder
{
    /// <summary>
    /// Builder command strings to SQL servers 
    /// </summary>
    public static class SqlBuilder
    {
        /// <summary>
        /// Build string to delete data from table.
        /// </summary>
        /// <param name="TableName">Table name for delete items</param>
        /// <returns></returns>
        public static string Delete(string TableName)
        {
            return String.Format("DELETE FROM {0}", TableName);
        }
    }
}
