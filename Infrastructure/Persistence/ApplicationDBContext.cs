using Application.Common.Interface;
using Domain.Common;
using Domain.Master;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, ICurrentUserService currentUserService) : IdentityDbContext<ApplicationUser>(options), IApplicationDBContext
    {

        #region Properties
        private readonly DateTime _currentDateTime;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        #endregion

        #region Ctor
        //public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, ICurrentUserService currentUserService)
        //  : base(options)
        //{
        //    _currentDateTime = DateTime.Now;
        //    _currentUserService = currentUserService;
        //}
        #endregion

        #region Master
        public DbSet<AppSetting> AppSettings { get; set; }
        
        #endregion

        public async Task<int> SaveChangesAsync()
        {
           
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                var currentUserID = _currentUserService.UserId;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Author = currentUserID; //Get Current UsereID
                        entry.Entity.Created = _currentDateTime;
                        entry.Entity.Editor = currentUserID; //Get Current UsereID
                        entry.Entity.Modified = _currentDateTime;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Editor = currentUserID; //Get Current UsereID
                        entry.Entity.Modified = _currentDateTime;
                        break;
                }
            }
            return await base.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
