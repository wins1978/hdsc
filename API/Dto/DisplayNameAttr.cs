using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class DisplayNameAttribute : Attribute
    {
        public string Name { get; }
        public DisplayNameAttribute(string sValue)
        {
            Name = sValue;
        }
    }
}
