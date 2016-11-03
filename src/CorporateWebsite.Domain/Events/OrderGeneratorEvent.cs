using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateWebsite.Domain.Events.Bus;

namespace CorporateWebsite.Domain.Events
{
    /// <summary>
    /// 订单生成事件
    /// </summary>
    public class OrderGeneratorEvent : IEvent
    {
        #region 手机短信发送字段

        /// <summary>
        /// 站点编号
        /// </summary>
        public string StationCode { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string PetitionerName { get; set; }
        
        /// <summary>
        /// 申请人所在省份
        /// </summary>
        public string ProvinceId { get; set; }

        /// <summary>
        /// 申请人电话
        /// </summary>

        public string PetitionerPhone { get; set; }

        /// <summary>
        ///  手机短信接收电话
        /// </summary>

        public string PhoneNumber { get; set; }
        #endregion

    }
}
