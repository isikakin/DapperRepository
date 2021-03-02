namespace DapperProject.Commands.Queries
{
    public class SelectByIdCommand<T> : BaseCommand<T> where T : class
    {
        public override string GenerateQuery()
        {
            return $"SELECT * FROM {_tableName} WHERE Id = @Id";
        }
    }
}
