using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebsite.Domain.Model
{
    public abstract class EntityBase<TKey>
    {
        protected EntityBase()
        {
            UpdateDate = DateTime.Now;
        }
        [Key]
        public TKey Id { get; set; }
       
        /// <summary>
        ///     获取或设置 添加时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }
    }
}
