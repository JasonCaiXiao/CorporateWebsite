using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebsite.Domain
{
    /// <summary>
    /// 领域实体接口
    /// 用作泛型约束，表示继承自该接口的为领域实体
    /// </summary>
    public interface IEntity
    {
        // 当前领域实体的全局唯一标识
        int Id { get; }
    }
}
