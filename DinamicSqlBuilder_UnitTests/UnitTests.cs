using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DinamicSqlBuilder;

namespace DinamicSqlBuilder_UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Get_Delete_Sql_String()
        {
            //arrange
            string tableName1 = "tableName1";
            string tableName2 = "tableName2";
            string tableName3 = "tableName3";
            //action
            string res1 = SqlBuilder.Delete(tableName1);
            string res2 = SqlBuilder.Delete(tableName2);
            string res3 = SqlBuilder.Delete(tableName3);            
            //assert
            Assert.AreEqual(res1, "DELETE FROM tableName1");
            Assert.AreEqual(res2, "DELETE FROM tableName2");
            Assert.AreEqual(res3, "DELETE FROM tableName3");
            Assert.IsTrue(res3 == "DELETE FROM tableName3");
        }
    }
}
