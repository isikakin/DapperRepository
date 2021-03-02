using System;
using System.Collections.Generic;
using System.Text;

namespace DapperProject.Commands.Queries
{
    public class SelectCommand<T> : BaseCommand<T> where T : class
    {
        public override string GenerateQuery()
        {
            return $"SELECT * FROM {_tableName}";
        }
    }
}
