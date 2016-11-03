using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebsite.Domain.Model
{
    [Description("用户信息")]
    public sealed class User : EntityBase<int>, IAggregateRoot
    {
        public User()
        {
            this.UserGroups = new List<UserGroup>();
            this.Roles = new List<Role>();
        }

        [Required]
        [Description("用户名")]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [Description("密码")]
        [StringLength(32)]
        public string Password { get; set; }

        [Required]
        [Description("真实姓名")]
        [StringLength(20)]
        public string TrueName { get; set; }

        [Required]
        [Description("邮箱")]
        [StringLength(50)]
        public string Email { get; set; }

        [Description("电话")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Description("地址")]
        [StringLength(300)]
        public string Address { get; set; }

        [Display(Name = "是否激活")]
        public bool Enabled { get; set; }
        /// <summary>
        /// 用户组集合
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// 用户拥有的角色信息集合
        /// </summary>
        public ICollection<Role> Roles { get; set; }

    }
}
