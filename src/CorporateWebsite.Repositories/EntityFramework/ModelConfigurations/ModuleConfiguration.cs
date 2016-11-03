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
  public class ModuleConfiguration : EntityTypeConfiguration<Module>
    {
        public ModuleConfiguration()
        {

            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasOptional(c => c.ParentModule).WithMany(c => c.ChildModules).HasForeignKey(d => d.ParentId);
        }
    }
}
