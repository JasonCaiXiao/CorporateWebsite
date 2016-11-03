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
   public class UserGroupConfiguration : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupConfiguration()
        {
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasMany(g => g.Users).WithMany(u => u.UserGroups);
            this.HasMany(g => g.Roles).WithMany(r => r.UserGroups);
        }
    }
}
