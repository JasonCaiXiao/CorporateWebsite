using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CorporateWebsite.Domain.Model;
using CorporateWebsite.Repositories.EntityFramework.ModelConfigurations;

namespace CorporateWebsite.Repositories.EntityFramework
{
    public class CaiXiaoDbContext : DbContext
    {
        public CaiXiaoDbContext() : base("CaiXiaoDbContext")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
            //CreateDatabaseIfNotExists :如果数据库不存在，那么就创建数据库。但是如果数据库存在了，而且实体发生了变化，就会出现异常。
            //DropCreateDatabaseIfModelChanges 此策略表明:如果模型变化了，数据库就会被重新创建，原来的数据库被删除掉了
            //DropCreateDatabaseAlways 此策略表示:每次运行程序都会重新创建数据库，这在开发和调试的时候非常有用
            Database.SetInitializer(new DropCreateDatabaseAlways<CaiXiaoDbContext>());
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Module> Modules { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            //移除一对多的级联删除约定，【想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制,级联删除是在WithMany返回的对象中设定的。】
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //移除一对一的级联删除约定
            //modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();
            //移除多对多的级联删除约定
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PermissionConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ModuleConfiguration());
            modelBuilder.Configurations.Add(new UserGroupConfiguration());
        }
    }
}
