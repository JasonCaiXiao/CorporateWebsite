using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebsite.Domain.Model
{
    /// <summary>
    /// 权限---实体
    /// </summary>
    [Description("权限")]
    public sealed class Permission : EntityBase<int>, IAggregateRoot
    {
        public Permission()
        {
            this.Roles = new List<Role>();
        }

        [Required]
        [Description("名称")]
        [StringLength(20)]
        public string Name { get; set; }

        [Description("权限编码")]
        public string Code { get; set; }

        [Description("描述")]
        [StringLength(100)]
        public string Description { get; set; }

        public bool Enabled { get; set; }

        [Description("所属模块Id")]
        public int ModuleId { get; set; }

        public Module module { get; set; }

        /// <summary>
        /// 角色集合
        /// </summary>   
        public ICollection<Role> Roles { get; set; }

       
    }
}
