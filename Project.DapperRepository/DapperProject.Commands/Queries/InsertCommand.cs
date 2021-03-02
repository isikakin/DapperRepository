using System.Text;

namespace DapperProject.Commands.Queries
{
    public class InsertCommand<T> : BaseCommand<T> where T : class
    {
        public override string GenerateQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop =>
            {
                //Id generated automatically by database
                if (!prop.Equals("Id"))
                {
                    insertQuery.Append($"[{prop}],");
                }
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop =>
            {
                //Id generated automatically by database
                if (!prop.Equals("Id"))
                {
                    insertQuery.Append($"@{prop},");
                }
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }
    }
}
