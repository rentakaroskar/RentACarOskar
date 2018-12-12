using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class ForeignKeyAttribute : Attribute
    {
        public string TableName;
        public string ColumnName;
        public string ClassName;

        public ForeignKeyAttribute(string tableName, string columnName, string className)
        {
            TableName = tableName;
            ColumnName = columnName;
            ClassName = className;
        }
    }
}
