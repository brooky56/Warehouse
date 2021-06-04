using DataModel.Entity.EntityContext.DataConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataModel.Entity.EntityContext
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Устанавливает начальную конфигурацию
        /// </summary>
        /// <param name="modelBuilder">Model API builder instance</param>
        public static void SetConfiguration(this ModelBuilder modelBuilder)
        {
            var entityConfigurationsList = new List<IDataConfiguration>();

            var assembly = typeof(IDataConfiguration).Assembly;
            var nspace = typeof(UserEntityConfiguration).Namespace;

            var entityTypes = assembly.GetExportedTypes()
                        .Where(t => t.Namespace == nspace)
                        .ToList();

            foreach (var type in entityTypes)
            {
                entityConfigurationsList.Add((IDataConfiguration)type.Assembly.CreateInstance(type.FullName));
            }

            entityConfigurationsList.ForEach(en => en.ConfigureData(modelBuilder));

        }
    }
}
