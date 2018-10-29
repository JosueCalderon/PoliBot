using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public abstract class EntityMapper
    {
        protected string GetStringValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is string s)
                return s;

            return "";
        }

        protected int GetIntValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is int || val is decimal))
                return (int)dic[attName];

            return -1;
        }

        protected double GetDoubleValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is double)
                return (double)dic[attName];

            return -1;
        }

        protected DateTime GetDateTimeValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is DateTime)
                return (DateTime)dic[attName];

            return DateTime.Now;
        }

        protected bool GetBoolValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is bool)
                return (bool)dic[attName];
            return false;
        }
    }
}
