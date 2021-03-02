using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace DapperProject.Commands.Queries
{
    public abstract class BaseCommand<T> where T : class
    {
        public readonly string _tableName;

        protected BaseCommand()
        {
            _tableName = typeof(T).GetCustomAttribute<TableAttribute>(true).Name;
        }

        public virtual List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        public virtual IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        public abstract string GenerateQuery();
    }
}
