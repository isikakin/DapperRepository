using System;
using System.Collections.Generic;
using System.Text;

namespace DapperProject.Commands.Queries
{
    public class QueryFactory
    {
        public string GetCommand<T>(BaseCommand<T> command) where T : class
        {
            return command.GenerateQuery();
        }
    }
}
