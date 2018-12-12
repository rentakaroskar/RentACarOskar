using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class DateTimePicker : Attribute
    {
        public bool ReadOnly;

        public DateTimePicker(bool readOnly)
        {
            ReadOnly = readOnly;
        }
    }
}
