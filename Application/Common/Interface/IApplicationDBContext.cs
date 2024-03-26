using Domain.Master;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interface;

public interface IApplicationDBContext
{
    /// <summary>
    /// dbset for the application settings
    /// </summary>
    DbSet<AppSetting> AppSettings { get; set; }    
    /// <summary>
    /// Creates a DbSet that can be used to query and save instances of entity
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A set for the given entity type</returns>
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
}
