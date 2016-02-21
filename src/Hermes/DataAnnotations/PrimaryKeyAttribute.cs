using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
        public string PrimaryKeyName { get; set; }

        public PrimaryKeyAttribute()
        {
        }
    }
}
