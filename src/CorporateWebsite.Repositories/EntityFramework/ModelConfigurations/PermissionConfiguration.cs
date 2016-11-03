using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateWebsite.Domain.Model;

namespace CorporateWebsite.Repositories.EntityFramework.ModelConfigurations
{
   public class PermissionConfiguration : EntityTypeConfiguration<Permission>
    {
        public PermissionConfiguration()
        {
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasMany(r => r.Roles).WithMany(u => u.Permissions);
            this.HasRequired(c => c.module).WithMany(c => c.Permissions).HasForeignKey(d => d.ModuleId);
        }
    }
}
