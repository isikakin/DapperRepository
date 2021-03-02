namespace DapperProject.Commands.Queries
{
    public class DeleteCommand<T> : BaseCommand<T> where T : class
    {
        public override string GenerateQuery()
        {
            return $"DELETE FROM {_tableName} WHERE Id = @Id";
        }
    }
}
