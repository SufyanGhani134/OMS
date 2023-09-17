using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class EnumStringValueAttribute : Attribute
    {
        public string Value { get; }

        public EnumStringValueAttribute(string value)
        {
            Value = value;
        }
    }
    public class Resolution
    {
        public enum resolution
        {
            [EnumStringValue("720p")]
            low,
            [EnumStringValue("1080p")]
            medium = 1080,
            [EnumStringValue("2k or 1440p")]
            high = 1440,
            [EnumStringValue("4k or 2160p")]
            ultraHigh = 2160
        }
    }
}