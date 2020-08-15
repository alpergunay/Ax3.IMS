using System;

namespace Ax3.IMS.DataAccess.EntityFramework
{
    public sealed class SqlColumnTypeAttribute : Attribute
    {
        public string ColumnType { get; private set; }

        public SqlColumnTypeAttribute(string columnType)
        {
            ColumnType = columnType;
        }
    }
}