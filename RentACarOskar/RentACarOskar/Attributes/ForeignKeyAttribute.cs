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
        string TableName;
        string ColumnName;

        public ForeignKeyAttribute(string tableName, string columnName)
        {
            TableName = tableName;
            ColumnName = columnName;
        }
    }
}
