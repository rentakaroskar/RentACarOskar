﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class SqlNameAttribute : Attribute
    {
        string Name;

        public SqlNameAttribute(string name)
        {
            Name = name;
        }
    }
}
