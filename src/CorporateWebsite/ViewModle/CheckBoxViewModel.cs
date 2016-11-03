using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorporateWebsite.ViewModle
{
    /// <summary>
    /// CheckBox控件数据模型
    /// </summary>
    public class CheckBoxViewModel
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public string Discription { get; set; }

        public bool IsChecked { get; set; }
    }
}