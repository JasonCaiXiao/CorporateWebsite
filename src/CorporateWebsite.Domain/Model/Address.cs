﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebsite.Domain.Model
{
    /// <summary>
    /// 值对象[为多个属性的组合，数据库中并没有这张表]
    /// </summary>
    public class Address
    {
        // 国家
        public string Country { get; set; }

        //省份
        public string State { get; set; }

        // 市
        public string City { get; set; }

        public string Street { get; set; }

        public string Zip { get; set; }
       

       
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            Address another = obj as Address;
            if (another == null)
                return false;

            return this.Country.Equals(another.Country) &&
                this.State.Equals(another.State) &&
                this.City.Equals(another.City) &&
                this.Street.Equals(another.Street) &&
                this.Zip.Equals(another.Zip);
        }

        public override int GetHashCode()
        {
            return this.Country.GetHashCode() ^
                this.State.GetHashCode() ^
                this.City.GetHashCode() ^
                this.Street.GetHashCode() ^
                this.Zip.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}, {3}, {4}", Zip, Street, City, State, Country);
        }
       
        public static bool operator ==(Address a, Address b)
        {
            if (a == null)
            {
                return b == null;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Address a, Address b)
        {
            return !(a == b);
        }
    }
}
